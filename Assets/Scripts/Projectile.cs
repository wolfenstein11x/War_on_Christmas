using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f, 10f)] [SerializeField] float projectileSpeed = 1.0f;
    [SerializeField] float damage = 30f;
    [SerializeField] GameObject projectileImpact;
    [SerializeField] Transform impactPoint;
    [SerializeField] float impactTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();

        health.DealDamage(damage);

        var impact = Instantiate(projectileImpact, impactPoint.transform.position, impactPoint.transform.rotation);
        Destroy(impact, impactTime);

        Destroy(gameObject);    
    }
}
