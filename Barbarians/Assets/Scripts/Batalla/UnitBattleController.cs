using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBattleController : MonoBehaviour
{
    public Dictionary<string, List<GameObject>> barbarians = new();
    public Dictionary<string, List<GameObject>> demons = new();

    public static UnitBattleController Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this) 
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        demons.Add("Diablillo", new List<GameObject>());
        barbarians.Add("Guerrero", new List<GameObject>());
    }
}
