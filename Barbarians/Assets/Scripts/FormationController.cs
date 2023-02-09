using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class FormationController
{
    private List<GameObject> objetosAFormar = new();
    private List<Vector3> posiciones = new();


    public void GetIds()
    {
        foreach (GameObject go in objetosAFormar)
        {
            Debug.Log(go + " is an active object " + go.GetInstanceID());
        }
    }
    public Vector3 GetMidpoint(List<GameObject> objetosAFormar)
    {
        float xmin = objetosAFormar[0].transform.position.x;
        float xmax = objetosAFormar[0].transform.position.x;
        float ymin = objetosAFormar[0].transform.position.y;
        float ymax = objetosAFormar[0].transform.position.y;

        foreach (GameObject go in objetosAFormar)
        {
            if (go.transform.position.x < xmin)
            {
                xmin = go.transform.position.x;
            }
            else if (go.transform.position.x > xmax)
            {
                xmax = go.transform.position.x;
            }
            if (go.transform.position.y < ymin)
            {
                ymin = go.transform.position.y;
            }
            else if (go.transform.position.y > ymax)
            {
                ymax = go.transform.position.y;
            }
        }
        return new Vector3((xmax + xmin) / 2, (ymax + ymin) / 2, (ymax + ymin) / 2);
    }
    public void PlaceUnitsFormation(Vector3 midPoint)
    {
        float posx = 0f;
        float posy = 8f;

        foreach (GameObject go in objetosAFormar)
        {
            go.transform.position = new Vector3(midPoint.x + posx, midPoint.y + posy, midPoint.y + posy);

            posy -= 1f;
            if (posy <= -8f)
            {
                posx -= 1f;
                posy = 8f;
            }
        }
    }
    public void PlaceWithoutFormation(Vector3 midPoint)
    {
        float yDiff = 8f;
        float xBack = 10f;
        float ypos;

        foreach (GameObject go in objetosAFormar)
        {
            ypos = Random.Range(midPoint.y + yDiff, midPoint.y - yDiff);
            go.transform.position = new Vector3(Random.Range(midPoint.x, midPoint.x + xBack), ypos, ypos);
        }
    }
    public List<Vector3> GetPositions(Vector3 midPoint)
    {
        List<Vector3> posiciones = new();
        Vector3 targetVector;
        float posx = 0f;
        float posy = 8f;

        foreach (GameObject go in objetosAFormar)
        {
            targetVector = new Vector3(midPoint.x + posx, midPoint.y + posy, midPoint.y + posy);
            posiciones.Add(targetVector);

            posy -= 1f;
            if (posy <= -8f)
            {
                posx -= 1f;
                posy = 8f;
            }
            //Debug.Log(targetVector);
        }

        return posiciones;
    }
    public List<GameObject> ObjetosAFormar
    {
        get { return objetosAFormar; }
        set { objetosAFormar = value; }
    }
    public List<Vector3> Posiciones
    {
        get { return posiciones; }
        set { posiciones = value; }
    }
}
