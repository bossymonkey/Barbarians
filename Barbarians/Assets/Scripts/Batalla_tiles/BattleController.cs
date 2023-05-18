using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    private List<GameObject> demonTiles;
    private List<GameObject> humanTiles;
    //true -> humanos, false -> demonios
    private bool turn;
    [SerializeField] private GameObject warrior;
    [SerializeField] private int warriorCount;
    [SerializeField] private GameObject imp;
    [SerializeField] private int impCount;

    public GameObject Warrior
    {
        get { return warrior; }
        set { warrior = value; }
    }
    public int WarriorCount
    {
        get { return warriorCount;}
        set { warriorCount = value; }
    }
    public GameObject Imp
    {
        get { return imp; }
        set { imp = value; }
    }
    public int ImpCount
    {
        get { return impCount; }
        set { impCount = value; }
    }
}
