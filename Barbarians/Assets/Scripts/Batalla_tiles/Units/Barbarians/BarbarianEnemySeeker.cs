using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianEnemySeeker : MonoBehaviour
{
    [SerializeField] private GameObject target;
    //private bool gotTarget;
    [SerializeField] private float range;

    private void Awake()
    {
        target = null;
        //gotTarget = false;
    }
    private void Update()
    {
        target = SearchTarget();
    }

    //devuelve el target cuando lo encuentra sino devuelve null
    public GameObject SearchTarget()
    {
        if (Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("demon")) == null)
        {
            return null;
        }
        else
        {
            return Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("demon")).gameObject;
        }
    }
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
    /*public bool GotTarget
    {
        get { return gotTarget; }
        set { gotTarget = value; }
    }*/
}
