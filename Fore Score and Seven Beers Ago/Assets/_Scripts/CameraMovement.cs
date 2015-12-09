using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public static CameraMovement S;
    public float cameraSpeed = .02f;
    public GameObject endLine;

    // Use this for initialization
    void Start () {
        S = this;
        cameraSpeed = cameraSpeed * PlayerPrefs.GetInt("difficulty", 2);
    }

    void FixedUpdate()
    {
        if(transform.position.x < endLine.transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + cameraSpeed, transform.position.y, transform.position.z);
        }
    }
}
