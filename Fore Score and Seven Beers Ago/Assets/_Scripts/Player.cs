using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    private int currentLane;
    private int minLane;
    private int maxLane;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentLane = 0;
        minLane = 0;
        maxLane = 5;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical >= .5 || Input.GetKeyDown(KeyCode.UpArrow))
        {
            changeLane(1);
        }
        else if (moveVertical <= -.5 || Input.GetKeyDown(KeyCode.DownArrow))
        {
            changeLane(-1);
        }
        else
        {
            //stay in same lane
        }

        movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
    }

    void FixedUpdate()
    {
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

    private void changeLane(int direction)
    {
        if(direction == 1 && currentLane < maxLane)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            currentLane++;
        }
        else if(direction == -1 && currentLane > minLane)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            currentLane--;
        }
    }
}
