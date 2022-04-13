using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeSliced : MonoBehaviour{
    [SerializeField] private SpriteRenderer _first;
    [SerializeField] private SpriteRenderer _second;
    [SerializeField] private SpriteRenderer _third;
    [SerializeField] private SpriteRenderer _fourth;
    private void Awake(){
        // Texture2D source = Texture2D.blackTexture;
        // Graphics.CopyTexture(GetComponent<SpriteRenderer>().sprite.texture, source); 
        Texture2D texture = GetComponent<SpriteRenderer>().sprite.texture;
       
        // var rect = new Rect(0,0, texture.width / 2, texture.height / 2);
        var rect1 = new Rect(0, 0, texture.width / 2, texture.height / 2);
        var rect2 = new Rect(texture.width/ 2, texture.width / 2, texture.width / 2, texture.height / 2);
        var rect3 = new Rect(0, texture.height / 2, texture.width / 2, texture.height / 2);
        var rect4 = new Rect(texture.width / 2, 0, texture.width / 2, texture.height / 2);
        // var rect = new Rect(texture.width / 4, texture.height / 4, texture.width / 2, texture.height / 2);

        var sprite1 = Sprite.Create(texture, rect1, Vector2.one);
        var sprite2 = Sprite.Create(texture, rect2, Vector2.zero);
        var sprite3 = Sprite.Create(texture, rect3, Vector2.right);
        var sprite4 = Sprite.Create(texture, rect4, Vector2.up);
        _first.GetComponent<SpriteRenderer>().sprite = sprite1;
        _second.GetComponent<SpriteRenderer>().sprite = sprite2;
        _third.GetComponent<SpriteRenderer>().sprite = sprite3;
        _fourth.GetComponent<SpriteRenderer>().sprite = sprite4;

        _first.gameObject.AddComponent<BoxCollider2D>();
        _second.gameObject.AddComponent<BoxCollider2D>();
        _third.gameObject.AddComponent<BoxCollider2D>();
        _fourth.gameObject.AddComponent<BoxCollider2D>();
        
        _first.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        _second.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 20, ForceMode2D.Impulse);
        _third.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50, ForceMode2D.Impulse);
        _fourth.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 80, ForceMode2D.Impulse);
    }
}
