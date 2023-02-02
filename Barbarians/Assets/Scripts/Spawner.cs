using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    //Constantes con rango de zona para el spawn
    //0:rango1x 1:rango2x 2:rango1y 3:rango2y
    private readonly float[] zonaBar = { -7f, -15f, -1f, -5f};
    private readonly float[] zonaDem = { 7f, 15f, -1f, -5f };

    [SerializeField] private GameObject guerreroObject;
    [SerializeField] private GameObject diablilloObject;
    [SerializeField] private int guerrerosNum;
    [SerializeField] private int diablilloNum;

    private GameObject thisBarbarian;
    private GameObject thisDemon;
    private static List<GameObject> guerrerosList;
    // Start is called before the first frame update
    void Start()
    {
        guerrerosList = SpawnBarbarians(guerreroObject, guerrerosNum);
        SpawnDemons(diablilloObject, diablilloNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<GameObject> SpawnBarbarians(GameObject unidad,int conteo)
    {
        Vector2 posicion;
        List<GameObject> barbarianList = new();
        if (conteo > 0)
        {
            for (int i = 0; i < conteo; i++)
            {
                posicion = RandomPosition(zonaBar[0], zonaBar[1], zonaBar[2], zonaBar[3]);
                thisBarbarian = Instantiate(unidad, posicion, Quaternion.identity) as GameObject;
                thisBarbarian.transform.position = new Vector3(posicion.x, posicion.y, posicion.y);
                barbarianList.Add(thisBarbarian);
                Debug.Log(thisBarbarian.transform.position.ToString());
            }
        }
        else Debug.Log("no hay "+unidad.gameObject.name+" que spawnear");
        return barbarianList;
    }
    private void SpawnDemons(GameObject unidad,int conteo)
    {
        Vector2 posicion;
        if (conteo > 0)
        {
            for (int i = 0; i < conteo; i++)
            {
                posicion = RandomPosition(zonaDem[0], zonaDem[1], zonaDem[2], zonaDem[3]);
                thisDemon = Instantiate(unidad, posicion, Quaternion.identity) as GameObject;
                thisDemon.transform.position = new Vector3(posicion.x, posicion.y, posicion.y);
                Debug.Log(thisDemon.transform.position.ToString());
            }
        }
        else Debug.Log("no hay " + unidad.gameObject.name + " que spawnear");
    }
    private Vector2 RandomPosition(float range1x,float range2x,float range1y,float range2y)
    {
        return new Vector2(UnityEngine.Random.Range(range1x, range2x), UnityEngine.Random.Range(range1y, range2y));
    }
    
    public static List<GameObject> GuerrerosList
    {
        get { return guerrerosList; }
    }
}
