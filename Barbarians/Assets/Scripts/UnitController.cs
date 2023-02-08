using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{

    private int id;
    [SerializeField]private string unitType;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string UnitType
    {
        get { return unitType; }
        set { unitType = value; }
    }
}
