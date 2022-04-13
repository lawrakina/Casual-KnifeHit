using System;
using Code.BaseControllers;
using Code.BaseControllers.Interfaces;
using Code.Data;
using Code.Extensions;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Code.Ui.Menu{
    internal class MenuController : BaseController{
        private readonly GameData _gameData;
        private readonly Transform _placeForUi;
        private MenuUiView _view;

        public MenuController(GameData gameData, Transform placeForUi):base(true){
            _gameData = gameData;
            _placeForUi = placeForUi;

            _view = ResourceLoader.InstantiateObject(_gameData.UiElements.menuUiView, _placeForUi, false);

            _view.Init(StartFight, ShowInventory, ShowTopRating, GetBonus);
            AddGameObjects(_view.GameObject);
        }

        private void StartFight(){
            _gameData.GameState.Value = GameState.Fight;
        }
        private void ShowInventory(){
            
        }
        private void ShowTopRating(){
            
        }
        private void GetBonus(){
            
        }
    }
}