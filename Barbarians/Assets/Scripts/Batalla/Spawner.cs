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
    public readonly float[] pool = { -20f, -15f, -20f, -15f };

    [SerializeField] public GameObject guerreroObject;
    [SerializeField] public GameObject diablilloObject;
    [SerializeField] public int guerrerosNum;
    [SerializeField] public int diablilloNum;

    public static Spawner Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void SpawnUnits(GameObject unit,int cont, float range1x, float range2x, float range1y, float range2y)
    {
        GameObject instanceUnit;

        if (cont > 0)
        {
            for (int i = 0; i < cont; i++)
            {
                instanceUnit = Instantiate(unit, RandomPosition(range1x, range2x, range1y, range2y), Quaternion.identity);
                if (unit.CompareTag("demon"))
                {
                    UnitBattleController.Instance.demons[unit.name].Add(instanceUnit);
                }
                else if (unit.CompareTag("barbarian"))
                {
                    UnitBattleController.Instance.barbarians[unit.name].Add(instanceUnit);
                }
            }
            Debug.Log("unidades de tipo " + unit + " instanciadas con exito");
        }
        else Debug.Log("no hay "+ unit +" que spawnear");
    }

    private Vector2 RandomPosition(float range1x,float range2x,float range1y,float range2y)
    {
        return new Vector2(UnityEngine.Random.Range(range1x, range2x), UnityEngine.Random.Range(range1y, range2y));
    }
}
