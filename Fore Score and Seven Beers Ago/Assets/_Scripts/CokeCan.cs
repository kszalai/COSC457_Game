using UnityEngine;
using System.Collections;

public class CokeCan : MonoBehaviour {
    public static float maxLeftZ = 6.5f;
    public static float maxRightZ = -1.5f;
	
	// Update the can called once per frame
	void Update () {
        if(transform.position.z < maxRightZ || transform.position.z > maxLeftZ)
        {
            Destroy(this.gameObject);
        }
	}
}
