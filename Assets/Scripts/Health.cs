using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float deathTime = 0.4f;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {

            StartCoroutine(ProcessDeath());
        }
    }

    IEnumerator ProcessDeath()
    {
        animator.SetTrigger("killed");
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}
