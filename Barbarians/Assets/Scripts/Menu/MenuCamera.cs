using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{

    public static MenuCamera instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    public void DownCamera()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y-0.01f,transform.position.z);
    }
}
