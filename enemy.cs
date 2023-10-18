using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    NavMeshAgent NMA;
    public float range;
    public float AtackRange;
    public Transform Player;

    public bool atackA = false;
    public bool rangeA = false;
    public Component dieanim;
    public Component diescreen;
    Animator anim;

    Vector3 enemystickDirection;
    float maxSpeed;
    public float dampp;
    void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
        Player = Player.transform;
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        rangeField();
        Atack();
        enemyMove();
    }

    void rangeField()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        foreach (var item in hitColliders)
        {
            if (item.gameObject.CompareTag("Player"))
            {
                LookPlayer();
                NMA.SetDestination(Player.transform.position);
                atackA = false;
                rangeA = true;
                NMA.isStopped = false;
                maxSpeed = 1;
                anim.SetBool("isMoving", true);
            }
        }
    }

    void Atack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, AtackRange);
        foreach (var item in hitColliders)
        {
            if (item.gameObject.CompareTag("Player"))
            {
                LookPlayer();
                NMA.isStopped = true;
                atackA = true;
                rangeA = false;
                anim.SetBool("isMoving", false);
                anim.SetBool("isAttacking", true);

            }
        }
    }
    void LookPlayer()
    {
        transform.LookAt(Player.position);
        transform.Rotate(0, 0, 0);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AtackRange);
    }

    public void enemyMove()
    {
        
    }
}

