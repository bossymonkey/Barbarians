using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{

    private GameObject[,] tiles = new GameObject[MAXTILESX, MAXTILESY]; 
    [SerializeField]private GameObject tileobject;
    public const int MAXTILESX = 90;
    public const int MAXTILESY = 30;
    private Vector3 initPos = new Vector3(-45f,2f,-9f);
    private Vector3 actualPos;

    public void InstanceTiles()
    {
        GameObject instanceUnit;

        for (int i = 0; i < MAXTILESX; i++)
        {
            for (int j = 0; j < MAXTILESY; j++)
            {
                actualPos = new Vector3(initPos.x + i, initPos.y - j, initPos.z);
                instanceUnit = Instantiate(tileobject, actualPos, Quaternion.identity);
                instanceUnit.GetComponent<TileScript>().Tileposx = i;
                instanceUnit.GetComponent<TileScript>().Tileposy = j;
                instanceUnit.GetComponent<TileScript>().enabled = false;
                tiles[i, j] = instanceUnit;
            }
        }
    }
    public GameObject[,] Tiles 
    {
        get { return tiles; }
        set { tiles = value; }
    }
}
