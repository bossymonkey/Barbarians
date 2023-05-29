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
            if (BattleController.instance.CheckVictory())
            {
                break;
            }
            try
            {
                HumanTurn();
            }
            catch
            {
                Debug.Log("ha ocurrido una excepcion durante el turno humano");
            }
            //Debug.Log("conteo humano "+BattleController.instance.HumanTiles.Count);
            yield return new WaitForSeconds(0.5f);
            if (BattleController.instance.CheckVictory())
            {
                break;
            }
            try
            {
                DemonTurn();
            }
            catch
            {
                Debug.Log("ha ocurrido una excepcion durante el turno demonio");
            }
            //Debug.Log("conteo demon " + BattleController.instance.DemonTiles.Count);
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("partida finalizada");
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
                else if(BattleController.instance.BerserkerCount > 0)
                {
                    instanceunit = Instantiate(BattleController.instance.Berserker) as GameObject;
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().Unit = instanceunit;
                    instanceunit.transform.position = new Vector3(200, 200, 200);
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                    BattleController.instance.BerserkerCount--;
                }
                else if (BattleController.instance.KnightCount > 0)
                {
                    instanceunit = Instantiate(BattleController.instance.Knight) as GameObject;
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().Unit = instanceunit;
                    instanceunit.transform.position = new Vector3(200, 200, 200);
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                    BattleController.instance.KnightCount--;
                }
                else if (BattleController.instance.VikingCount > 0)
                {
                    instanceunit = Instantiate(BattleController.instance.Viking) as GameObject;
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().Unit = instanceunit;
                    instanceunit.transform.position = new Vector3(200, 200, 200);
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                    BattleController.instance.VikingCount--;
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
                else if (BattleController.instance.EyeCount > 0)
                {
                    instanceunit = Instantiate(BattleController.instance.Eye) as GameObject;
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().Unit = instanceunit;
                    instanceunit.transform.position = new Vector3(200, 200, 200);
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                    BattleController.instance.EyeCount--;
                }
                else if (BattleController.instance.WormCount > 0)
                {
                    instanceunit = Instantiate(BattleController.instance.Worm) as GameObject;
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().Unit = instanceunit;
                    instanceunit.transform.position = new Vector3(200, 200, 200);
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                    BattleController.instance.WormCount--;
                }
                else if (BattleController.instance.DevilCount > 0)
                {
                    instanceunit = Instantiate(BattleController.instance.Devil) as GameObject;
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().Unit = instanceunit;
                    instanceunit.transform.position = new Vector3(200, 200, 200);
                    TileController.instance.Tiles[i, j].GetComponent<TileScript>().enabled = true;
                    BattleController.instance.DevilCount--;
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
            //Debug.Log(human.GetComponentInChildren<Unit>().name);
            if (human.GetComponent<TileScript>().CheckEnemyinRange())
            {
                human.GetComponent<TileScript>().Attack();
                human.transform.GetChild(0).GetComponent<Unit>().Attacking = true;
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
            //Debug.Log(demon.GetComponentInChildren<Unit>().name);
            if (demon.GetComponent<TileScript>().CheckEnemyinRange())
            {
                demon.GetComponent<TileScript>().Attack();
                demon.transform.GetChild(0).GetComponent<Unit>().Attacking = true;
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
