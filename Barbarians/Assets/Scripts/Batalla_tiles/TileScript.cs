using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] private GameObject warrior;
    private GameObject unit;
    private int tileposx;
    private int tileposy;

    private void OnEnable()
    {
        if (unit != null)
        {
            Instantiate(unit,transform.position,Quaternion.identity).transform.parent = gameObject.transform;
        }
    }
    private void OnDisable()
    {
        if (unit == null)
        {
            Destroy(unit);
        }
        unit = null;
    }
    private void Update()
    {
        
    }
    public int Tileposx
    {
        get { return tileposx; }
        set { tileposx = value; }
    }
    public int Tileposy
    {
        get { return tileposy; }
        set { tileposy = value; }
    }
    public GameObject Unit
    {
        get { return unit; }
        set { unit = value; }
    }
    public GameObject Warrior
    {
        get { return warrior; }
        set { warrior = value; }
    }
}
