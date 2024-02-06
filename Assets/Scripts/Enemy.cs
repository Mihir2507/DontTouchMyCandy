using UnityEngine.AI;
using UnityEngine;
using UnityEngine.Rendering;
using System.Transactions;
using Unity.VisualScripting;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;

    [SerializeField] GameObject fruitDrop;
    
    //EnemyStats
    [Header("Stats")]
    [SerializeField] HealthBarScript healthScript;
    int maxHealth;
    int currentHealth;
    int damage;
    //Pateroling
    [SerializeField] Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange;

    [Header("Chasing")]
    public bool isChasing;
    public bool isAttacking;
    public bool isStandingForAttack;

    //Attacking
    [SerializeField] float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    [SerializeField] float sightRange, attackRange;
    bool playerInSightRange, playerInAttackRange;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        isChasing = false;
        maxHealth = 100;
        currentHealth = maxHealth;
        healthScript.SetMaxHealth(currentHealth);
        damage = 20;
    }

    private void Update()
    {
        //Check player in sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        // if(!playerInSightRange && !playerInAttackRange){ 
        //     Pateroling();
        // }
        // else if(playerInSightRange && !playerInAttackRange){ 
        //     Debug.Log("Chase");
        //     ChasePlayer();
        // }
        // else if(playerInSightRange && playerInAttackRange){ 
        //     AttackPlayer();
        // }
        CheckPlayerInSight();
        FreezeRotation();
    }
    private void FreezeRotation()
    {
        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
    }
    private void CheckPlayerInSight()
    {
        if(!playerInSightRange && !playerInAttackRange){ 
            // Pateroling();
            isChasing = false;
            agent.SetDestination(transform.position);

        }
        else if(playerInSightRange && !playerInAttackRange){ 
            ChasePlayer();
        }
        else if(playerInSightRange && playerInAttackRange){ 
            Debug.Log("Player in attack sight");
            AttackPlayer();
        }
    }

    private void Pateroling()
    {
    
        if(!walkPointSet) SetWalkPoint();

        if(walkPointSet)
        {
            transform.LookAt(walkPoint);
            agent.SetDestination(walkPoint);
            if(playerInSightRange || playerInAttackRange){
                CheckPlayerInSight();
            }
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }
    private void SetWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        isChasing = true;
        isAttacking = false;
        transform.LookAt(player);
        agent.SetDestination(player.position);
        Debug.Log("Chasing!!");
    }

    private void AttackPlayer()
    {
        isChasing = false;
        isStandingForAttack = true;
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            ///Attack code here
            isStandingForAttack = false;
            isAttacking = true;
            // Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            // rb.AddForce(transform.forward *16f, ForceMode.Impulse);
            // rb.AddForce(transform.up *5f, ForceMode.Impulse);
            
            ///

            alreadyAttacked = true;
            Invoke(nameof(ResteAttack), timeBetweenAttacks);
        }
    }

    private void ResteAttack()
    {
        isAttacking = false;
        alreadyAttacked = false;
    }

    public void Damage()
    {
        currentHealth -= damage;
        healthScript.SetHealth(currentHealth);
        if(currentHealth<=0)
        {
            KillEnemy();
        }
    }
    private void KillEnemy()
    {
        // Destroy(gameObject);
        gameObject.SetActive(false);
        Debug.Log("Enemy Died");
        Rigidbody rb = Instantiate(fruitDrop, transform.position + new Vector3(0f, 1f, 0f) , Quaternion.identity).GetComponent<Rigidbody>();
        //Rigidbody rb = Instantiate(fruitDrop, transform.position + new Vector3(0.0f, 1.0f, 0.0f) , Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.up *5f, ForceMode.Force);
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);    
    }


}
