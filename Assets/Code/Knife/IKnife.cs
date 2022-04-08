using System;
using UnityEngine;


namespace Code.Knife{
    internal interface IKnife{
        Guid Id{ get; }
        Transform View{ get; set; }
        KnifeState State{ get; set; }
    }
}