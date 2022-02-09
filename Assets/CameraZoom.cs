using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D targetRB;
        

    private void LateUpdate() {

        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, (3 + targetRB.velocity.magnitude), 0.001f);
        Mathf.Clamp(Camera.main.orthographicSize, 3, 30);
    }
}
