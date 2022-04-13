using System;
using Code.BaseControllers;
using Code.Data;
using Code.Extensions;
using Code.Fight;
using Code.Ui.Menu;
using UniRx;
using UnityEngine;


namespace Code{
    internal class MainController : BaseController{
        private readonly GameData _gameData;
        private readonly Transform _placeForUi;
        private GameState _oldState = GameState.None;
        private FightController _fightController;
        private MenuController _menuController;

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
                    _fightController?.Dispose();
                    _menuController = new MenuController(_gameData, _placeForUi);
                    break;
                case GameState.Fight:
                    _fightController = new FightController(_gameData, _placeForUi);
                    _menuController?.Dispose();
                    break;
                case GameState.Ads:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}