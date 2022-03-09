using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    float timer;
    public   float projectileSpeed, damage;
   

    void Start()
    {
        
        projectileSpeed = 40 + GetComponentInParent<Weapon>().projectileSpeed * 20;
        damage = GetComponentInParent<Weapon>().damage;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projectileSpeed;
        transform.localScale = new Vector3(damage / 2, damage / 2, 1);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
            Destroy(gameObject);
    }
}
