using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : EnemyAiScriptBase
{
    private NavMeshAgent agent;

    private float dist;

    private PlayerController player;

    private Animator animator;
    
    [SerializeField]
    private GameObject[] targets;

    private int patrolTarget;

    private bool playerDead = false;

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
        animator = gameObject.GetComponentInChildren<Animator>();
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
            case State.Idle:
                agent.velocity = Vector3.zero;
                animator.SetInteger("Anim", 0);
                break;
            case State.Chase:
                animator.SetInteger("Anim", 2);
                agent.SetDestination(player.gameObject.transform.position);
                break;
            case State.Attack:
                agent.velocity = Vector3.zero;
                gameObject.transform.LookAt(player.transform);
                animator.SetInteger("Anim", 1);
                break;
        }
    }

    private void Patrol()
    {
        ChangeState(State.Patrol);
        agent.SetDestination(targets[patrolTarget].transform.position);
        animator.SetInteger("Anim", 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(state == State.Patrol)
        {
            if(other.tag == "patrol")
            {
                patrolTarget++;
                if(patrolTarget == targets.Length)
                    patrolTarget = 0;
                Invoke("Patrol", 5);
                Invoke("GoIdle", 0.75f);
            }
        }
    }

    private void GoIdle()
    {
        state = State.Idle;
    }

    private void LateUpdate()
    {
        if (playerDead) return;
        dist = Vector3.Distance(transform.position, player.gameObject.transform.position);
        if (dist < 10f && dist > 2.5f)
        {
            ChangeState(State.Chase);
        }
        if (dist < 2.5f)
        {
            ChangeState(State.Attack);
        }
    }

    private void ChangeState(State _state)
    {
        lastState = state;
        state = _state;
    }

    public virtual void PlayerDied()
    {
        playerDead = true;
        ChangeState(State.Patrol);
    }

}
