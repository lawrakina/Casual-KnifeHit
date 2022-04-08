using System;
using Code.Extensions;
using UnityEngine;


namespace Prototype{
    public class ProTarget : MonoBehaviour{
        private void Update(){
            transform.Rotate(Vector3.back, Time.deltaTime * 80f);
        }

        private void OnCollisionEnter2D(Collision2D other){
            if (other.transform.TryGetComponent(out ProKnife knife)){
                Dbg.Log($"В цель попали:{other}");
                other.transform.SetParent(this.transform);
                other.rigidbody.bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
}