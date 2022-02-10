using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float x, y;
    bool clockWise, counterClockWise;

    public float thrust;
    public float turnSpeed;
    public float heatSink;

    float rotationAcceleration;
    bool boostIsActive;
    Vector3 mousePos;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
    }

    public void GenerateMovementStats()
    {
        thrust = GetComponent<ShipPartController>().myThrust / 5;
        turnSpeed = GetComponent<ShipPartController>().myTurnSpeed / 2;
        heatSink = GetComponent<ShipPartController>().myHeatSink;

        rb.angularDrag = turnSpeed / 6;
        rb.drag = thrust / 4;
    }

    private void LateUpdate()
    {
        if (y != 0)
        {
            ApplyThrust();
        }
        if (x != 0)
            Strafe();
        
        ReadInputs();
        Rotate();
        ApplyBoost();
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

    void ApplyThrust()
    {
        thrust += Time.deltaTime;
        rb.AddForce(transform.up * thrust * y * Time.deltaTime * 200);
    }

    void ApplyBoost()
    {

        if (boostIsActive) { 
            thrust += Time.deltaTime * 2;
        thrust = Mathf.Clamp(thrust, 0, GetComponent<ShipPartController>().myThrust / 5 * 2);
    }
        else
            thrust = Mathf.Clamp(thrust, 0, GetComponent<ShipPartController>().myThrust / 5);
    }

    void Rotate()
    {
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //difference.Normalize();
        //float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, rotation_z - 90));

        if (clockWise)
        {
            rb.AddTorque(turnSpeed * Time.deltaTime * 80);
        }
        else if (counterClockWise)
        {
            rb.AddTorque(-turnSpeed * Time.deltaTime * 80);
        }

        //else
        //{
        //    Debug.Log("Reseting Rotation");
        //    rotationAcceleration = 0;
        //    if (!Camera.main.GetComponent<LookAtPlayer>().cameraRelative)
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 0.001f);
        //}
    }


    void Strafe()
    {
        rb.AddForce(transform.right * thrust * x * Time.deltaTime * 200);
    }

}

