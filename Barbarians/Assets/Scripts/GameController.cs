using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private ControladorFormacion cf = new ControladorFormacion();

    private List<GameObject> guerrerosList;
    private float timeControl;
    private Vector2 puntoMedio;
    private bool flag = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        timeControl += Time.deltaTime;
        if(timeControl >= 3f)
        {
            guerrerosList = cf.GenerarListaGuerreros();
            if (!flag)
            {
                puntoMedio = cf.ObtenerPuntoMedio(guerrerosList);
                flag = true;
            }
            Debug.Log(puntoMedio);
            timeControl= 0f;
        }
        if (flag)
        {
            cf.CrearFormacion(guerrerosList, puntoMedio);
        }
    }

}
