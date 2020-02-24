using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFireball : Fireball
{
    void Start()
    {
        MoveSpeed = 1f;
        LivesToRemove = 1;
        Type = Element.FIRE;
    }
}
