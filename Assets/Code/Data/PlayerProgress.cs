using System;
using UnityEngine;


namespace Code.Data{
    [CreateAssetMenu(fileName = nameof(PlayerProgress), menuName = "Configs/" + nameof(PlayerProgress))]
    internal class PlayerProgress : ScriptableObject{
        public int Attempts;
        public int Score;
        public DateTime InstallDateTime;
        public Guid ActiveKnife;
        public float ForceOfThrowing = 200.0f;
    }
}