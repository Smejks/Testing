using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void Start()
    {
        Movement.testEvent += Die;
        Movement.testEvent += Ouch;
    }

    private void Ouch()
    {
        Debug.Log("Ouch");
    }

    private void Die()
    {
        Debug.Log("Die");
    }


}
