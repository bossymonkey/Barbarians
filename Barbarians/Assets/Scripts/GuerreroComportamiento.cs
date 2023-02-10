using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuerreroComportamiento : MonoBehaviour
{

    private Animator animator;
    private GameObject target;
    private UnitController uc;

    private bool combatiendo = false;
    private float timeControlCarga = 0f;
    private float timeControlAtaque= 0f;
    private bool enFormacion = false;

    private void Start()
    {
        animator= this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        target = EncontrarObjetivo();

        if (!combatiendo && HayEnemigoCerca(target))
        {
            timeControlCarga += Time.deltaTime;
            if (timeControlCarga >= 3f) 
            {
                Cargar();
            }
            else
            {
                Defender();
            }
        }
        else if(combatiendo)
        {
            timeControlAtaque += Time.deltaTime;
            if(timeControlAtaque >= uc.VelocidadAtaque)
            {
                Atacar();
            }
            else
            {
                Defender();
            }
        }
        else if(!enFormacion)
        {
            Avanzar();
        }
    }

    private GameObject EncontrarObjetivo()
    {
        return GameObject.FindGameObjectWithTag("demon");
    }

    private bool HayEnemigoCerca(GameObject target)
    {
        if (Vector2.Distance(transform.position, target.transform.position) < 4f)
            return true;
        else return false;
    }

    private void Avanzar()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1, transform.position.y,transform.position.z), uc.VelocidadMovimiento * Time.deltaTime);
        animator.SetBool("avanzando", true);
    }
    private void Cargar()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, uc.VelocidadMovimiento * Time.deltaTime);
        animator.SetBool("defendiendo", false);
        animator.SetBool("avanzando", true);
    }
    
    private void Atacar()
    {
        animator.SetBool("defendiendo", false);
        animator.SetBool("atacando", true);
    }

    private void Defender()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z);
        animator.SetBool("avanzando", false);
        animator.SetBool("atacando", false);
        animator.SetBool("defendiendo", true);
    }

    private void FinAtaque()
    {
        target.GetComponent<UnitController>().Vida -= uc.Ataque;
        timeControlAtaque = 0f;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("demon"))
        {
            combatiendo = true;
            timeControlCarga = 0f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        combatiendo = false;
    }
    public bool EnFormacion
    {
        get;set;
    }
}
