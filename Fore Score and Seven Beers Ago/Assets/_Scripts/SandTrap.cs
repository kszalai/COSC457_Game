using UnityEngine;
using System.Collections;

public class SandTrap : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        //When the trigger is entered
        //Check if its the player
        if(other.tag == "Player")
        {
            //Slow down player velocity
            //We don't have an actual character model yet
            //This will be handled once we have a character model
            //It will limit player velocity
        }
    }
}
