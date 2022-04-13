using System;
using System.Collections.Generic;
using System.Linq;
using Code.BaseControllers;
using Code.BaseControllers.Interfaces;
using Code.Data;
using Code.Extensions;
using Code.Knife;
using Code.Ui.Fight;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Code.Fight{
    internal class FightController : BaseController{
        private readonly GameData _gameData;
        private readonly Transform _placeForUi;
        private Level.Level[] _levels;
        private FightModel _fightModel;
        private UiFightController _uiFightController;
        private TargetFightController _targetController;
        private KnifeFightController _knifeController;

        public FightController(GameData gameData, Transform placeForUi) : base(true){
            _gameData = gameData;
            _placeForUi = placeForUi;

            InitModel();
            
            _fightModel.Level.Subscribe(OnChangeLevel).AddTo(_subscriptions);
            _fightModel.FightState.Subscribe(OnChangeFightState).AddTo(_subscriptions);

            _uiFightController = new UiFightController(true,_gameData, _fightModel, _placeForUi);
            AddAsManagedController(_uiFightController);
            _targetController = new TargetFightController(true,_gameData, _fightModel);
            AddAsManagedController(_targetController);
            _knifeController = new KnifeFightController(true,_gameData, _fightModel);
            AddAsManagedController(_knifeController);

            _fightModel.FightState.Value = FightState.Fight;
        }

        private void InitModel(){
            _fightModel = ResourceLoader.LoadModel<FightModel>();
            _fightModel.Level = new ReactiveProperty<Level.Level>();
            _fightModel.FightState = new ReactiveProperty<FightState>();
            _fightModel.DificultyLevel = -1;
            _fightModel.QueueOfKnivesCount = new Queue<IKnife>();
            _fightModel.OnThrowKnife = new ReactiveCommand();
            _fightModel.HitCounts = new ReactiveProperty<int>();
        }

        private void OnChangeFightState(FightState state){
            switch (state){
                case FightState.Fight:
                    Dbg.Log($"Level Loading and started");
                    _fightModel.DificultyLevel++;
                    LoadLevel();
                    break;
                case FightState.Win:
                    //Show UI window of Winner
                    break;
                case FightState.Loss:
                    _fightModel.DificultyLevel = 0;
                    //Show UI window of Loos and return to main window
                    _gameData.GameState.Value = GameState.Menu;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void OnChangeLevel(Level.Level level){
            //sent to UI message of update level
        }
        
        private void LoadLevel(){
            _levels = _gameData.EnemiesData.Levels.List.Where
                (x => x.DificultyLevel == _fightModel.DificultyLevel).ToArray();
            Dbg.Warning($"Levels count:{_levels.Length}");
            _fightModel.Level.Value = _levels[Random.Range(0, _levels.Length)];
        }
    }
}