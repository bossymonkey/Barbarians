using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianEnemySeeker : MonoBehaviour
{
    private GameObject target;
    private bool gotTarget = false;
    [SerializeField] private float range;

    private void Update()
    {
        if (target == null)
        {
            gotTarget= false;
            target = Physics2D.OverlapCircle(transform.position, range).gameObject;
        }
        else
        {
            gotTarget= true;
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
