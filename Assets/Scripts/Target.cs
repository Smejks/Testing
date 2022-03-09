using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] TMP_Text TargetDamage;
    float damageTaken;
    float timer;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        TargetDamage.text = ("" + (int)damageTaken);

        if (timer > 2.5f)
            damageTaken = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer = 0;
        damageTaken += collision.transform.GetComponent<Projectile>().damage * collision.transform.GetComponent<Projectile>().damage + collision.transform.GetComponent<Projectile>().projectileSpeed / 100;
        
    }

}
