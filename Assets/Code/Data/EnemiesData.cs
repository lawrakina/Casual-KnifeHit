using System.Collections.Generic;
using UnityEngine;


namespace Code.Data{
    internal class EnemiesData{
        public ListOfLevels Levels { get; set; }
        public ListEnemies ListEnemies{ get; set; }
    }

    
    
    [CreateAssetMenu(fileName = nameof(ListOfLevels), menuName = "Configs/" + nameof(ListOfLevels))]
    internal class ListOfLevels : ScriptableObject{
        public List<Level> List;
    }

    internal class Level{
        public int DificultyLevel;
        public float SpeedRotation;
        public bool VariableSpeed;
        public float SpeedDelta;
        public int KnivesCount;
        public int ObstacleCountMin;
        public int ObstacleCountMax;
        public bool IsBossLevel;
    }
}