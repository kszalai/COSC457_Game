using UnityEngine;
using System.Collections;

public class Gopher : MonoBehaviour {

    //Seconds between Gopher pop ups
    public float PopUpTime = 10f;

    //Seconds Gopher remains above ground
    public float AboveGroundTime = 2f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("PopUpGopher", 2f, PopUpTime);
	}
	
	IEnumerator PopUpGopher () {
        transform.position = new Vector3(transform.position.x, 0.25f, transform.position.z);
        yield return new WaitForSeconds(AboveGroundTime);
        transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
	}
}
