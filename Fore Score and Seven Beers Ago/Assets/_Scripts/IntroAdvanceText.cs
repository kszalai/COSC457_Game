using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroAdvanceText : MonoBehaviour {

	private Text paragraph1;
	private Text paragraph2;
	private Text paragraph3;
	private Text paragraph4;


	// Use this for initialization
	void Start () {
	
		paragraph1 = GetComponent<Text> ();
		paragraph2 = GetComponent<Text> ();
		paragraph3 = GetComponent<Text> ();
		paragraph4 = GetComponent<Text> ();

		//Set first paragraph to be visible, others to be invisible
		paragraph2.enabled = false;
		paragraph3.enabled = false;
		paragraph4.enabled = false;
		paragraph1.enabled = true;

		//Allow 10 seconds to pass, then disable the current paragraph
		//yield return new WaitForSeconds(10);
		//paragraph1.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
