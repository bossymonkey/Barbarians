using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UnitController : MonoBehaviour
{
    public static UnitController Instance { get; private set; }
    private GameObject target;

    private int id;
    [SerializeField] private string unitType;
    [SerializeField] private float vida;
    [SerializeField] private float ataque;
    [SerializeField] private float velocidadAtaque;
    [SerializeField] private float velocidadMovimiento;

    private float timeControlAtaque = 0f;

    private bool inController = false;
    private bool controllerOnce = true;
    private bool bhOnce = true;

    private void Start()
    {
        SetBehaviours(false);
    }

    private void FixedUpdate()
    {

        if (controllerOnce && GameController.MapsReady)
        {
            GetInController(GameController.Fcmap);
            controllerOnce = false;
        }
        if (bhOnce && GameController.FightReady)
        {
            SetBehaviours(true);
            bhOnce= false;
        }
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public GameObject EncontrarObjetivo(string tag)
    {
        return GameObject.FindGameObjectWithTag(tag);
    }

    public bool HayEnemigoCerca(GameObject target)
    {
        if (Vector2.Distance(transform.position, target.transform.position) < 4f || this.transform.position.x-target.transform.position.x < 2f)
            return true;
        else return false;
    }
    public void Avanzar()
    {
        if (this.gameObject.CompareTag("barbarian"))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        else transform.position += Vector3.left * Time.deltaTime;   
    }
    public void Cargar()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocidadMovimiento * Time.deltaTime);
    }

    public void Atacar()
    {
        
    }
    public void Esperar()
    {
        transform.position += Vector3.zero * Time.deltaTime;
    }
    public void Defender()
    {
        transform.position += Vector3.zero * Time.deltaTime;
    }

    public void FinAtaque()
    {
        target.GetComponent<UnitController>().Vida -= ataque;
        timeControlAtaque = 0f;
    }
    public void SetBehaviours(bool boolean)
    {
        foreach (Behaviour bh in this.GetComponents<Behaviour>())
        {
            if (this.GetComponent<UnitController>() != bh)
            {
                bh.enabled = boolean;
            }
        }
    }
    public void GetInController(Dictionary<string, FormationController> fcmap)
    {
        fcmap[unitType].ObjetosAFormar.Add(this.gameObject);
        inController= true;
    }
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string UnitType
    {
        get { return unitType; }
        set { unitType = value; }
    }
    public bool InController
    {
        get { return inController; }
        set { inController = value; }
    }
    public float Vida
    {
        get { return vida; }
        set { vida = value; }
    }
    public float Ataque
    {
        get { return ataque; }
        set { ataque = value; }
    }
    public float VelocidadAtaque
    {
        get { return velocidadAtaque; }
        set { velocidadAtaque = value; }
    }
    public float VelocidadMovimiento
    {
        get { return velocidadMovimiento; }
        set { velocidadMovimiento = value; }
    }
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
    public float TimeControlAtaque
    {
        get { return timeControlAtaque; }
        set { timeControlAtaque = value; }
    }
}
