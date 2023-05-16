using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    List<GameObject> tiles;
    [SerializeField]private GameObject tileobject;
    private const int MAXTILESX = 90;
    private const int MAXTILESY = 30;
    private Vector3 initPos = new Vector3(-45f,2f,-9f);
    private Vector3 actualPos;
    private TileScript tileScript;

    private void Start()
    {
        InstanceTiles();
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
                tileScript = instanceUnit.GetComponent<TileScript>();
                tileScript.Tileposx = i;
                tileScript.Tileposy = j;
            }
        }
    }
}
