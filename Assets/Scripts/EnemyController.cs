using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyStates currentState;
    private NavMeshAgent agent;
    private GameObject player;
    public LayerMask layerMask;
    public EnemyAttackZone attackZone;

    public float aggroRange;
    public float attackRange;

    [SerializeField]
    private bool inAggroRange;
    [SerializeField]
    private bool inAttackRange;

    private bool walkpointSet;
    [SerializeField]
    private Vector3 walkpoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentState = EnemyStates.Idle;
        player = GameObject.Find("PlayerCharacter");
    }

    private void LateUpdate()
    {
        inAggroRange = Physics.CheckSphere(transform.position, aggroRange, layerMask);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, layerMask);

        if (!inAggroRange && !inAttackRange)
        {
            Idle();
        }
        if (inAggroRange && !inAttackRange)
        {
            Chase();
        }
        if (inAggroRange && inAttackRange)
        {
            Attack();
        }
    }

    private void Idle()
    {
        currentState = EnemyStates.Idle;
        Roam();
    }

    private void Roam()
    {
        currentState = EnemyStates.Roam;
        if (!walkpointSet)
        {
            walkpoint = SetWalkpoint();
            agent.SetDestination(walkpoint);
            walkpointSet = true;
        }
        if (Vector3.Distance(walkpoint, transform.position) <= 1.5f)
        {
            walkpointSet = false;
            Debug.Log("reached walk point");
        }
    }
    private Vector3 SetWalkpoint()
    {
        float pointX = Random.Range(-2f, 4f);
        float pointZ = Random.Range(-2, 4f);
        return new Vector3(pointX, 0f, pointZ);
    }

    private void Chase()
    {
        walkpointSet = false;
        currentState = EnemyStates.Chase;
        agent.SetDestination(player.transform.position);
    }

    private void Attack()
    {
        currentState = EnemyStates.Attack;
        
    }

    enum EnemyStates
    {
        Idle,
        Roam,
        Chase,
        Attack
    }


}
