using System.Linq;
using Code.BaseControllers;
using Code.BaseControllers.Interfaces;
using Code.Data;
using Code.Extensions;
using Code.Knife;
using UniRx;
using UnityEngine;


namespace Code.Fight{
    internal class KnifeFightController : BaseController{
        private readonly GameData _gameData;
        private readonly FightModel _model;

        public KnifeFightController(bool active, GameData gameData, FightModel model) : base(active){
            _gameData = gameData;
            _model = model;

            _model.Level.Subscribe(OnChangeLevel).AddTo(_subscriptions);
            _model.OnThrowKnife.Subscribe(_ => ThrowKnife()).AddTo(_subscriptions);
        }

        private void OnChangeLevel(Level.Level level){
            for (int i = 0; i < level.KnivesCount; i++){
                var item = ResourceLoader.InstantiateObject(
                    _gameData.KnivesData.List.List.FirstOrDefault(x =>
                        x.Id == _gameData.PlayerData.Progress.ActiveKnife), _gameData.ThorwPosition, true);
                item.View.gameObject.SetActive(false);
                item.Collider2D = item.View.GetComponent<Collider2D>();
                item.Rigidbody2D = item.View.GetComponent<Rigidbody2D>();
                item.OnCollisionEnter2d.Subscribe(CollisionOnTarget).AddTo(_subscriptions);
                
                AddGameObjects(item.gameObject);
                
                _model.QueueOfKnivesCount.Enqueue(item);

                _model.HitCountsForWin++;
            }

            var knife = _model.QueueOfKnivesCount.Dequeue();
            ActivateKnife(knife);
        }

        private void CollisionOnTarget(GameObject other){
            if (other.transform.TryGetComponent(out TargetView target)){
                Dbg.Log($"Попадание в цель");

                _model.HitCounts.Value++;
            } else if (other.transform.TryGetComponent(out IKnife knife)){
                Dbg.Log($"Ножом в нож!");
                
                knife.View.transform.SetParent(null);
                knife.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                _model.ActiveKnife.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                
                _model.FightState.Value = FightState.Loss;
            }
        }

        private void ActivateKnife(IKnife knife){
            knife.View.gameObject.SetActive(true);
            knife.Collider2D.isTrigger = true;
            knife.Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            _model.ActiveKnife = knife;
        }

        private void ThrowKnife(){
            // _model.ActiveKnife.View.position = _model.ActiveKnife.View.position + new Vector3(0f,2,0f);
            _model.ActiveKnife.Collider2D.isTrigger = false;
            _model.ActiveKnife.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _model.ActiveKnife.Rigidbody2D.AddForce(new Vector2(0f, _gameData.PlayerData.Progress.ForceOfThrowing));

            if (_model.QueueOfKnivesCount.Count > 0)
                ActivateKnife(_model.QueueOfKnivesCount.Dequeue());
        }
    }
}