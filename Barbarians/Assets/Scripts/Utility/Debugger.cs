using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(DebugRoutine());
    }

    IEnumerator DebugRoutine()
    {
        yield return new WaitForSeconds(20f);
        foreach(List<GameObject> li in UnitBattleController.Instance.demons.Values)
        {
            Debug.Log("la list" + li[0].name+" tiene "+li.Count+" objetos");
            foreach(GameObject go in li)
            {
                Debug.Log(go.name);
            }
        }
        foreach (List<GameObject> li in UnitBattleController.Instance.barbarians.Values)
        {
            Debug.Log("la list" + li[0].name + " tiene " + li.Count + " objetos");
            foreach (GameObject go in li)
            {
                Debug.Log(go.name);
            }
        }
        StopAllCoroutines();
    }
}
