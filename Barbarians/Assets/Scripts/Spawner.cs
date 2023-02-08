using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Timeline;
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



    void Start()
    {
        SpawnUnits(guerreroObject, guerrerosNum, zonaBar[0], zonaBar[1], zonaBar[2], zonaBar[3]);
        SpawnUnits(diablilloObject, diablilloNum, zonaDem[0], zonaDem[1], zonaDem[2], zonaDem[3]);
    }


    void Update()
    {

    }

    private void SpawnUnits(GameObject unit,int cont, float range1x, float range2x, float range1y, float range2y)
    {
        GameObject instanceUnit;

        if (cont > 0)
        {
            for (int i = 0; i < cont; i++)
            {
                instanceUnit = Instantiate(unit, RandomPosition(range1x, range2x, range1y, range2y), Quaternion.identity);
                instanceUnit.SetActive(false);
                instanceUnit.GetComponent<UnitController>().Id = i;
            }
        }
        else Debug.Log("no hay "+unit+" que spawnear");
    }

    private Vector2 RandomPosition(float range1x,float range2x,float range1y,float range2y)
    {
        return new Vector2(UnityEngine.Random.Range(range1x, range2x), UnityEngine.Random.Range(range1y, range2y));
    }
}
