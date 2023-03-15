using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneRoutine : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(initialRoutine());
    }
    IEnumerator initialRoutine()
    {
        yield return null;
    }
}
