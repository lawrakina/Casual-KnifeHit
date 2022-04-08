using System.Collections.Generic;
using UnityEngine;


namespace Code.Data{
    [CreateAssetMenu(fileName = nameof(ListBosses), menuName = "Configs/" + nameof(ListBosses))]
    public class ListBosses : ScriptableObject{
        public List<Transform> List;
    }
}