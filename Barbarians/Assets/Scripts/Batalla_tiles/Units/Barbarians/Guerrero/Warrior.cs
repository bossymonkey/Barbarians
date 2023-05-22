using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Warrior : Unit
{
    [NonSerialized] public Animator anim;

    private void Awake()
    {
        
        anim = GetComponent<Animator>();
    }
}
