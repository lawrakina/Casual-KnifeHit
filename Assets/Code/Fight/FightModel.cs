using UniRx;
using UnityEngine;


namespace Code.Fight{
    [CreateAssetMenu(fileName = nameof(FightModel), menuName = "Models/"+nameof(FightModel))]
    public class FightModel: ScriptableObject{
        public float FightTimer{ get; set; }
        public int QueueOfKnivesCount{ get; set; }
        public ReactiveProperty<FightState> FightState{ get; set; }
        public int DificultyLevel{ get; set; }
    }

    public enum FightState{
        Process,
        Win,
        Loss
    }
}