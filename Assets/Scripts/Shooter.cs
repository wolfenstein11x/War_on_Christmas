using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject throwPoint;

    public void Fire()
    {
        Instantiate(projectile, throwPoint.transform.position, transform.rotation);
    }
}
