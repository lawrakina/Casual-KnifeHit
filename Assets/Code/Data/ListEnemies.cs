using System.Collections.Generic;
using UnityEngine;


namespace Code.Data{
    [CreateAssetMenu(fileName = nameof(ListEnemies), menuName = "Configs/" + nameof(ListEnemies))]
    public class ListEnemies : ScriptableObject{
        public List<Enemy> List;
    }

    public class Enemy{
        public GameObject View;
        public bool IsBoss;
    }
}