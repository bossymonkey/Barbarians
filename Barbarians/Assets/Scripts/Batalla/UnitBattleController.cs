using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBattleController : MonoBehaviour
{
    [SerializeField] private List<GameObject> barbarians;
    [SerializeField] private List<GameObject> demons;

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
    }

    public List<GameObject> GetBarbarians() { return barbarians; }
    
    public List<GameObject> GetDemons() { return demons; }

}
