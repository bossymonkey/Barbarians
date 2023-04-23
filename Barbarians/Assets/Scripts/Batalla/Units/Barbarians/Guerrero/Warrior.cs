using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Unit
{
    [NonSerialized] public BarbarianEnemySeeker targeter;
    [NonSerialized] public WarriorStateMachine sm;
    [NonSerialized] public Animator anim;

    private float armorBonus = 0;

    private void Awake()
    {
        targeter = GetComponent<BarbarianEnemySeeker>();
        sm = GetComponent<WarriorStateMachine>();
        anim = GetComponent<Animator>();
    }



    public float ArmorBonus
    {
        get { return armorBonus; }
        set { armorBonus = value; }
    }
}
