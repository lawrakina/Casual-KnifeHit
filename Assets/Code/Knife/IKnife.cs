using System;
using UnityEngine;


namespace Code.Knife{
    public interface IKnife{
        Guid Id{ get; }
        Transform View{ get; }
        Collider2D Collider2D{ get; }
        Rigidbody2D Rigidbody2D{ get; }
        KnifeState State{ get; set; }
    }
}