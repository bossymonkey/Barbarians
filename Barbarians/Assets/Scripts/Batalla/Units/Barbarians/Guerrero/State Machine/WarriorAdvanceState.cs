using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAdvanceState : MonoBehaviour
{

    private Warrior w;

    private void Awake()
    {
        w= GetComponent<Warrior>();
    }
    private void Update()
    {
        if (w.targeter.Target == null)
        {
            Advance();
        }
        else
        {
            w.sm.ActivateState(w.sm.charge);
        }
    }
    private void Advance()
    {
        transform.Translate(w.Speed*Time.deltaTime,0,0);
        w.anim.SetTrigger("avanzando");
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("demon"))
        {
            w.anim.SetTrigger("quieto");
            w.StopTranslate();
            w.sm.ActivateState(w.sm.attack);
        }
    }
}
