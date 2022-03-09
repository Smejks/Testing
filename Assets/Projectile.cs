using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    float timer;
    private float projectileSpeed, damage;
   

    void Start()
    {
        
        projectileSpeed = 30 + GetComponentInParent<Weapon>().projectileSpeed * 100;
        Debug.Log(projectileSpeed);
        damage = GetComponentInParent<Weapon>().damage;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projectileSpeed;
        transform.localScale = new Vector3(damage / 1.2f, damage / 1.2f, 1);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
            Destroy(gameObject);
    }
}
