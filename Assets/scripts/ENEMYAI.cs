using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ENEMYAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatIsground, WhatIsPlayer;
    public GameObject projectile;
    public float health;

    //Patrullando
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    //Ataque
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //Estado

    public float sigthRange, AttackRange;
    public bool playerInSigthRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.Find("PLAYER").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        playerInSigthRange = Physics.CheckSphere(transform.position, sigthRange, WhatIsPlayer);
        playerInSigthRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);

        if (!playerInSigthRange && !playerInAttackRange) Patrolling();
        if (playerInSigthRange && !playerInAttackRange) ChasePlayer();
        if (playerInSigthRange && playerInAttackRange) AttackPlayer();

    }
    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkpoint);
        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkpoint, -transform.up, 2f, WhatIsground))
        walkPointSet = true;

    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;


    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);

    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sigthRange);
    }
}

