using System.Collections.Generic;
using UnityEngine;


namespace Code.Data{
    [CreateAssetMenu(fileName = nameof(ListKnivesData), menuName = "Configs/" + nameof(ListKnivesData))]
    public class ListKnivesData : ScriptableObject{
        public List<Transform> List;
    }
}