using Code.BaseControllers;
using Code.Data;
using Code.Extensions;
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
                EnemiesData = LoadEnemiesSettings(),
                KnivesData = LoadKnivesData(),
                UiElements = LoadUiElements()
            };

            var mainController = new MainController(true, gameData, _placeForUi);

            gameData.GameState.Value = GameState.Fight;
            
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

        private EnemiesData LoadEnemiesSettings(){
            var result = new EnemiesData();
            result.Levels = ResourceLoader.LoadConfig<ListOfLevels>();
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
            Controllers.Dispose();
        }
    }
}