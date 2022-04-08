using System;
using UnityEngine;


namespace Code.Data{
    [CreateAssetMenu(fileName = nameof(PlayerProgress), menuName = "Configs/" + nameof(PlayerProgress))]
    internal class PlayerProgress : ScriptableObject{
        public int Attempts{ get; set; }
        public int Score{ get; set; }
        public DateTime InstallDateTime{ get; set; }
    }
}