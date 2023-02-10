using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiablilloComportamiento : MonoBehaviour
{
    private GameObject target;
    private Animator animator;
    private UnitController uc;

    private bool combatiendo = false;
    private float timeControlAtaque = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        uc = this.GetComponent<UnitController>();
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
            if (timeControlAtaque >= uc.VelocidadAtaque)
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
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 1, transform.position.y,transform.position.z), uc.VelocidadMovimiento * Time.deltaTime);
        animator.SetBool("avanzando", true);
    }
    private void Cargar()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, uc.VelocidadMovimiento * Time.deltaTime);
        animator.SetBool("avanzando", true);
    }
    private void Atacar()
    {
        animator.SetBool("atacando", true);
        animator.SetBool("avanzando", false);
    }
    private void FinAtaque()
    {
        target.GetComponent<UnitController>().Vida -= uc.Ataque;
        timeControlAtaque = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("barbarian"))
        {
            combatiendo = true;
            target = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        combatiendo = false;
    }
}
