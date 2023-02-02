using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFormacion : MonoBehaviour
{
    private List<GameObject> guerrerosList;
    private float timeControl = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        guerrerosList = Spawner.GuerrerosList;
    }
    // Update is called once per frame
    void Update()
    {
        timeControl += Time.deltaTime;
        if (timeControl >= 5f)
        {
            CrearFormacion(guerrerosList, ObtenerPuntoMedio(guerrerosList));
            timeControl= 0f;
        }
    }

    private Vector2 ObtenerPuntoMedio(List<GameObject> lista)
    {
        float xmin = lista[0].transform.position.x;
        float xmax = lista[0].transform.position.x;
        float ymin = lista[0].transform.position.y;
        float ymax = lista[0].transform.position.y;

        foreach (GameObject go in lista)
        {
            if (go.transform.position.x > xmax)
            {
                xmax= go.transform.position.x;
            }
            if (go.transform.position.x < xmin)
            {
                xmin= go.transform.position.x;
            }
            if (go.transform.position.y > ymax)
            {
                ymin= go.transform.position.y;
            }
            if (go.transform.position.y < ymin)
            {
                ymax= go.transform.position.y;
            }
        }
        return new Vector2(xmax-xmin, ymax-ymin);
    }
    private void CrearFormacion(List<GameObject> lista, Vector2 puntoMedio)
    {
        float posx = 5f;
        float posy = 4f;

        foreach (GameObject go in lista)
        {
            go.transform.Translate(puntoMedio.x + posx, puntoMedio.y + posy, puntoMedio.y + posy);
            posy -= 0.5f;
            if(posy <= -4f)
            {
                posx -= 0.5f;
                posy = 4f;
            }
            Debug.Log(go.GetInstanceID()+" x ="+go.transform.position.x+" y="+go.transform.position.y);
        }
    }
    public List<GameObject> GetGuerrerosList
    {
        get { return this.guerrerosList; }
    }
    public List<GameObject> SetGuerrerosList
    {
        set { this.guerrerosList = value; }
    }
}
