using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Walking,
        Attack
    }

    public EnemyState enemyState;
    //public float wanderRadius;

    [Header("Follow Object")]
    public GameObject targetObject;
    public float attackerRadius;

    [SerializeField] private float startWaitForWalking;
    private bool canDoActions = false;

    [Header("AnimFix")]
    [SerializeField] private GameObject targetTransform;
    private Vector3 firstTransform;

    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;

    [Header("Damage")]
    [SerializeField] private float minVelocityRequired;

    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find("PlayerTarget");

        firstTransform = targetTransform.transform.localPosition;

        //agent = GetComponent<NavMeshAgent>();
        enemyState = EnemyState.Idle;
        Invoke("StartWalking", startWaitForWalking);
    }
    void StartWalking()
    {
        enemyState = EnemyState.Walking;
        //Debug.Log("Start Walking");
        canDoActions = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(this.gameObject.transform.position, targetObject.transform.position));

        if (Vector3.Distance(this.gameObject.transform.position, targetObject.transform.position) >= attackerRadius && canDoActions)
        {
            enemyState = EnemyState.Walking;            
            
        }
        else if(canDoActions)
        {
            enemyState = EnemyState.Attack;
        }

        //if(Input.GetKeyDown(KeyCode.P))
        //{
        //    Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        //    agent.SetDestination(newPos);
        //}

        if (enemyState == EnemyState.Idle) { IdleState(); }
        else if (enemyState == EnemyState.Walking) { WalkingState(); }
        else if (enemyState == EnemyState.Attack) { AttackState(); }
    }

    void IdleState()
    {
        animator.SetInteger("ZombieAnimState", 0);
    }

    void WalkingState()
    {
        animator.SetInteger("ZombieAnimState", 1);

        agent.SetDestination(targetObject.transform.position);

        targetTransform.transform.localPosition = firstTransform;
    }

    void AttackState()
    {
        //Debug.Log("attack");
        Vector3.RotateTowards(this.transform.position, targetObject.transform.position, 0f, 0f);
        animator.SetInteger("ZombieAnimState", 2);

        targetTransform.transform.localPosition = firstTransform;

        //if (Vector3.Distance(this.gameObject.transform.position, targetObject.transform.position) >= attackerRadius)
        //{
        //    enemyState = EnemyState.Walking;
        //}
    }


    //public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    //{
    //    Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

    //    randomDirection += origin;

    //    NavMeshHit navHit;

    //    NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

    //    return navHit.position;
    //}

    public float DamageCalculator(float punchVelocity)
    { 
        if(punchVelocity > minVelocityRequired && enemyState == EnemyState.Attack)
        {
            float damage = (float)Convert.ToInt32(punchVelocity / 2);
            return damage;
        }

        return 0f;
    }
    
}
