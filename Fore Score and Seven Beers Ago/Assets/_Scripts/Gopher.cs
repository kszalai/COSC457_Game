using UnityEngine;
using System.Collections;

public class Gopher : MonoBehaviour {

    //Seconds between Gopher pop ups
    public float PopUpTime = 5f;

    //Seconds Gopher remains above ground
    public float AboveGroundTime = 2f;

    private bool AboveGround = true;

	// Use this for initialization
	void Start () {
        InvokeRepeating("PopUpGopher", 2f, PopUpTime);
	}
	
    void PopUpGopher () {
        Vector3 pos = transform.position;
        if(!AboveGround)
            pos.y = 0.25f;
        else
            pos.y = -0.5f;
        AboveGround = !AboveGround;
        transform.position = pos;
    }
}
