using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    private List<GameObject> demonTiles = new();
    private List<GameObject> humanTiles = new();
    [SerializeField] private GameObject warrior;
    [SerializeField] private int warriorCount;
    [SerializeField] private GameObject imp;
    [SerializeField] private int impCount;

    public static BattleController instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

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
    public List<GameObject> DemonTiles
    {
        get { return demonTiles; }
        set { demonTiles = value; }
    }
    public List<GameObject> HumanTiles
    {
        get { return humanTiles; }
        set { humanTiles = value; }
    }
}
