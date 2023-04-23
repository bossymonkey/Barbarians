using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorChargeState : MonoBehaviour
{
    private Warrior w;

    private void Awake()
    {
        w = GetComponent<Warrior>();
    }
    private void Update()
    {
        if (w.targeter.Target != null)
        {
            Charge();
        }
        else
        {
            w.sm.ActivateState(w.sm.advance);
        }
    }
    private void Charge()
    {
        transform.position = Vector3.MoveTowards(transform.position, w.targeter.Target.transform.position, (w.Speed+0.5f)*Time.deltaTime);
        w.anim.SetTrigger("avanzando");
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("demon"))
        {
            w.anim.SetTrigger("quieto");
            w.StopMovingTowards();
            w.sm.ActivateState(w.sm.attack);
        }
    }
}
