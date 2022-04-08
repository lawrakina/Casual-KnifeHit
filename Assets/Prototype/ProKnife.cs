using System;
using Code.Extensions;
using UnityEngine;


namespace Prototype{
    public class ProKnife : MonoBehaviour{
        private void OnCollisionEnter2D(Collision2D other){
            if (other.transform.TryGetComponent(out ProTarget target)){
                Dbg.Log($"Попадание в цель");
            }else if (other.transform.TryGetComponent(out ProKnife knife)){
                Dbg.Log($"Ножом в нож!");
                knife.transform.SetParent(null);
                knife.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }

        // public void OnCollision(GameObject gameObject){
        //     if (gameObject.TryGetComponent(out ProTarget target)){
        //         Dbg.Log($"Попадание в цель");
        //     }else if (gameObject.TryGetComponent(out ProKnife knife)){
        //         Dbg.Log($"Ножом в нож!");
        //         knife.transform.SetParent(null);
        //     }
        // }
    }
}