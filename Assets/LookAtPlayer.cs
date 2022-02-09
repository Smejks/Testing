using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    Transform target;

    //float moveSpeed = 0.005f;

    Vector3 targetPos;
    public bool cameraRelative;
    float cameraRotation;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
            cameraRelative = !cameraRelative;

        if (cameraRelative) {
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 0.01f);
            Physics2D.gravity = new Vector3(0, 0, 0);
        }
        else {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 0.001f);
            Physics2D.gravity = new Vector3(0, -15.81f, 0);
        }


            targetPos = new Vector3(target.transform.position.x, target.transform.position.y, -10);
        transform.position = targetPos;
        



    }
}
