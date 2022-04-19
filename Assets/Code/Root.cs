using Code.BaseControllers;
using Code.Data;
using Code.Extensions;
using DG.Tweening;
using UniRx;
using UnityEngine;


namespace Code{
    public class Root : MonoBehaviour{
        [SerializeField]
        private Transform _targetPosition;
        [SerializeField]
        private Transform _throwPosition;
        [SerializeField]
        private GameState _stateAfterStart = GameState.Fight;
        [SerializeField]
        private Transform _placeForUi;
        private void Awake(){
            var gameData = new GameData{
                TargetPosition = _targetPosition,
                ThorwPosition = _throwPosition,
                GameState = new ReactiveProperty<GameState>{Value = _stateAfterStart},
                PlayerData = LoadPlayerSettings(),
                GameSettings = LoadEnemiesSettings(),
                KnivesData = LoadKnivesData(),
                UiElements = LoadUiElements()
            };

            DOTween.Init();
            
            var mainController = new MainController(true, gameData, _placeForUi);

            gameData.GameState.Value = GameState.Menu;

            Controllers.RootMonoBehaviour = this;
            Controllers.Init();
        }

        private UiElements LoadUiElements(){
            return ResourceLoader.LoadConfig<UiElements>();
        }

        private PlayerData LoadPlayerSettings(){
            var result = new PlayerData();
            result.Progress = ResourceLoader.LoadConfig<PlayerProgress>();
            // result.Purchases....
            return result;
        }

        private GameSettings LoadEnemiesSettings(){
            var result = new GameSettings();
            result.Levels = ResourceLoader.LoadConfig<Levels>();
            result.ListEnemies = ResourceLoader.LoadConfig<ListEnemies>();
            return result;
        }

        private KnivesData LoadKnivesData(){
            var result = new KnivesData();
            result.List = ResourceLoader.LoadConfig<ListKnivesData>();
            return result;
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
            StopAllCoroutines();
            Controllers.Dispose();
        }
    }
}