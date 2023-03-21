using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorStateMachine : MonoBehaviour
{
    [SerializeField] public MonoBehaviour defend;
    [SerializeField] public MonoBehaviour attack;
    [SerializeField] public MonoBehaviour advance;
    [SerializeField] public MonoBehaviour charge;

    private MonoBehaviour actualState;

    public void Awake()
    {
        ActivateState(advance);
    }
    public void ActivateState(MonoBehaviour newState)
    {
        if(actualState != null)
        {
            actualState.enabled= false;
        }
        actualState= newState;
        actualState.enabled= true;
    }
}
