using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        SpawnBarbarians(guerreroObject, guerrerosNum);
        SpawnDemons(diablilloObject, diablilloNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBarbarians(GameObject unidad,int conteo)
    {
        for (int i = 0; i < conteo; i++)
        {
            Instantiate(unidad, RandomPosition(zonaBar[0], zonaBar[1], zonaBar[2], zonaBar[3]), Quaternion.identity);
        }
    }
    private void SpawnDemons(GameObject unidad,int conteo)
    {
        for (int i = 0; i < conteo; i++)
        {
            Instantiate(unidad, RandomPosition(zonaDem[0], zonaDem[1], zonaDem[2], zonaDem[3]),Quaternion.identity);
        }
    }
    private Vector3 RandomPosition(float range1x,float range2x,float range1y,float range2y)
    {
        return new Vector3(UnityEngine.Random.Range(range1x, range2x), UnityEngine.Random.Range(range1y, range2y), 0f);
    }

}
