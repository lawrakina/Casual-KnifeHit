using Code.BaseControllers;
using UniRx;


namespace Code{
    internal class MainController : BaseController{
        private readonly ReactiveProperty<GameState> _gameState;

        public MainController(ReactiveProperty<GameState> gameState){
            _gameState = gameState;
        }
    }
}