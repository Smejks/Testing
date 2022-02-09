using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void testDelegate();

public class MovementOLD : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed;
    Rigidbody2D rb;
    private Inputs playerInputs;
    public static event testDelegate testEvent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInputs = new Inputs();
        playerInputs.PlayerControls.Enable();
        playerInputs.PlayerControls.Thrust.performed += Jump;
        playerInputs.PlayerControls.Attack.performed += Attack;
        playerInputs.PlayerControls.RotateLeft.performed += RotateLeft;
        playerInputs.PlayerControls.RotateRight.performed += RotateRight;
    }

    private void RotateRight(InputAction.CallbackContext obj)
    {
        rb.AddTorque(rotationSpeed * Time.deltaTime, ForceMode2D.Force);
    }

    private void RotateLeft(InputAction.CallbackContext obj)
    {
        rb.AddTorque(-rotationSpeed * Time.deltaTime, ForceMode2D.Force);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            testEvent?.Invoke();

        }
    }

    private void Attack(InputAction.CallbackContext obj)
    {

    }

    private void Jump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jumping");
        rb.AddForce(transform.up * 10, ForceMode2D.Impulse);
    }

}
