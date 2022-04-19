using System;
using Code.Target;
using UnityEngine;


namespace Code.Enemy{
    [Serializable]
    public class Enemy {
        public TargetView View;
        public bool IsBoss;
    }
}