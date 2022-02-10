using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public float heatSink;

    int weaponHardpoints;
    int moduleHardpoints;

    public void GenerateAttackStats()
    {
        damage = GetComponent<ShipPartController>().myHitPoints * 10;
        heatSink = GetComponent<ShipPartController>().myHeatSink;
        weaponHardpoints = GetComponent<ShipPartController>().myWeaponHardpoints;
        moduleHardpoints = GetComponent<ShipPartController>().myModuleHardpoints;
    }
}
