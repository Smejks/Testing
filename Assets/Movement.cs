using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float x, y;
    bool clockWise, counterClockWise;

    public float hitPoints;
    public float thrust;
    public float turnSpeed;
    public float system;
    public float heatSink;
    public float damage;

    float rotationAcceleration;
    bool boostIsActive;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        hitPoints = GetComponent<ShipPartController>().myHitPoints;
        thrust = GetComponent<ShipPartController>().myThrust;
        turnSpeed = GetComponent<ShipPartController>().myTurnSpeed;
        system = GetComponent<ShipPartController>().mySystem;
        heatSink = GetComponent<ShipPartController>().myHeatSink;
        damage = GetComponent<ShipPartController>().myDamage;
    }

    private void LateUpdate()
    {
        ReadInputs();

        thrust += Time.deltaTime * 2;


        if (y != 0)
        {
            ApplyThrust();
        }
        if (x != 0)
            Strafe();

        Rotate();
        //ApplyBoost();




    }

    private void ReadInputs()
    {
        x = Input.GetAxis("Horizontal") / 2;
        y = Input.GetAxis("Vertical");
        clockWise = Input.GetKey(KeyCode.A);
        counterClockWise = Input.GetKey(KeyCode.D);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            boostIsActive = true;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            boostIsActive = false;


    }

    void Rotate()
    {

        if (clockWise)
        {
            rotationAcceleration += Time.deltaTime * 10;
            rb.AddTorque(turnSpeed * 0.3f);
        }
        else if (counterClockWise)
        {
            rotationAcceleration += Time.deltaTime * 10;
            rb.AddTorque(-turnSpeed * 0.3f);
        }
        else
        {
            Debug.Log("Reseting Rotation");
            rotationAcceleration = 0;
            if (!Camera.main.GetComponent<LookAtPlayer>().cameraRelative)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 0.001f);
        }
    }


    void Strafe()
    {
        rb.AddForce(transform.right * turnSpeed * x);
    }

    void ApplyThrust()
    {
        rb.AddForce(transform.up * thrust * y);
    }

    //void ApplyBoost() {

    //    if (boostIsActive)
    //    thrust = Mathf.Clamp(thrust, 0, 4f);
    //    else
    //    thrust = Mathf.Clamp(thrust, 0, 1.5f);
    //}
}

