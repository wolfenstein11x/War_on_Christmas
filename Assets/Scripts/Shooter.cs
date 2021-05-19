using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject throwPoint;

    AttackerSpawner myLaneSpawner;

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("shoot!");
            // TODO change animation state
        }

        else
        {
            //Debug.Log("don't shoot");
            // TODO change animation state
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
