using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianEnemySeeker : MonoBehaviour
{
    private GameObject target;
    private bool gotTarget;
    [SerializeField] private float range;

    private void Awake()
    {
        target = null;
        gotTarget = false;
    }
    private void Update()
    {

        if (Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("demon")).gameObject == null)
        {
            target = null;
            Debug.Log("buscando target");
        }
        else if (Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("demon")) != null)
        {
            gotTarget = true;
            Debug.Log("target encontrado");
        }
        else
        {
            target = null;
            gotTarget = false;
            Debug.Log("target perdido");
        }
        /*if (Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("demon")) == null)//
        {
            target = null;
            gotTarget= false;
        }
        else if (target == null)
        {
            gotTarget = true;
            target = Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("demon")).gameObject;
            Debug.Log("target: "+target.transform.position+" name:"+target.name);
        }*/
    }

    //devuelve el target cuando lo encuentra sino devuelve null
    public GameObject SearchTarget()
    {
        if (Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("demon")).gameObject == null)
        {
            return null;
        }
        else return Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("demon")).gameObject;
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
