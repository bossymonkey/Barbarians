using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttackState : MonoBehaviour
{
    private Warrior w;
    private float time;

    private void Awake()
    {
        w = GetComponent<Warrior>();
        time = w.AttackSpeed;
    }
    private void Update()
    {
        time += Time.deltaTime; 
        if (w.targeter.Target == null)
        {
            w.sm.ActivateState(w.sm.advance);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == w.targeter.Target)
        {
            if (time > w.AttackSpeed)
            {
                Attack(w.targeter.Target);
            }
        }
        else if(col.gameObject.CompareTag("demon"))
        {
            w.targeter.Target = col.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        w.sm.ActivateState(w.sm.advance);
    }
    private void Attack(GameObject go)
    {
        Debug.Log(gameObject.name + " ha atacado a " + go.name);
        time = 0f;
    }
}
