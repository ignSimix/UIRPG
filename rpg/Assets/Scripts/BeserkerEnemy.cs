using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeserkerEnemy : Enemy
{
    [SerializeField] private int AggressionGain = 5;
    public override int Attack()
    {
        aggression += AggressionGain;
        return aggression / 10;
    }
}
