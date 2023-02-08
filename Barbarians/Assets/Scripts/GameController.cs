using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public List<KeyValuePair<string,FormationController>> fcmap;

    public void GetFormationMaps()
    {
        List<UnitController> masterList = FindObjectsOfType<UnitController>().ToList();
        SortedSet<string> stringSet = new();

        foreach (UnitController uc in masterList)
        {
            stringSet.Add(uc.UnitType);
        }

        foreach (string st in stringSet)
        {
            fcmap.Add(new KeyValuePair<string,FormationController>(st, new FormationController()));
        }
    }

}
