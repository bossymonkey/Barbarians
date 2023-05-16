using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{

    private GameObject unit;
    private int tileposx;
    private int tileposy;


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

}
