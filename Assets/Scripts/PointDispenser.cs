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
    [SerializeField] GameObject ceiling;
    [SerializeField] GameObject point;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] float offset;
    public List<GameObject> activePoints = new List<GameObject>();
    [SerializeField] List<GameObject> stats = new List<GameObject>();
    public int damage, fireRate, projectileSpeed, heatSink;
    public bool weaponReady;



    void Start()
    {
        damage = 1;
        fireRate = 1;
        projectileSpeed = 1;
        heatSink = 1;

        DAMA.text = ("Damage: XX");
        DAMA.color = Color.red;
        RATE.text = ("Fire Rate: XX");
        RATE.color = Color.red;
        PSPD.text = ("Projectile Speed: XX");
        PSPD.color = Color.red;
        HEAT.text = ("Heat Sink: XX");
        HEAT.color = Color.red;

        StartCoroutine(LaunchPoints());

        for (int i = 0; i < 4; i++) {
            stats.Add(Instantiate(receptacle, new Vector2(i * offset, -100), Quaternion.identity));
        }
        Instantiate(wall, new Vector2(-2.4f, -50), Quaternion.identity);
        Instantiate(wall, new Vector2(52.6f, -50), Quaternion.identity);
        Instantiate(ceiling, new Vector2(23, 60), Quaternion.identity);


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && weaponReady) {
            if (activePoints.Count > 0)
                StartCoroutine(TossPoints());
        }
    }


    IEnumerator TossPoints()
    {
        weaponReady = false;
        audioPlayer.PlayZipSound();

        DAMA.text = ("Damage: XX");
        DAMA.color = Color.red;
        RATE.text = ("Fire Rate: XX");
        RATE.color = Color.red;
        PSPD.text = ("Projectile Speed: XX");
        PSPD.color = Color.red;
        HEAT.text = ("Heat Sink: XX");
        HEAT.color = Color.red;

        foreach (var point in activePoints) {
            point.GetComponent<Point>().TossPoints(1000);
        }
        yield return new WaitForSeconds(1);

        RemovePoints();

    }

    void RemovePoints()
    {
        for (int i = 0; i < activePoints.Count; i++) {
            Destroy(activePoints[i].gameObject);
            stats[0].GetComponent<PointCounter>().points = 0;
            stats[1].GetComponent<PointCounter>().points = 0;
            stats[2].GetComponent<PointCounter>().points = 0;
            stats[1].GetComponent<PointCounter>().points = 0;

            

        }
        activePoints.Clear();
        StartCoroutine(LaunchPoints());
    }

    IEnumerator LaunchPoints()
    {
        audioPlayer.PlayPointSpawnSound();
        for (int i = 0; i < 16; i++) {
            yield return new WaitForSeconds(0.05f);
            activePoints.Add(Instantiate(point, new Vector2(Random.Range(10, 40), -10), Quaternion.identity));
        }

        yield return new WaitForSeconds(5);

        weaponReady = true;
        audioPlayer.PlayStatsReadySound();

        damage = stats[0].GetComponent<PointCounter>().points;
        fireRate = stats[1].GetComponent<PointCounter>().points;
        projectileSpeed = stats[2].GetComponent<PointCounter>().points;
        heatSink = stats[3].GetComponent<PointCounter>().points;

        DAMA.text = ("Damage: " + (damage - 1));
        DAMA.color = Color.green;
        RATE.text = ("Fire Rate: " + (fireRate - 1));
        RATE.color = Color.green;
        PSPD.text = ("Projectile Speed: " + (projectileSpeed -1));
        PSPD.color = Color.green;
        HEAT.text = ("Heat Sink: " + (heatSink - 1));
        HEAT.color = Color.green;


    }

}

