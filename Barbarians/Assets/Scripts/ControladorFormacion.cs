using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFormacion : MonoBehaviour
{
    private List<GameObject> guerrerosList;
    // Start is called before the first frame update
    void Start()
    {
        guerrerosList = Spawner.GuerrerosList;
        foreach  (GameObject go in guerrerosList)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
