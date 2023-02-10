using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuerreroComportamiento : MonoBehaviour
{
    private UnitController uc;
    private Animator animator;

    private bool combatiendo = false;
    private float timeControlCarga = 0f;
    private bool enFormacion = false;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        uc = this.GetComponent<UnitController>();
    }

    private void FixedUpdate()
    {
        if (!combatiendo)
        {
            uc.Target = uc.EncontrarObjetivo("demon");
        }
        if (!combatiendo && uc.HayEnemigoCerca(uc.Target))
        {
            timeControlCarga += Time.deltaTime;
            if (timeControlCarga >= 3f) 
            {
                uc.Cargar();
                animator.SetTrigger("avanzando");
            }
            else
            {
                uc.Defender();
                animator.SetTrigger("defendiendo");
            }
        }
        else if(combatiendo)
        {
            uc.TimeControlAtaque += Time.deltaTime;
            if(uc.TimeControlAtaque >= uc.VelocidadAtaque)
            {
                uc.Atacar();
                animator.SetTrigger("atacando");
            }
            else
            {
                uc.Defender();
                animator.SetTrigger("defendiendo");
            }
        }
        else if(!enFormacion)
        {
            uc.Avanzar();
            animator.SetTrigger("avanzando");
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("demon"))
        {
            combatiendo = true;
            timeControlCarga = 0f;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        combatiendo = false;
    }
}
