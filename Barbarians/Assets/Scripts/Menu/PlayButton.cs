using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    public void EnableMenu()
    {
        menu.SetActive(true);
    }
}
