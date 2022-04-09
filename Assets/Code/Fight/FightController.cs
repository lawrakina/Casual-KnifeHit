using System.Collections.Generic;
using System.Linq;
using Code.BaseControllers;
using Code.BaseControllers.Interfaces;
using Code.Data;
using Code.Extensions;
using Code.Knife;
using UnityEngine;


namespace Code.Fight{
    internal class FightController : BaseController{
        private readonly GameData _gameData;

        public FightController(GameData gameData) : base(true){
            _gameData = gameData;

            var fightModel = ResourceLoader.LoadModel<FightModel>();
            fightModel.DificultyLevel = 0;
            var targetController = new TargetFightController(_gameData, fightModel);
            // var knifeController = new KnifeFightController(_gameData, fightModel);
        }
    }

    internal class TargetFightController : BaseController, IExecute{
        private readonly GameData _gameData;
        private readonly FightModel _model;
        private GameObject _view;
        private Level _level;
        
        /// <summary>
        /// variables for Variable rotation target
        /// </summary>
        private float _timeToLerp = 0.0f;
        private float _minSpeedRotateTarget;
        private float _maxSpeedRotateTarget;

        public TargetFightController(GameData gameData, FightModel model) : base(true){
            _gameData = gameData;
            _model = model;

            var levels = _gameData.EnemiesData.Levels.List.Where
                    (x => x.DificultyLevel == _model.DificultyLevel).ToArray();
            _level = levels[Random.Range(0, levels.Length)];
            _minSpeedRotateTarget = _level.SpeedRotation - _level.SpeedDelta;
            _maxSpeedRotateTarget = _level.SpeedRotation + _level.SpeedDelta;

            var enemies = _gameData.EnemiesData.ListEnemies.List.Where(x => x.IsBoss == _level.IsBossLevel).ToArray();
            var enemy = enemies[Random.Range(0, enemies.Length)];
            
            _view = ResourceLoader.InstantiateObject(enemy.View, _gameData.TargetPosition, true);
        }

        public void Execute(float deltaTime){
            if (_model.FightState.Value == FightState.Process){
                if(!_level.VariableSpeed)
                    _view.transform.Rotate(Vector3.back, Time.deltaTime * _level.SpeedRotation);
                else{
                    _view.transform.Rotate(Vector3.back, Mathf.Lerp(_minSpeedRotateTarget, _maxSpeedRotateTarget, _timeToLerp));
                    if (_timeToLerp > 1.0f){
                        //switch without release memory 
                        _maxSpeedRotateTarget -= _minSpeedRotateTarget;
                        _minSpeedRotateTarget += _maxSpeedRotateTarget;
                        _maxSpeedRotateTarget = _minSpeedRotateTarget - _maxSpeedRotateTarget;
                        _timeToLerp = 0.0f;
                    }    
                }
            }
        }
    }
}