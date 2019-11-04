using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    private NavMeshAgent agent;

    private float dist;

    private PlayerController player;

    [SerializeField]
    private GameObject[] targets;

    private int patrolTarget;

    private enum State
    {
        Idle,
        Patrol,
        Chase,
        Attack,
    }

    private State lastState;
    private State state;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
        state = State.Patrol;
        lastState = state;
        Patrol();
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Patrol:
                if (lastState != State.Patrol)
                    Patrol();
                break;
            case State.Chase:
                agent.SetDestination(player.gameObject.transform.position);
                break;
            case State.Attack:
                //attack
                break;
        }
    }

    private void Patrol()
    {
        agent.SetDestination(targets[patrolTarget].transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("gona");
        if(state == State.Patrol)
        {
            if(other.tag == "patrol")
            {
                patrolTarget++;
                if(patrolTarget == targets.Length)
                    patrolTarget = 0;
                Invoke("Patrol", 5);
            }
        }
    }

    private void LateUpdate()
    {
        dist = Vector3.Distance(transform.position, player.gameObject.transform.position);
        if (dist < 10f && dist > 2f)
        {
            ChangeState(State.Chase);
        }
        if (dist < 2f)
        {
            ChangeState(State.Attack);
        }
    }

    private void ChangeState(State _state)
    {
        lastState = state;
        state = _state;
    }
}
