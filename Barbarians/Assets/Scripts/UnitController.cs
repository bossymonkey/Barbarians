using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{

    private int id;
    [SerializeField]private string unitType;

    private bool inController = false;
    private bool controllerOnce = true;
    private bool bhOnce = true;

    private void Start()
    {
        SetBehaviours(false);
    }

    private void FixedUpdate()
    {

        if (controllerOnce && GameController.MapsReady)
        {
            GetInController(GameController.Fcmap);
            controllerOnce = false;
        }
        if (bhOnce && GameController.FightReady)
        {
            SetBehaviours(true);
            bhOnce= false;
        }
    }
    public void SetBehaviours(bool boolean)
    {
        foreach (Behaviour bh in this.GetComponents<Behaviour>())
        {
            if (this.GetComponent<UnitController>() != bh)
            {
                bh.enabled = boolean;
            }
        }
    }
    public void GetInController(Dictionary<string, FormationController> fcmap)
    {
        fcmap[unitType].ObjetosAFormar.Add(this.gameObject);
        inController= true;
    }
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string UnitType
    {
        get { return unitType; }
        set { unitType = value; }
    }
    public bool InController
    {
        get { return inController; }
        set { inController = value; }
    }
}
