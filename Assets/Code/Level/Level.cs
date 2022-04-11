using System;


namespace Code.Level{
    [Serializable] public class Level{
        public int DificultyLevel = 0;
        public float SpeedRotation = 80.0f;
        public bool VariableSpeed = false;
        public float SpeedDelta = 30.0f;
        public float DurationOfVariableSpeed = 1.0f;
        public int KnivesCount = 6;
        public int ObstacleCountMin = 0;
        public int ObstacleCountMax = 2;
        public bool IsBossLevel = false;
    }
}