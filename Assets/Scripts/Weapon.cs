using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] PointDispenser pointDispenser;
    [SerializeField] GameObject bullet;
    SpriteRenderer indicator;
    float timer, heat;
    public float damage, fireRate, projectileSpeed, heatSink;
    bool overheat;
    void Start()
    {
        damage = pointDispenser.damage;
        fireRate = pointDispenser.fireRate;
        projectileSpeed = pointDispenser.projectileSpeed;
        heatSink = pointDispenser.heatSink;
        indicator = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        damage = pointDispenser.damage;
        fireRate = pointDispenser.fireRate;
        projectileSpeed = pointDispenser.projectileSpeed;
        heatSink = pointDispenser.heatSink;

        timer += Time.deltaTime * 40;
        if (Input.GetButton("Fire1")) {
            if (timer > 17 - fireRate && !overheat) {
                GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                GetComponent<AudioPlayer>().PlayFireSound(fireRate, damage);
                _bullet.transform.parent = transform;
                heat += 25 + damage * 2 - heatSink - fireRate / 2 - projectileSpeed / 2;
                timer = 0;
            }
        }


        if (overheat)
            heat -= heatSink * Time.deltaTime * 16;
        else
            heat -= heatSink * Time.deltaTime * 8;

        heat = Mathf.Clamp(heat, 0, 150);
        indicator.transform.localScale = new Vector3(2, 0 + heat * 0.025f, 1);
        if (heat >= 100)
            overheat = true;
        if (heat <= 0)
            overheat = false;

    }
}
