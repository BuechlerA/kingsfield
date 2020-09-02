using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    EnemyStates currentState;

    private void Start()
    {
        currentState = EnemyStates.Idle;
    }

    private void LateUpdate()
    {
        
    }

    private void Idle()
    {

    }

    private void Roam()
    {
        
    }

    private void Chase()
    {

    }

    private void Attack()
    {

    }

    enum EnemyStates
    {
        Idle,
        Roam,
        Chase,
        Attack
    }
}
