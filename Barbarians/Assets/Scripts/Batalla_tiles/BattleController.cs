using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    private List<GameObject> demonTiles = new();
    private List<GameObject> humanTiles = new();
    [SerializeField] private GameObject warrior;
    [SerializeField] private int humanCount;
    [SerializeField] private GameObject imp;
    [SerializeField] private int impCount;
    [SerializeField] private GameObject berserker;
    [SerializeField] private int berserkerCount;
    [SerializeField] private GameObject knight;
    [SerializeField] private int knightCount;
    [SerializeField] private GameObject viking;
    [SerializeField] private int vikingCount;
    [SerializeField] private GameObject eye;
    [SerializeField] private int eyeCount;
    [SerializeField] private GameObject worm;
    [SerializeField] private int wormCount;
    [SerializeField] private GameObject devil;
    [SerializeField] private int devilCount;

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
    public bool CheckVictory()
    {
        if (demonTiles.Count == 0)
        {
            return true;
        }
        else if (humanTiles.Count == 0)
        {
            return true;
        }
        else return false;
    }

    public GameObject Warrior
    {
        get { return warrior; }
        set { warrior = value; }
    }
    public int WarriorCount
    {
        get { return humanCount;}
        set { humanCount = value; }
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

    public GameObject Berserker { get => berserker; set => berserker = value; }
    public int BerserkerCount { get => berserkerCount; set => berserkerCount = value; }
    public GameObject Knight { get => knight; set => knight = value; }
    public int KnightCount { get => knightCount; set => knightCount = value; }
    public GameObject Viking { get => viking; set => viking = value; }
    public int VikingCount { get => vikingCount; set => vikingCount = value; }
    public GameObject Eye { get => eye; set => eye = value; }
    public int EyeCount { get => eyeCount; set => eyeCount = value; }
    public GameObject Worm { get => worm; set => worm = value; }
    public int WormCount { get => wormCount; set => wormCount = value; }
    public GameObject Devil { get => devil; set => devil = value; }
    public int DevilCount { get => devilCount; set => devilCount = value; }
}
