using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WarriorDefenceState : MonoBehaviour
{
    private Warrior w;
    private float time;

    private void Awake()
    {
        w = GetComponent<Warrior>();
    }
    private void OnEnable()
    {
        time = 0f;
        Stop();
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (w.targeter.GotTarget && time>5f)
        {
            Defend();
        }
        else if(!w.targeter.GotTarget) 
        {
            w.sm.ActivateState(w.sm.advance);
        }
        else
        {
            w.sm.ActivateState(w.sm.charge);
        }
    }
    private void Stop()
    {
        transform.Translate(0, 0, 0);
        w.anim.SetTrigger("quieto");
    }
    private void Defend()
    {
        w.ArmorBonus = 2;
        w.anim.SetTrigger("defendiendo");
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("demon"))
        {
            w.sm.ActivateState(w.sm.attack);
        }
    }
}
