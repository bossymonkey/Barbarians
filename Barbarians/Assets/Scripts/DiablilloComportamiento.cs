using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiablilloComportamiento : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject target;
    private Animator animator;

    private float vida = 100f;
    private float ataque = 10f;
    private float velocidadAtaque = 0.80f;
    private float velocidadMovimiento = 1.5f;
    private bool combatiendo = false;
    private float timeControlAtaque = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = EncontrarObjetivo();
        if(!combatiendo && HayEnemigoCerca(target))
        {
            Cargar();
        }
        else if(combatiendo)
        {
            timeControlAtaque += Time.deltaTime;
            if (timeControlAtaque >= velocidadAtaque)
            {
                Atacar();
            }
            else
            {
                Esperar();
            }
        }
        else
        {
            Avanzar();
        }
    }
    private GameObject EncontrarObjetivo()
    {
        return GameObject.FindGameObjectWithTag("barbarian");
    }
    private bool HayEnemigoCerca(GameObject target)
    {
        if (Vector2.Distance(transform.position, target.transform.position) < 4f)
            return true;
        else return false;
    }
    private void Esperar()
    {
        animator.SetBool("atacando", false);
        animator.SetBool("avanzando", false);
    }
    private void Avanzar()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x - 1, transform.position.y), velocidadMovimiento * Time.deltaTime);
        animator.SetBool("avanzando", true);
    }
    private void Cargar()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, velocidadMovimiento * Time.deltaTime);
        animator.SetBool("avanzando", true);
    }
    private void Atacar()
    {
        animator.SetBool("atacando", true);
        animator.SetBool("avanzando", false);
    }
    private void FinAtaque()
    {
        timeControlAtaque = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("barbarian"))
        {
            combatiendo = true;
        }
    }
}
