using System;
using Code.BaseControllers;
using Code.Data;
using Code.Fight;
using UniRx;
using UnityEngine;


namespace Code{
    internal class MainController : BaseController{
        private readonly GameData _gameData;
        private readonly Transform _placeForUi;
        private GameState _oldState = GameState.None;
        private FightController _fightController;

        public MainController(bool active, GameData gameData, Transform placeForUi): base(active){
            _gameData = gameData;
            _placeForUi = placeForUi;

            _gameData.GameState.Subscribe(OnChangeGameState).AddTo(_subscriptions);
        }

        private void OnChangeGameState(GameState state){
            if(state == _oldState) return;

            switch (state){
                case GameState.None:
                    break;
                case GameState.HelloWindow:
                    break;
                case GameState.Menu:
                    break;
                case GameState.Fight:
                    _fightController = new FightController(_gameData, _placeForUi);
                    break;
                case GameState.Ads:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}