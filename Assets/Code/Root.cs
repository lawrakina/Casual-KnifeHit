using Code.BaseControllers;
using UniRx;
using UnityEngine;


namespace Code{
    public class Root : MonoBehaviour{
        private Controllers _controllers;
        private ReactiveProperty<GameState> _gameState;
        
        [SerializeField]
        private GameState _stateAfterStart = GameState.HelloWindow;

        private void Awake(){
            _controllers = new Controllers();
            _gameState = new ReactiveProperty<GameState>{Value = _stateAfterStart};

            var mainController = new MainController(_gameState);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            _controllers.FixedExecute(deltaTime);
        }

        private void OnDestroy(){
            _controllers.Dispose();
        }
    }
}