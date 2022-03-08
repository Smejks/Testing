using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointDispenser : MonoBehaviour
{
    [SerializeField] TMP_Text DAMA;
    [SerializeField] TMP_Text RATE;
    [SerializeField] TMP_Text PSPD;
    [SerializeField] TMP_Text HEAT;
    [SerializeField] GameObject receptacle;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject point;
    [SerializeField] float offset;
    [SerializeField] List<GameObject> activePoints = new List<GameObject>();
    [SerializeField] List<GameObject> stats = new List<GameObject>();
    public int damage, fireRate, projectileSpeed, heatSink;



    void Start()
    {
        for (int i = 0; i < 4; i++) {
            stats.Add(Instantiate(receptacle, new Vector2(i * offset, -100), Quaternion.identity));
        }
        Instantiate(wall, new Vector2(-2.4f, -50), Quaternion.identity);
        Instantiate(wall, new Vector2(52.6f, -50), Quaternion.identity);


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) {
            if (activePoints.Count > 0)
                RemovePoints();

            StartCoroutine(LaunchPoints());
        }
    }


    void RemovePoints()
    {
        Camera.main.GetComponent<GeneratorCamera>().ScrollUp();
        for (int i = 0; i < activePoints.Count; i++) {
            Destroy(activePoints[i].gameObject);
            stats[0].GetComponent<PointCounter>().points = 0;
            stats[1].GetComponent<PointCounter>().points = 0;
            stats[2].GetComponent<PointCounter>().points = 0;
            stats[1].GetComponent<PointCounter>().points = 0;

            DAMA.text = ("Damage: " + damage);
            RATE.text = ("Fire Rate: " + fireRate);
            PSPD.text = ("Projectile Speed: " + projectileSpeed);
            HEAT.text = ("Heat Sink: " + heatSink);

        }
        activePoints.Clear();
    }

    IEnumerator LaunchPoints()
    {
        Camera.main.GetComponent<GeneratorCamera>().ScrollDown();
        for (int i = 0; i < 16; i++) {
            yield return new WaitForSeconds(0.05f);
            activePoints.Add(Instantiate(point, new Vector2(Random.Range(10, 40), -10), Quaternion.identity));
        }

        yield return new WaitForSeconds(5);

        damage = stats[0].GetComponent<PointCounter>().points;
        fireRate = stats[1].GetComponent<PointCounter>().points;
        projectileSpeed = stats[2].GetComponent<PointCounter>().points;
        heatSink = stats[3].GetComponent<PointCounter>().points;

        DAMA.text = ("Damage: " + damage);
        RATE.text = ("Fire Rate: " + fireRate);
        PSPD.text = ("Projectile Speed: " + projectileSpeed);
        HEAT.text = ("Heat Sink: " + heatSink);


    }

}

