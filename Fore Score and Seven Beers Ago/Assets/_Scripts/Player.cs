using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter (Collider other)
    {
        string tag = other.gameObject.tag;
        switch(tag)
        {
            case "Alligator":
                print("Hit by Alligator");
                break;
            case "CokeCan":
                print("Hit by CokeCan");
                break;
            case "CokeMachine":
                print("Hit by CokeMachine");
                break;
            case "Gopher":
                print("Hit by Gopher");
                break;
            case "Pond":
                print("Hit by Pond");
                break;
            case "SandTrap":
                print("Hit by SandTrap");
                break;
            case "Tees":
                print("Hit by Tees");
                break;
        }
    }
}
