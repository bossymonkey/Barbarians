using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class StartBattleRoutine : MonoBehaviour
{
    [SerializeField] BattleController battleController;
    [SerializeField] TileController tileController;
    public void Start()
    {
        StartCoroutine(InitialRoutine());
    }
    IEnumerator InitialRoutine()
    {
        Debug.Log("inicio");
        tileController.InstanceTiles();
        yield return null;
        Debug.Log("antes de Spawn");
        Spawn();
        Debug.Log("fuera");
        yield return null;
        StopAllCoroutines();
    }
    public void Spawn()
    {
        Debug.Log("dentro");
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < TileController.MAXTILESY; j++)
            {
                if (battleController.WarriorCount > 0)
                {
                    tileController.Tiles[i, j].GetComponent<TileScript>().Unit = battleController.Warrior;
                    tileController.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                }
                else break;
            }
        }
        for (int i = (TileController.MAXTILESX - 1); i > (TileController.MAXTILESX - 11); i--)
        {
            for (int j = 0; j < TileController.MAXTILESY; j++)
            {
                if (battleController.ImpCount > 0)
                {
                    tileController.Tiles[i, j].GetComponent<TileScript>().Unit = battleController.Imp;
                    tileController.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                }
                else break;
            }
        }
    }
}
