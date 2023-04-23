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
        w.StopTranslate();
        w.StopMovingTowards();
    }
    private void Update()
    {
        if(w.targeter.Target != null)
        {
            time += Time.deltaTime;
            Defend();
            if (time >= 5f)
            {
                w.ArmorBonus = 0;
                w.sm.ActivateState(w.sm.charge);
            }
        }
        else
        {
            w.sm.ActivateState(w.sm.advance);
        }

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
            w.anim.SetTrigger("quieto");
            w.StopTranslate();
            w.sm.ActivateState(w.sm.attack);
        }
    }
}
