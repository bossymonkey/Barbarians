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
            yield return new WaitForSeconds(1f);
            DemonTurn();
            yield return new WaitForSeconds(1f);
        }
    }
    public void Spawn()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < TileController.MAXTILESY; j++)
            {
                if (BattleController.instance.WarriorCount > 0)
                {
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().Unit = BattleController.instance.Warrior;
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                    //BattleController.instance.HumanTiles.Add(TileController.instance.Tiles[i, j]);
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
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().Unit = BattleController.instance.Imp;
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                    //BattleController.instance.DemonTiles.Add(TileController.instance.Tiles[i, j]);
                    BattleController.instance.ImpCount--;
                }
                else break;
            }
        }
    }
    public void HumanTurn()
    {
        Debug.Log("empieza el turno de humanos");
        Debug.Log("humancount " + BattleController.instance.HumanTiles.Count);
        List<GameObject> humans = new();
        foreach (GameObject human in BattleController.instance.HumanTiles)
        {
            humans.Add(human);
        }
        foreach (GameObject human in humans)
        {
            //Debug.Log(human.GetComponentInChildren<Unit>().name);
            human.GetComponent<TileScript>().GetTarget(BattleController.instance.DemonTiles);
            if (human.GetComponent<TileScript>().CheckEnemyinRange())
            {
                human.GetComponent<TileScript>().Attack();
            }
            else
            {
                human.GetComponent <TileScript>().MoveTo(human.GetComponent<TileScript>().GetMove());
            }
        }
        Debug.Log("termina el turno de humanos");
    }
    public void DemonTurn()
    {
        Debug.Log("empieza el turno de demonios");
        Debug.Log("demoncount " + BattleController.instance.DemonTiles.Count);
        List<GameObject> demons = new(); 
        foreach(GameObject demon in BattleController.instance.DemonTiles)
        {
            demons.Add(demon);
        }
        foreach (GameObject demon in demons)
        {
            //Debug.Log(demon.GetComponentInChildren<Unit>().name);
            demon.GetComponent<TileScript>().GetTarget(BattleController.instance.HumanTiles);
            if (demon.GetComponent<TileScript>().CheckEnemyinRange())
            {
                demon.GetComponent<TileScript>().Attack();
            }
            else
            {
                demon.GetComponent<TileScript>().MoveTo(demon.GetComponent<TileScript>().GetMove());
            }
        }
        Debug.Log("termina el turno de demonios");
    }
}
