using System.Linq;
using Code.BaseControllers;
using Code.Data;
using Code.Extensions;
using Code.Knife;
using UniRx;
using UnityEngine;


namespace Code.Fight{
    internal class KnifeFightController : BaseController{
        private readonly GameData _gameData;
        private readonly FightModel _model;

        public KnifeFightController(GameData gameData, FightModel model){
            _gameData = gameData;
            _model = model;

            _model.Level.Subscribe(OnChangeLevel).AddTo(_subscriptions);
            _model.OnThrowKnife.Subscribe(_ => ThrowKnife()).AddTo(_subscriptions);
        }

        private void OnChangeLevel(Level.Level level){
            for (int i = 0; i < level.KnivesCount; i++){
                var item = ResourceLoader.InstantiateObject(
                    _gameData.KnivesData.List.List.FirstOrDefault(x =>
                        x.Id == _gameData.PlayerData.Progress.ActiveKnife), _gameData.ThorwPosition, false);
                item.View.gameObject.SetActive(false);
                item.Rigidbody2D = item.View.GetComponent<Rigidbody2D>();
                _model.QueueOfKnivesCount.Enqueue(item);
            }

            var knife = _model.QueueOfKnivesCount.Dequeue();
            ActivateKnife(knife);
        }

        private void ActivateKnife(IKnife knife){
            knife.View.gameObject.SetActive(true);
            knife.Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            _model.ActiveKnife = knife;
        }

        private void ThrowKnife(){
            _model.ActiveKnife.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _model.ActiveKnife.Rigidbody2D.AddForce(new Vector2(0f, _gameData.PlayerData.Progress.ForceOfThrowing));
        }
    }
}