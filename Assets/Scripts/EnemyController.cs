using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;



public enum EnemyState
{
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private CharacterAnimations enemy_anim;
    private NavMeshAgent navAgent;

    private Transform playerTarget;
    public float move_speed = 3.5f;
    public float attack_distance = 1f;
    public float chase_player_after_dist = 1.6f;

    private float wait_before_attack_time = 3f;
    private float attack_Timer;

    private EnemyState enemy_state;

    public GameObject attackPoint;

    private CharacterSoundFX soundFX;


    void Awake()
    {
        enemy_anim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
        
        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

    void Start()
    {
        enemy_state = EnemyState.CHASE;

        attack_Timer = wait_before_attack_time;
    }

    // Update is called once per frame
    void Update() 
    {
        if (enemy_state == EnemyState.CHASE)
        {
            ChasePlayer();
        }

        if (enemy_state == EnemyState.ATTACK)
        {
            AttackPlayer();
        }

    }

    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = move_speed;

        if(navAgent.velocity.sqrMagnitude == 0)
        {
            enemy_anim.Walk(false);
        } else
        {
            enemy_anim.Walk(true);
        }

        if (Vector3.Distance(transform.position, playerTarget.position) <= attack_distance)
        {
            enemy_state = EnemyState.ATTACK;
        }
    }

    //what happens when navagent attacks
    void AttackPlayer() 
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        enemy_anim.Walk(false);

        attack_Timer += Time.deltaTime;

        if (attack_Timer > wait_before_attack_time)
        {
            if (Random.Range(0, 2) > 0)
            {
                enemy_anim.Attack_1();
                soundFX.Attack_1();
            } else {
                enemy_anim.Attack_2();
                soundFX.Attack_2();
            }
            attack_Timer = 0f;
        } // if we can attack

        if (Vector3.Distance(transform.position, playerTarget.position) >
            attack_distance + chase_player_after_dist)
        {
            navAgent.isStopped = false;
            enemy_state = EnemyState.CHASE;
        }
    }

    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }


    void Deactivate_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
} //class
