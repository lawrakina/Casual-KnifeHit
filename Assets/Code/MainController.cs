using System;
using Code.BaseControllers;
using Code.Fight;
using UniRx;


namespace Code{
    internal class MainController : BaseController{
        private readonly GameData _gameData;
        private GameState _oldState = GameState.None;
        private FightController _fightController;

        public MainController(bool active, GameData gameData): base(active){
            _gameData = gameData;

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
                    _fightController = new FightController(_gameData);
                    break;
                case GameState.Ads:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}