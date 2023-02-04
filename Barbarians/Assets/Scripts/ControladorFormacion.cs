using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControladorFormacion
{

    public Vector2 ObtenerPuntoMedio(List<GameObject> lista)
    {
        float xmin = lista[0].transform.position.x;
        float xmax = lista[0].transform.position.x;
        float ymin = lista[0].transform.position.y;
        float ymax = lista[0].transform.position.y;
        float x = 0f;
        float y = 0f;

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
        Debug.Log("xmax: " + xmax + " xmin: " + xmin + " ymax: " + ymax + " ymin: " + ymin);
        return new Vector2((xmax+xmin)/2, (ymax+ymin)/2);
    }
    public void CrearFormacion(List<GameObject> lista, Vector2 puntoMedio)
    {
        float posx = 5f;
        float posy = 3f;
        Vector3 targetVector = new Vector3(0,0,0);

        foreach (GameObject go in lista)
        {
            targetVector = new Vector3(puntoMedio.x + posx, puntoMedio.y + posy, puntoMedio.y + posy);
            go.transform.position = Vector3.MoveTowards(go.transform.position,targetVector,1f *Time.deltaTime);
            
            
            go.GetComponent<Animator>().SetBool("avanzando", true);
            if(go.transform.position == targetVector)
            {
                go.GetComponent<Animator>().SetBool("avanzando", false);
            }
            
            posy -= 1f;
            if(posy <= -3f)
            {
                posx -= 1f;
                posy = 3f;
            }
            //Debug.Log(go.GetInstanceID()+" x ="+go.transform.position.x+" y="+go.transform.position.y);
        }
    }
    public List<GameObject> GenerarListaGuerreros()
    {
        return GameObject.FindGameObjectsWithTag("barbarian").ToList();
    }
}
