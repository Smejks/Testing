using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCamera : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;


    void Start()
    {
        startPos = new Vector3(23, -40, -10);
        endPos = new Vector3(23, -115, -10);

        transform.position = startPos;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.G)) {
            if (transform.position.y > -110)
                ScrollDown();
            if (transform.position.y < -30)
                ScrollUp();
        }


    }

    public void ScrollDown()
    {
        transform.position = Vector3.Lerp(transform.position, endPos, 0.5f);
    }

    public void ScrollUp()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, 0.9f);
    }


}
