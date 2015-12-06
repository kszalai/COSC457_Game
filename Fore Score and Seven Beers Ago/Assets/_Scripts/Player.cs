using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject SP_Camera;

    private int currentLane;
    private int minLane;
    private int maxLane;
    public float minSpeed;
    public float restingSpeed;
    public float maxSpeed;
    private float desiredSpeed;

    void Start()
    {
        currentLane = 0;
        minLane = 0;
        maxLane = 5;
    }

    void Update()
    {
        //CHANGE LANES

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changeLane(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            changeLane(-1);
        }
        else
        {
            //stay in same lane
        }


        // SET SPEED

        desiredSpeed = restingSpeed;

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < SP_Camera.transform.position.x + 4f)
        {
            desiredSpeed = maxSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > SP_Camera.transform.position.x - (4f + transform.lossyScale.x))
        {
            desiredSpeed = minSpeed;
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + desiredSpeed, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter (Collider other)
    {
        string tag = other.gameObject.tag;
        switch(tag)
        {
            case "Alligator":
                print("Hit by Alligator");
				changeLane(1);
                break;
            case "CokeCan":
                print("Hit by CokeCan");
				Destroy(other.gameObject);
                break;
            case "CokeMachine":
                print("Hit by CokeMachine");
				changeLane(1);
                break;
            case "Gopher":
                print("Hit by Gopher");
				changeLane(1);
                break;
            case "Pond":
                print("Hit by Pond");
				desiredSpeed = minSpeed;
                break;
            case "SandTrap":
                print("Hit by SandTrap");
				desiredSpeed = minSpeed;
                break;
            case "Tees":
                print("Hit by Tees");
                break;
			default:
				print ("Hit by CokeCan");
				break;
        }
    }

    private void changeLane(int direction)
    {
        if (direction == 1 && currentLane < maxLane) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1);
			currentLane++;
		} else if (direction == -1 && currentLane > minLane) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 1);
			currentLane--;
		} else if (direction == 1 && currentLane == maxLane) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 1);
			currentLane--;
		} else if (direction == - 1 && currentLane == minLane) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1);
			currentLane++;
		}
    }
}
