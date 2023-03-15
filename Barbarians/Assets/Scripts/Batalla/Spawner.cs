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
    private readonly float[] pool = { -20f, -15f, -20f, -15f };

    [SerializeField] private GameObject guerreroObject;
    [SerializeField] private GameObject diablilloObject;
    [SerializeField] private int guerrerosNum;
    [SerializeField] private int diablilloNum;

    private static bool ready = false;

    void Start()
    {
        SpawnUnits(guerreroObject, guerrerosNum, pool[0], pool[1], pool[2], pool[3]);
        SpawnUnits(diablilloObject, diablilloNum, pool[0], pool[1], pool[2], pool[3]);

        ready= true;
    }


    private void SpawnUnits(GameObject unit,int cont, float range1x, float range2x, float range1y, float range2y)
    {
        GameObject instanceUnit;

        if (cont > 0)
        {
            for (int i = 0; i < cont; i++)
            {
                instanceUnit = Instantiate(unit, RandomPosition(range1x, range2x, range1y, range2y), Quaternion.identity);
                instanceUnit.GetComponent<UnitController>().Id = i;
            }
            Debug.Log("unidades de tipo " + unit + " instanciadas con exito");
        }
        else Debug.Log("no hay "+unit+" que spawnear");
    }

    private Vector2 RandomPosition(float range1x,float range2x,float range1y,float range2y)
    {
        return new Vector2(UnityEngine.Random.Range(range1x, range2x), UnityEngine.Random.Range(range1y, range2y));
    }
    public static bool Ready
    {
        get { return ready; }
        set { ready = value; }
    }
}
