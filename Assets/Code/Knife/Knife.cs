using System;
using UniRx;
using UnityEngine;


namespace Code.Knife{
    [Serializable] public class Knife : MonoBehaviour, IKnife{
        [SerializeField]
        private Guid _id;
        public Guid Id => _id;
        public Transform View => transform;
        public Collider2D Collider2D{ get; set; }
        public Rigidbody2D Rigidbody2D{ get; set; }
        public KnifeState State{ get; set; }

        public ReactiveCommand<GameObject> OnCollisionEnter2d = new ReactiveCommand<GameObject>();

        private void OnCollisionEnter2D(Collision2D other){
            OnCollisionEnter2d.Execute(other.gameObject);
        }
    }
}