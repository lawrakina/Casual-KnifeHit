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

        private void Awake(){
            var gameData = new GameData{
                TargetPosition = _targetPosition,
                ThorwPosition = _throwPosition,
                GameState = new ReactiveProperty<GameState>{Value = _stateAfterStart},
                PlayerData = LoadPlayerSettings(),
                EnemiesData = LoadEnemiesSettings(),
                KnivesData = LoadKnivesData()
            };

            var mainController = new MainController(true, gameData);

            Controllers.Init();
        }

        private PlayerData LoadPlayerSettings(){
            var result = new PlayerData();
            result.Progress = ResourceLoader.LoadConfig<PlayerProgress>();
            // result.Purchases....
            return result;
        }

        private EnemiesData LoadEnemiesSettings(){
            var result = new EnemiesData();
            result.ListStandardEnemies = ResourceLoader.LoadConfig<ListStandardEnemies>();
            result.ListBosses = ResourceLoader.LoadConfig<ListBosses>();
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