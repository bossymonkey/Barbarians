using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : Unit
{
    [NonSerialized] public Animator anim;
    private void Awake()
    {

        anim = GetComponent<Animator>();
    }
}
