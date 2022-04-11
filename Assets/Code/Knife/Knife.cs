using System;
using UnityEngine;


namespace Code.Knife{
    [Serializable]
    public class Knife : MonoBehaviour, IKnife{
        [SerializeField]
        private Guid _id;
        public Guid Id => _id;
        public Transform View => transform;
        public Rigidbody2D Rigidbody2D{ get; set; }
        public KnifeState State{ get; set; }
    }
}