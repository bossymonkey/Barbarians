using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    //List<GameObject> tiles;
    private GameObject[,] tiles = new GameObject[MAXTILESX, MAXTILESY]; 
    [SerializeField]private GameObject tileobject;
    private const int MAXTILESX = 90;
    private const int MAXTILESY = 30;
    private Vector3 initPos = new Vector3(-45f,2f,-9f);
    private Vector3 actualPos;

    private void Start()
    {
        InstanceTiles();
        Spawn();
    }
    private void InstanceTiles()
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
    private void Spawn()
    {
        for(int i = 0; i < 2; i++)
        {
            for(int j = 0;j < MAXTILESY; j++)
            {
                tiles[i, j].GetComponent<TileScript>().Unit = tiles[i, j].GetComponent<TileScript>().Warrior;
                tiles[i, j].GetComponent<TileScript>().enabled = true;
            }
        }
    }
}
