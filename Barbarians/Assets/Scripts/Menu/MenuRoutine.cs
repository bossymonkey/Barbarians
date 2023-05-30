using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MenuRoutine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI play;

    private void Start()
    {
        StartCoroutine(OptionsRoutine());
    }
    IEnumerator OptionsRoutine()
    {
        while(MenuCamera.instance.gameObject.transform.position.y > 1.20f)
        {
            MenuCamera.instance.DownCamera();
            yield return null;
        }
        yield return null;
        play.gameObject.SetActive(true);
    }
}
