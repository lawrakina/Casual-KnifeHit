using System.Collections.Generic;
using UnityEngine;


namespace Code.Data{
    [CreateAssetMenu(fileName = nameof(ListOfLevels), menuName = "Configs/" + nameof(ListOfLevels))]
    internal class ListOfLevels : ScriptableObject{
        public List<Level.Level> List;
    }
}