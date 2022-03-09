using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hitPoints;

    public void GenerateHealthStats()
    {
        hitPoints = GetComponent<ShipPartController>().myHitPoints * 10;
    }
}
