using Code.BaseControllers;
using UniRx;
using UnityEngine;


namespace Code{
    public class Root : MonoBehaviour{
        private ReactiveProperty<GameState> _gameState;
        
        [SerializeField]
        private GameState _stateAfterStart = GameState.HelloWindow;

        private void Awake(){
            _gameState = new ReactiveProperty<GameState>{Value = _stateAfterStart};

            var mainController = new MainController(true, _gameState);
            Controllers.Add(mainController);
            
            
            Controllers.Init();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            Controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            Controllers.LateExecute(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            Controllers.FixedExecute(deltaTime);
        }

        private void OnDestroy(){
            Controllers.Dispose();
        }
    }
}