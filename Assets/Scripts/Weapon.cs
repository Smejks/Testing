using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] PointDispenser pointDispenser;
    [SerializeField] GameObject bullet;
    SpriteRenderer indicator, readyLight;
    float timer, heat;
    public float damage, fireRate, projectileSpeed, heatSink;
    bool overheat;
    Color readyColor;
    Color notReadyColor;

    void Start()
    {
        readyColor = new Color(0.5f, 1, 0.95f);
        notReadyColor = new Color(0.9f, 0.1f, 0.1f);
        damage = pointDispenser.damage;
        fireRate = pointDispenser.fireRate;
        projectileSpeed = pointDispenser.projectileSpeed;
        heatSink = pointDispenser.heatSink;
        indicator = transform.GetChild(0).GetComponent<SpriteRenderer>();
        readyLight = transform.GetChild(1).GetComponent<SpriteRenderer>();
        readyLight.color = readyColor;
        readyLight.color = notReadyColor;
    }

    void Update()
    {


        damage = pointDispenser.damage;
        fireRate = pointDispenser.fireRate;
        projectileSpeed = pointDispenser.projectileSpeed;
        heatSink = pointDispenser.heatSink;

        timer += Time.deltaTime * 60;
        if (Input.GetButton("Fire1") && pointDispenser.weaponReady) {
            if (timer > 17 - fireRate && !overheat) {
                GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                GetComponent<AudioPlayer>().PlayFireSound(fireRate, damage);
                _bullet.transform.parent = transform;
                heat += 30 + damage * 2 - heatSink - fireRate * 2 - projectileSpeed / 2;
                timer = 0;

                foreach (var point in pointDispenser.activePoints) {
                    point.GetComponent<Point>().ShakePoints(damage);
                }
            }
        }


        if (overheat || !pointDispenser.weaponReady)
            readyLight.color = Color.red;
        if (!overheat && pointDispenser.weaponReady)
            readyLight.color = readyColor;

        if (overheat)
            heat -= heatSink * Time.deltaTime * 20;
        else
            heat -= heatSink * Time.deltaTime * 10;

        heat = Mathf.Clamp(heat, 0, 150);
        indicator.transform.localScale = new Vector3(2.25f, 0 + heat * 0.018f, 1);
        if (heat >= 150) {
            GetComponent<AudioPlayer>().PlayOverHeatSound();
            overheat = true;
        }
        if (heat <= 0 && overheat) {
            GetComponent<AudioPlayer>().PlayCoolDownCompleteSound();
            overheat = false;
        }

    }
}
