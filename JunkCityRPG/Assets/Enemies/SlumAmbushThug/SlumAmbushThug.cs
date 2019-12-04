using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlumAmbushThug : EnemyAiScriptBase
{
    private NavMeshAgent agent;

    private float dist;

    private PlayerController player;

    private Animator animator;
    
    [SerializeField]
    private GameObject[] targets;

    [SerializeField]
    private GameObject attackHitBox;

    private int patrolTarget;

    bool aggressive = false;

    private enum State
    {
        Idle,
        Patrol,
        Chase,
        Attack,
    }

    private State lastState;
    private State state;

    public void Answered(bool attack)
    {
        if (attack)
        {
            aggressive = true;
            ChangeState(State.Chase);
        }
        else
        {
            state = State.Patrol;
        }
    }

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        animator = gameObject.GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        state = State.Idle;
        lastState = state;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Patrol:
                if (lastState != State.Patrol)
                    Patrol();
                break;
            case State.Idle:
                agent.velocity = Vector3.zero;
                animator.SetBool("Moving", false);
                break;
            case State.Chase:
                animator.SetBool("Moving", true);
                agent.SetDestination(player.gameObject.transform.position);
                break;
            case State.Attack:
                agent.velocity = Vector3.zero;
                gameObject.transform.LookAt(player.transform);
                animator.SetTrigger("Attack");
                break;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            attackHitBox.SetActive(true);
        }
        else
        {
            attackHitBox.SetActive(false);
        }
    }

    private void Patrol()
    {
        ChangeState(State.Patrol);
        agent.SetDestination(targets[patrolTarget].transform.position);
        animator.SetBool("Moving", true);
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
        if (Gamemanager.Instance.CurrentState == Gamemanager.GameState.Dead && aggressive) {
            PlayerDied();
            return;
        }
        dist = Vector3.Distance(transform.position, player.gameObject.transform.position);
        if (dist < 10f && dist > 2.5f && aggressive)
        {
            ChangeState(State.Chase);
        }
        if (dist < 2.5f && aggressive)
        {
            ChangeState(State.Attack);
        }
    }

    private void ChangeState(State _state)
    {
        lastState = state;
        state = _state;
    }

    public override void PlayerDied()
    {
        aggressive = false;
        ChangeState(State.Idle);
    }

}
