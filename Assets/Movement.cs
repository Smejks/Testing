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
    bool cameraRelative;
    Vector2 direction;

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
        Debug.Log(cameraRelative);
        //if (y != 0)
        //{
        //    ApplyThrust();
        //}
        //if (x != 0)
        //    Strafe();
        
        ReadInputs();
        ApplyBoost();

        if (Input.GetKeyDown(KeyCode.T))
            cameraRelative = !cameraRelative;

        if (cameraRelative)
        FlyByKeys();
        else
        FlyByMouse();
        
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

    //void ApplyThrust()
    //{
    //    thrust += Time.deltaTime;
    //    rb.AddForce(transform.up * thrust * y * Time.deltaTime * 200);
    //}

    void ApplyBoost()
    {

        if (boostIsActive) { 
        thrust += Time.deltaTime * 2;
        thrust = Mathf.Clamp(thrust, 0, GetComponent<ShipPartController>().myThrust / 5 * 2);
    }
        else
            thrust = Mathf.Clamp(thrust, 0, GetComponent<ShipPartController>().myThrust / 5);
    }

    void FlyByKeys()
    {
        if (clockWise)
        {
            rb.AddTorque(turnSpeed * Time.deltaTime * 80);
        }
        else if (counterClockWise)
        {
            rb.AddTorque(-turnSpeed * Time.deltaTime * 80);
        }

        thrust += Time.deltaTime;
        rb.AddForce(transform.up * thrust * y * Time.deltaTime * 200);

        rb.AddForce(transform.right * thrust * x * Time.deltaTime * 200);

        //else
        //{
        //    Debug.Log("Reseting Rotation");
        //    rotationAcceleration = 0;
        //    if (!Camera.main.GetComponent<LookAtPlayer>().cameraRelative)
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 0.001f);
        //}
    }

    private void FlyByMouse()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

        thrust += Time.deltaTime;
        rb.AddForce(Vector2.up * thrust * y * Time.deltaTime * 200);
        rb.AddForce(Vector2.right * thrust * x * Time.deltaTime * 200);
    }

    //void Strafe()
    //{
    //    rb.AddForce(transform.right * thrust * x * Time.deltaTime * 200);
    //}

}

