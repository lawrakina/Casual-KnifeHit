using System.Collections.Generic;
using UnityEngine;


namespace Code.Data{
    [CreateAssetMenu(fileName = nameof(Levels), menuName = "Configs/" + nameof(Levels))]
    internal class Levels : ScriptableObject{
        public float WaitingTimeAtEndOfLevel = 2.0f;
        public List<Level.Level> List;
    }
}