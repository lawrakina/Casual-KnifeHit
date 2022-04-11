using System.Collections.Generic;
using Code.Data;
using Code.Knife;
using UniRx;
using UnityEngine;


namespace Code.Fight{
    [CreateAssetMenu(fileName = nameof(FightModel), menuName = "Models/"+nameof(FightModel))]
    public class FightModel: ScriptableObject{
        [SerializeField]
        public ReactiveProperty<Level.Level> Level{ get; set; }
        public float FightTimer{ get; set; }
        public Queue<IKnife> QueueOfKnivesCount{ get; set; }
        public ReactiveProperty<FightState> FightState{ get; set; }
        public int DificultyLevel{ get; set; }
        public ReactiveCommand OnThrowKnife{ get; set; }
        public IKnife ActiveKnife{ get; set; }
    }

    public enum FightState{
        Fight,
        Win,
        Loss
    }
}