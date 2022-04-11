using Code.BaseControllers;
using Code.Data;
using Code.Extensions;
using Code.Fight;
using UnityEngine;


namespace Code.Ui.Fight{
    internal class UiFightController: BaseController{
        private readonly GameData _gameData;
        private readonly FightModel _fightModel;
        private readonly Transform _placeForUi;
        private FightUiView _view;

        public UiFightController(GameData gameData, FightModel fightModel, Transform placeForUi): base(true){
            _gameData = gameData;
            _fightModel = fightModel;
            _placeForUi = placeForUi;

            _view = ResourceLoader.InstantiateObject(_gameData.UiElements.fightUiView, _placeForUi, false);
            _view.Init(_fightModel.OnThrowKnife);
        }
    }
}