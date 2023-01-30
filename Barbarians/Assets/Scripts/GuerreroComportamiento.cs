using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerreroComportamiento : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject target;
    private Animator animator;

    private float vida = 100f;
    private float ataque = 10f;
    private float velocidadAtaque = 0.80f;
    private float velocidadMovimiento = 1f;
    private bool combatiendo = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        target = EncontrarObjetivo();
        if (HayEnemigoCerca(target) && !combatiendo)
        {
            Cargar();
        }
        else if(combatiendo)
        {
            Defender();
            Atacar();
            
        }
        else
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
        if (Vector2.Distance(transform.position, target.transform.position) < 5f)
            return true;
        else return false;
    }

    private void Avanzar()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 1, transform.position.y), velocidadMovimiento * Time.deltaTime);
        
    }
    private void Cargar()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, velocidadMovimiento * Time.deltaTime);
        animator.SetBool("avanzando", true);
    }
    
    private void Atacar()
    {
        animator.SetBool("atacando", true);
    }

    private void Defender()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
        animator.SetBool("avanzando", false);
        animator.SetBool("luchando", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Debug.Log("colision");
            combatiendo = true;
        }
    }
}
