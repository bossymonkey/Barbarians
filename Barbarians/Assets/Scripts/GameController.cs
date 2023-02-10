using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    private static Dictionary<string,FormationController> fcmap  = new();
    
    private float countDown = 3f;
    
    private bool mapsOnce = true;
    private static bool mapsReady = false;
    private bool allInController = false;
    private bool initPositionOnce = true;
    private bool countdownOnce = true;
    private static bool fightReady = false;


    private void FixedUpdate()
    {
        

        if (mapsOnce && Spawner.Ready)
        {
            GetFormationMaps();
            mapsReady = true;
            mapsOnce = false;
        }
        if (!allInController) 
        {
            allInController = CheckController();
        }
        else if(initPositionOnce)
        {
            foreach(KeyValuePair<string,FormationController> kv in fcmap) 
            {
                if(kv.Key == "guerrero")
                {
                    kv.Value.PlaceUnitsFormation(new Vector3(-17f, -8.5f, 0));
                }
                else if (kv.Key == "diablillo")
                {
                    kv.Value.PlaceWithoutFormation(new Vector3(20f,-8.5f,0f));
                }
            }
            Debug.Log("posiciones incializadas con exito");
            initPositionOnce = false;
        }
        else if(countdownOnce)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0f)
            {
                countdownOnce= false;
            }
            if (countDown <= 1f)
            {
                Debug.Log("1");
            }
            else if(countDown <= 2f) 
            {
                Debug.Log("2");
            }
            else if (countDown <= 3f)
            {
                Debug.Log("3");
            }
        }
        else
        {
            Debug.Log("A Luchar");
            fightReady = true;
        }
    }
    public bool CheckController()
    {
        int cont = 0;
        UnitController[] unitControllers = FindObjectsOfType<UnitController>();
        foreach (UnitController uc in unitControllers)
        {
            if(uc.InController == true) 
            { 
                cont++;
            }
        }
        if (cont == unitControllers.Count())
        {
            Debug.Log("unidades cargadas con exito en el controlador");
            return true;
        }
        else return false;
    }
    public void GetFormationMaps()
    {
        List<Object> masterList = Resources.FindObjectsOfTypeAll(typeof(UnitController)).ToList();
        SortedSet<string> stringSet = new();

        foreach (UnitController uc in masterList.Cast<UnitController>())
        {
            stringSet.Add(uc.UnitType);
        }
        foreach (string st in stringSet)
        {
            fcmap.Add(st,new FormationController());
        }
        Debug.Log(fcmap.Count+" maps creados con exito");
    }
    public static Dictionary<string,FormationController> Fcmap
    {
        get { return fcmap; }
        set { fcmap = value; }
    }
    public static bool MapsReady
    {
        get { return mapsReady; }
        set { mapsReady = value; }
    }
    public static bool FightReady
    {
        get { return fightReady; }
        set { fightReady = value; }
    }
}
