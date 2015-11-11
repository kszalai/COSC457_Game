using UnityEngine;
using System.Collections;

public class CokeMachine : MonoBehaviour {

    //CokeCan prefab
    public GameObject CokeCanPrefab;

    //Speed at the machine will throw the can at the player
    public float velocityMult = 4f;

    //Seconds between CokeCan firing
    public float fireRate = 1f;

    //Ends of map
    public float startMap = 0f;
    public float endMap = 45f;

	void Start () {
        //Fire cans every second
        InvokeRepeating("FireCan", 2f, fireRate);
	}
	
	void FireCan () {
	    GameObject can = Instantiate(CokeCanPrefab) as GameObject;
        Vector3 direction;
        if (transform.position.z <= 2)
            direction = new Vector3(0.0f, 0.0f, 1.0f);
        else
            direction = new Vector3(0.0f, 0.0f, -1.0f);
        can.transform.position = transform.position;
        can.GetComponent<Rigidbody>().velocity = direction * velocityMult;
	}
}
