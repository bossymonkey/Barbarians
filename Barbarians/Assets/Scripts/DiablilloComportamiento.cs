using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiablilloComportamiento : MonoBehaviour
{
    private UnitController uc;
    private Animator animator;

    private bool combatiendo = false;
    
    void Start()
    {
        animator = this.GetComponent<Animator>();
        uc = this.GetComponent<UnitController>();
    }

    void FixedUpdate()
    {
        if (!combatiendo)
        {
            uc.Target = uc.EncontrarObjetivo("barbarian");
        }
        if(!combatiendo && uc.HayEnemigoCerca(uc.Target))
        {
            uc.Cargar();
            animator.SetTrigger("avanzando");
        }
        else if(combatiendo)
        {
            uc.TimeControlAtaque += Time.deltaTime;
            if (uc.TimeControlAtaque >= uc.VelocidadAtaque)
            {
                uc.Atacar();
                animator.SetTrigger("atacando");
            }
            else
            {
                uc.Esperar();
                animator.SetTrigger("quieto");
            }
        }
        else
        {
            uc.Avanzar();
            animator.SetTrigger("avanzando");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("barbarian"))
        {
            combatiendo = true;
            uc.Target = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        combatiendo = false;
    }
}
