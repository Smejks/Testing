using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartController : MonoBehaviour
{
    [Header("Parts")]
    [SerializeField] List<Fuselage> Fuselages = new List<Fuselage>();
    [SerializeField] List<Nose> Noses = new List<Nose>();
    [SerializeField] List<Tail> Tails = new List<Tail>();
    [SerializeField] List<Lwing> Lwings = new List<Lwing>();
    [SerializeField] List<Rwing> Rwings = new List<Rwing>();
    List<GameObject> BuiltParts = new List<GameObject>();

    public Fuselage myFuselage;
    public Nose myNose;
    public Tail myTail;
    public Lwing myLwing;
    public Rwing myRwing;

    Movement movement;
    Attack attack;
    Health health;
    ShipSystem shipSystem;

    public float myHitPoints;
    public float myThrust;
    public float myTurnSpeed;
    public float mySystem;
    public float myHeatSink;
    public float myDamage;
    public int myWeaponHardpoints;
    public int myModuleHardpoints;

    private void Start()
    {
        movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
        health = GetComponent<Health>();
        shipSystem = GetComponent<ShipSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RandomizeShip();
    }

    private void RandomizeShip()
    {
        int symmetryChance;
        int wing;

        myFuselage = Fuselages[UnityEngine.Random.Range(0, Fuselages.Count)];
        myNose = Noses[UnityEngine.Random.Range(0, Noses.Count)];
        myTail = Tails[UnityEngine.Random.Range(0, Tails.Count)];
        symmetryChance = UnityEngine.Random.Range(0, 3);

        if (symmetryChance != 0)
        {
            Debug.Log("Asymmetrical wings");
            myLwing = Lwings[UnityEngine.Random.Range(0, Lwings.Count)];
            myRwing = Rwings[UnityEngine.Random.Range(0, Rwings.Count)];
            if (myLwing == myRwing)
                RandomizeShip();
        }
        else
        {
            Debug.Log("Symmetrical wings");
            wing = UnityEngine.Random.Range(0, Lwings.Count);
            myLwing = Lwings[wing];
            myRwing = Rwings[wing];
        }

        myHitPoints = 5 + myFuselage.hitPoints + myNose.hitPoints + myTail.hitPoints + myLwing.hitPoints + myRwing.hitPoints;
        myThrust = 1 + myFuselage.thrust + myNose.thrust + myTail.thrust + myLwing.thrust + myRwing.thrust;
        myTurnSpeed = myFuselage.turnSpeed + myNose.turnSpeed + myTail.turnSpeed + myLwing.turnSpeed + myRwing.turnSpeed;
        mySystem = myFuselage.system + myNose.system + myTail.system + myLwing.system + myRwing.system;
        myHeatSink = myFuselage.heatSink + myNose.heatSink + myTail.heatSink + myLwing.heatSink + myRwing.heatSink;
        myDamage = myFuselage.damage + myNose.damage + myTail.damage + myLwing.damage + myRwing.damage;
        myWeaponHardpoints = myNose.WeaponHardpoint + myLwing.WeaponHardpoint + myRwing.WeaponHardpoint;
        myModuleHardpoints = myFuselage.ModuleHardpoint + myNose.ModuleHardpoint + myLwing.ModuleHardpoint + myRwing.ModuleHardpoint;

        if (myWeaponHardpoints < 1)
            RandomizeShip();
        else
        {
            BuildShip();
            movement.GenerateMovementStats();
            attack.GenerateAttackStats();
            health.GenerateHealthStats();
            shipSystem.GenerateSystemStats();
        }

    }

    private void BuildShip()
    {
        if (BuiltParts.Count != 0)
        {
            for (int i = 0; i < BuiltParts.Count; i++)
            {
                Destroy(transform.GetChild(i).GetChild(0).gameObject);
            }
            BuiltParts.Clear();
        }
        

        BuiltParts.Add(Instantiate(myFuselage.sprite, transform.GetChild(0)));
        BuiltParts.Add(Instantiate(myNose.sprite, transform.GetChild(1)));
        BuiltParts.Add(Instantiate(myTail.sprite, transform.GetChild(2)));
        BuiltParts.Add(Instantiate(myLwing.sprite, transform.GetChild(3)));
        BuiltParts.Add(Instantiate(myRwing.sprite, transform.GetChild(4)));
        
    }


}
