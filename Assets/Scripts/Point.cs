using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audioSource;
    [SerializeField] AudioClip ping;
    Vector2 randomVector;
    float force;
    float timer;
    int bounceCount;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.localScale = new Vector3(Random.Range(0.5f, 2), Random.Range(0.5f, 2), 1);
        randomVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        randomVector = randomVector.normalized;
        force = Random.Range(500, 1000);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(randomVector * force * Time.deltaTime, ForceMode2D.Impulse);
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    public void ShakePoints(float shakeForce)
    {
        randomVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        rb.AddForce(randomVector * shakeForce * 40 * Time.deltaTime, ForceMode2D.Impulse);
    }
    
    public void TossPoints(float shakeForce)
    {
        randomVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        rb.AddForce(Vector2.up * shakeForce * 40 * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (timer > 8 || bounceCount > 4) { return; }
        if (collision.transform.CompareTag("Receptacle")) {
            audioSource.pitch = Random.Range(0.5f, 1.4f);
            audioSource.PlayOneShot(ping);
        }
        bounceCount++;

    }

}
