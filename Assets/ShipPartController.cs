using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartController : MonoBehaviour
{
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

    private void Start()
    {

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
        BuildShip();

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
