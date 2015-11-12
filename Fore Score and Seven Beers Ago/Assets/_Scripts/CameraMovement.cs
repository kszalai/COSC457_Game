using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public static CameraMovement S;
    public float cameraSpeed = .03f;

    // Use this for initialization
    void Start () {
        S = this;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + cameraSpeed, transform.position.y, transform.position.z);
    }
}
