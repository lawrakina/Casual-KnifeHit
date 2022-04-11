using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class TargetView : MonoBehaviour
{
    public ReactiveCommand<GameObject> OnCollisionEnter2d = new ReactiveCommand<GameObject>();

    private void OnCollisionEnter2D(Collision2D other){
        OnCollisionEnter2d.Execute(other.gameObject);
    }
}