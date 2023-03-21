using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianEnemySeeker : MonoBehaviour
{
    [SerializeField]private GameObject target;
    private bool gotTarget = false;
    [SerializeField] private float range;

    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("demon")) == null)
        {
            gotTarget= false;
        }
        else
        {
            gotTarget = true;
            target = Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("demon")).gameObject;
            Debug.Log("target: "+target.name);
        }
    }
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
    public bool GotTarget
    {
        get { return gotTarget; }
        set { gotTarget = value; }
    }
}