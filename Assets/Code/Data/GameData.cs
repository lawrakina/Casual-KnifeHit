using Code.Data;
using UniRx;
using UnityEngine;


namespace Code{
    internal struct GameData{
        public Transform TargetPosition{ get; set; }
        public Transform ThorwPosition{ get; set; }
        public ReactiveProperty<GameState> GameState{ get; set; }
        public PlayerData PlayerData{ get; set; }
        public EnemiesData EnemiesData{ get; set; }
        public KnivesData KnivesData{ get; set; }
    }
}