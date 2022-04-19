using System;
using Code.BaseControllers;
using Code.Data;
using Code.Extensions;
using Code.Fight;
using UniRx;
using UnityEngine;


namespace Code.Ui.Fight{
    internal class UiFightController: BaseController{
        private readonly GameData _gameData;
        private readonly FightModel _fightModel;
        private readonly Transform _placeForUi;
        private FightUiView _view;
        private GameoverUiView _gameoverView;

        public UiFightController(bool active,GameData gameData, FightModel fightModel, Transform placeForUi): base(active){
            _gameData = gameData;
            _fightModel = fightModel;
            _placeForUi = placeForUi;

            _view = ResourceLoader.InstantiateObject(_gameData.UiElements.fightUiView, _placeForUi, false);
            _view.Init(_fightModel.OnThrowKnife);
            AddGameObjects(_view.GameObject);

            _gameoverView = ResourceLoader.InstantiateObject(_gameData.UiElements.GameoverUiView, _placeForUi, false);
            _gameoverView.Init(RestartFight, GoToMenu);
            AddGameObjects(_gameoverView.GameObject);

            _fightModel.FightState.Subscribe(OnChangeFightState).AddTo(_subscriptions);
        }
        
        private void RestartFight(){
            _gameData.GameState.Value = GameState.Fight;
        }

        private void GoToMenu(){
            _gameoverView.SetActive(false);
            _gameData.GameState.Value = GameState.Menu;
        }

        private void OnChangeFightState(FightState state){
            switch (state){
                case FightState.Fight:
                    _gameoverView.SetActive(false);
                    _view.SetActive(true);
                    break;
                case FightState.Win:
                    _gameoverView.SetActive(true);
                    _view.SetActive(false);
                    break;
                case FightState.Loss:
                    //need sending push up message
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}