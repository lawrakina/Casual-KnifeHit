using Code.BaseControllers;
using UnityEngine;


namespace Code{
    public class MainController : MonoBehaviour{
        private Controllers _controllers;

        private void Awake(){
            _controllers = new Controllers();
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
            _controllers.Cleanup();
        }
    }
}