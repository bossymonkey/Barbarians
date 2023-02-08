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
    private float timeControlCarga = 0f;
    private float timeControlAtaque= 0f;
    private bool enFormacion = false;
    private float timeControl = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator= this.GetComponent<Animator>();
    }

    // Update is called once per frame
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
            if(timeControlAtaque >= velocidadAtaque)
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
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1, transform.position.y,transform.position.z), velocidadMovimiento * Time.deltaTime);
        animator.SetBool("avanzando", true);
    }
    private void Cargar()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocidadMovimiento * Time.deltaTime);
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
    public bool EnFormacion
    {
        get;set;
    }
    public float VelocidadMovimiento
    {
        get; set;
    }
}
