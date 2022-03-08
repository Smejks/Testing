using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 randomVector;
    float force;

    void Start()
    {
        transform.localScale = new Vector3(Random.Range(0.5f, 2), Random.Range(0.5f, 2), 1);
        randomVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        randomVector = randomVector.normalized;
        force = Random.Range(5000, 10000);
        //force = 10000;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(randomVector * force * Time.deltaTime, ForceMode2D.Impulse);
    }

    void Update()
    {
        
    }
}
