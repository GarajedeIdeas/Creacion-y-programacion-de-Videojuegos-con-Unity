using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    Animator anim;
    EnemyHealth enemyHealth;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if(player !=null && enemyHealth.isDead == false)
        {
            agent.SetDestination(player.transform.position);
        }
        Animating();
    }
    void Animating()
    {
        if (agent.velocity.magnitude != 0)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
