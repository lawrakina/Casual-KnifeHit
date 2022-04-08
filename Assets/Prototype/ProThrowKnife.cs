using System.Collections;
using System.Collections.Generic;
using Code.Extensions;
using Prototype;
using UnityEngine;

public class ProThrowKnife : MonoBehaviour{
    [SerializeField]
    private Transform _startPosition;
    [SerializeField]
    private ProKnife _knife;
    public void ThrowKnife(){
        var knife = Instantiate(_knife, _startPosition);
        var rb = knife.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector2(0f, 200f));
    }
}
