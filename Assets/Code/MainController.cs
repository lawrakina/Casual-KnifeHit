using System;
using Code.BaseControllers;
using Code.BaseControllers.Interfaces;
using UniRx;


namespace Code{
    internal class MainController : BaseController{
        private readonly ReactiveProperty<GameState> _gameState;
        private GameState _oldState = GameState.None;

        public MainController(bool active, ReactiveProperty<GameState> gameState): base(active){
            _gameState = gameState;

            _gameState.Subscribe(OnChangeGameState).AddTo(_subscriptions);
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
                    // _fightController = new FightController();
                    break;
                case GameState.Ads:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}