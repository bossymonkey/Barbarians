using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class StartSceneRoutine : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(InitialRoutine());
    }
    IEnumerator InitialRoutine()
    {
        yield return new WaitForSeconds(1f);
        Spawner.Instance.SpawnUnits(Spawner.Instance.guerreroObject, Spawner.Instance.guerrerosNum,
            Spawner.Instance.pool[0], Spawner.Instance.pool[1], Spawner.Instance.pool[2], Spawner.Instance.pool[3]);
        Spawner.Instance.SpawnUnits(Spawner.Instance.diablilloObject, Spawner.Instance.diablilloNum,
            Spawner.Instance.pool[0], Spawner.Instance.pool[1], Spawner.Instance.pool[2], Spawner.Instance.pool[3]);
        yield return new WaitForSeconds(1f);
        foreach (List<GameObject> li in UnitBattleController.Instance.barbarians.Values) 
        {
            FormationController.Instance.PlaceUnitsFormation(new Vector3(-30, -10, 0), li);
        }
        foreach (List<GameObject> li in UnitBattleController.Instance.demons.Values)
        {
            FormationController.Instance.PlaceWithoutFormation(new Vector3(30, -10, 0), li);
        }
        yield return new WaitForSeconds(1f);
        StopAllCoroutines();
    }
}
