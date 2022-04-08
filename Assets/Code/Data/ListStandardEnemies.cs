using System.Collections.Generic;
using UnityEngine;


namespace Code.Data{
    [CreateAssetMenu(fileName = nameof(ListStandardEnemies), menuName = "Configs/" + nameof(ListStandardEnemies))]
    public class ListStandardEnemies : ScriptableObject{
        public List<Transform> List;
    }
}