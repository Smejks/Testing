using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystem : MonoBehaviour
{
    public float heatSink;
    public float system;
    public void GenerateSystemStats()
    {
        heatSink = GetComponent<ShipPartController>().myHeatSink;
        system = GetComponent<ShipPartController>().mySystem;
    }
}
