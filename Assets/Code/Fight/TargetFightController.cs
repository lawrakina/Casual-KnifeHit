using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Code.BaseControllers;
using Code.BaseControllers.Interfaces;
using Code.Data;
using Code.Extensions;
using Code.Knife;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Code.Fight{
    internal class TargetFightController : BaseController, IExecute{
        private readonly GameData _gameData;
        private readonly FightModel _model;
        private TargetView _view;
        private ReactiveProperty<Level.Level> _level;
        
        /// <summary>
        /// variables for Variable rotation target
        /// </summary>
        private float _timeToLerp = 0.0f;
        private float _minSpeedRotateTarget;
        private float _maxSpeedRotateTarget;

        public TargetFightController(bool active, GameData gameData, FightModel model) : base(active){
            _gameData = gameData;
            _model = model;
            _level = _model.Level;

            _level.Subscribe(OnChangeLevel).AddTo(_subscriptions);
            _model.FightState.Subscribe(OnChangeFightState).AddTo(_subscriptions);
        }

        private void OnChangeLevel(Level.Level level){
            if (_view){
                Object.Destroy(_view);
                _view = null;
            }
            
            _minSpeedRotateTarget = _level.Value.SpeedRotation - _level.Value.SpeedDelta;
            _maxSpeedRotateTarget = _level.Value.SpeedRotation + _level.Value.SpeedDelta;

            var enemies = _gameData.GameSettings.ListEnemies.List.Where(x => x.IsBoss == _level.Value.IsBossLevel).ToArray();
            var enemy = enemies[Random.Range(0, enemies.Length)];

            // StartCoroutine(); надо запустить кортину что бы инстантировать таргет в следующем после уничтожения кадре
            _view = ResourceLoader.InstantiateObject(enemy.View, _gameData.TargetPosition, false);
            
            _view.OnCollisionEnter2d.Subscribe(CollisionOn).AddTo(_subscriptions);

            AddGameObjects(_view.gameObject);
        }

        private void CollisionOn(GameObject other){
            if (other.transform.TryGetComponent(out IKnife knife)){
                Dbg.Log($"В цель попали:{other}");
                knife.View.transform.SetParent(_view.transform);
                knife.Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            }
        }
        
        private void OnChangeFightState(FightState state){
            switch (state){
                case FightState.Fight:
                    break;
                case FightState.Win:
                    Dbg.Log($"Destroy target");
                    //Destroy Target
                    
                    break;
                case FightState.Loss:
                    Dbg.Log($"Destroy target");
                    
                    Controllers.StartCoroutine(DeferredDestroy(_view.gameObject));
                    //Destroy target
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private IEnumerator DeferredDestroy(GameObject gameObject){
            yield return new WaitForSeconds(_gameData.GameSettings.Levels.WaitingTimeAtEndOfLevel);
            Object.Destroy(gameObject);
        }

        public void Execute(float deltaTime){
            if (_model.FightState.Value == FightState.Fight){
                if(!_level.Value.VariableSpeed)
                    _view.transform.Rotate(Vector3.back, Time.deltaTime * _level.Value.SpeedRotation);
                else{
                    _timeToLerp += Time.deltaTime;
                    _view.transform.Rotate(Vector3.back, Mathf.Lerp(Time.deltaTime *_minSpeedRotateTarget, Time.deltaTime *_maxSpeedRotateTarget, _timeToLerp));
                    if (_timeToLerp > _level.Value.DurationOfVariableSpeed){
                        //switch without release memory 
                        _maxSpeedRotateTarget -= _minSpeedRotateTarget;
                        _minSpeedRotateTarget += _maxSpeedRotateTarget;
                        _maxSpeedRotateTarget = _minSpeedRotateTarget - _maxSpeedRotateTarget;
                        _timeToLerp = 0.0f;
                    }    
                }
            }
        }

        public override void Dispose(){
            Controllers.StartCoroutine(DeferredDispose());
        }

        private IEnumerator DeferredDispose(){
            Dbg.Log($"Start Coroutine");
            foreach (var child in _view.GetComponentsInChildren<Transform>()){
                child.SetParent(null);
                if(child.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidBody))
                {
                    rigidBody.AddForce(Vector2.one, ForceMode2D.Impulse);
                }
            }

            yield return new WaitForSeconds(_gameData.GameSettings.Levels.WaitingTimeAtEndOfLevel);
            base.Dispose();
        }
    }
}