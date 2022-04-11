using System;
using UnityEngine;


namespace Code.Knife{
    public interface IKnife{
        Guid Id{ get; }
        Transform View{ get; }
        Rigidbody2D Rigidbody2D{ get; }
        KnifeState State{ get; set; }
    }
}