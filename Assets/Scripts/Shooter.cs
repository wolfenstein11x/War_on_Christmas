using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject throwPoint;
    Animator animator;

    AttackerSpawner myLaneSpawner;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }

        else
        {
            animator.SetBool("isAttacking", false);
        }

    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>(); 

        foreach (AttackerSpawner spawner in spawners)
        {
            // if attacker and shooter in same lane, difference in y values should be practically zero
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        return (myLaneSpawner.transform.childCount >= 1);    
    }

    public void Fire()
    {
        Instantiate(projectile, throwPoint.transform.position, transform.rotation);
    }
}
