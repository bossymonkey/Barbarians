using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class StartBattleRoutine : MonoBehaviour
{

    public void Start()
    {
        StartCoroutine(InitialRoutine());
    }
    IEnumerator InitialRoutine()
    {
        TileController.instance.InstanceTiles();
        yield return null;
        Spawn();
        yield return new WaitForSeconds(1f);
        while (true)
        {
            HumanTurn();
            yield return new WaitForSeconds(0.2f);
            DemonTurn();
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void Spawn()
    {
        GameObject instanceunit;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < TileController.MAXTILESY; j++)
            {
                if (BattleController.instance.WarriorCount > 0)
                {
                    instanceunit = Instantiate(BattleController.instance.Warrior) as GameObject;
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().Unit = instanceunit;
                    instanceunit.transform.position = new Vector3(200, 200, 200);
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                    BattleController.instance.WarriorCount--;
                }
                else break;
            }
        }
        for (int i = (TileController.MAXTILESX - 1); i > (TileController.MAXTILESX - 11); i--)
        {
            for (int j = 0; j < TileController.MAXTILESY; j++)
            {
                if (BattleController.instance.ImpCount > 0)
                {
                    instanceunit = Instantiate(BattleController.instance.Imp) as GameObject;
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().Unit = instanceunit;
                    instanceunit.transform.position = new Vector3(200,200,200);
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                    BattleController.instance.ImpCount--;
                }
                else break;
            }
        }
    }
    public void HumanTurn()
    {
        Debug.Log("empieza el turno de humanos");
        //Debug.Log("humancount " + BattleController.instance.HumanTiles.Count);
        foreach (GameObject human in BattleController.instance.HumanTiles.ToList())
        {
            Debug.Log(human.GetComponentInChildren<Unit>().name);
            if (human.GetComponent<TileScript>().CheckEnemyinRange())
            {
                human.GetComponent<TileScript>().Attack();
            }
            else
            {
                human.GetComponent<TileScript>().GetTarget(BattleController.instance.DemonTiles);
                human.GetComponent <TileScript>().MoveTo(human.GetComponent<TileScript>().GetMove());
            }
        }
        Debug.Log("termina el turno de humanos");
    }
    public void DemonTurn()
    {
        Debug.Log("empieza el turno de demonios");
        //Debug.Log("demoncount " + BattleController.instance.DemonTiles.Count);
        foreach (GameObject demon in BattleController.instance.DemonTiles.ToList())
        {
            Debug.Log(demon.GetComponentInChildren<Unit>().name);
            if (demon.GetComponent<TileScript>().CheckEnemyinRange())
            {
                demon.GetComponent<TileScript>().Attack();
            }
            else
            {
                demon.GetComponent<TileScript>().GetTarget(BattleController.instance.HumanTiles);
                demon.GetComponent<TileScript>().MoveTo(demon.GetComponent<TileScript>().GetMove());
            }
        }
        Debug.Log("termina el turno de demonios");
    }
}
