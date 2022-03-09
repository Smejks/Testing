using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public int points;

    void Start()
    {
    }

    void Update()
    {
        points = Mathf.Clamp(points, 1, 16);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        points++;
   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        points--;
    }

}
