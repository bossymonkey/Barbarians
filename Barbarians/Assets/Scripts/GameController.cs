using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    private List<KeyValuePair<string,FormationController>> fcmap  = new();
    private float timeControl = 0f;
    private bool once = true;
    private bool ready = false;


    private void Update()
    {
        timeControl += Time.deltaTime;

        if (once && timeControl >= 3f)
        {
            GetFormationMaps();
            once = false;
        }
    }
    public void GetFormationMaps()
    {
        List<Object> masterList = Resources.FindObjectsOfTypeAll(typeof(UnitController)).ToList();
        SortedSet<string> stringSet = new();

        Debug.Log("list "+masterList.Count);
        foreach (UnitController uc in masterList.Cast<UnitController>())
        {
            stringSet.Add(uc.UnitType);
        }
        Debug.Log("set "+stringSet.Count);
        foreach (string st in stringSet)
        {
            fcmap.Add(new KeyValuePair<string,FormationController>(st, new FormationController()));
        }
        Debug.Log("map "+fcmap.Count);
    }
    public List<KeyValuePair<string, FormationController>> Fcmap
    {
        get { return fcmap; }
        set { fcmap = value; }
    }
}
