using UniRx;
using UnityEngine;


namespace Code.Data{
    internal class GameData{
        public Transform TargetPosition{ get; set; }
        public Transform ThorwPosition{ get; set; }
        public ReactiveProperty<GameState> GameState{ get; set; }
        public PlayerData PlayerData{ get; set; }
        public GameSettings GameSettings{ get; set; }
        public KnivesData KnivesData{ get; set; }
        public UiElements UiElements{ get; set; }
    }
}