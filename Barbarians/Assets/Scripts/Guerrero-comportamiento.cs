using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject target;

    // Start is called before the first frame update
    private void Start()
    {
        float vida = 100f;
        float ataque = 10f;
        float velocidadAtaque = 0.80f;
        float velocidadMovimiento = 1f;
        bool combatiendo = false;

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    private bool BuscarEnemigo()
    {
        return true;
    }
}
