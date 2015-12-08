using UnityEngine;
using System.Collections;

public class Alligator : MonoBehaviour {

    //Speed at which the Alligator Moves
    public float speed = 1f;

    //Distance where Alligator turns around
    public float RightEdge = 10f;
    public float LeftEdge = -10f;

    void Start (){
        RightEdge += transform.position.x;
        LeftEdge += transform.position.x;
    }
	
	void FixedUpdate () {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if(pos.x <= LeftEdge){
            transform.Rotate(0f, 180f, 0f);
            speed = Mathf.Abs(speed); //Move right
        }
        else if(pos.x >= RightEdge){
            transform.Rotate(0f, 180f, 0f);
            speed = -Mathf.Abs(speed); //Move left
        }
	}
}
