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
	
		//paragraph1 = GameObject.FindGameObjectWithTag ("Paragraph1YouAreAbe");
		//Transform textTr = paragraph1.transform.Find ("paragraph1");
		//Text text = textTr .GetComponent<Text>();

		paragraph1 = GameObject.FindWithTag("Paragraph1YouAreAbe").GetComponent<Text>() as Text;
		paragraph2 = GameObject.FindWithTag("Paragraph2FreakAccident").GetComponent<Text>() as Text;
		paragraph3 = GameObject.FindWithTag("Paragraph3BarCloses").GetComponent<Text>() as Text;
		paragraph4 = GameObject.FindWithTag("Paragraph4CaddyCannotLeave").GetComponent<Text>() as Text;

		//paragraph1 = GetComponent<Text> ();
		//paragraph2 = GetComponent<Text> ();
		//paragraph3 = GetComponent<Text> ();
		//paragraph4 = GetComponent<Text> ();

		//Set first paragraph to be visible, others to be invisible
		paragraph2.enabled = false;
		paragraph3.enabled = false;
		paragraph4.enabled = false;
		paragraph1.enabled = true;

		StartCoroutine(castFire ());

		//Allow 15 seconds to pass, then disable the 1st paragraph and enable the 2nd
		//yield WaitForSeconds (10);
		//if (Time.time >= 5) {
		//	paragraph1.enabled = false;
		//	paragraph2.enabled = true;
		//}




	}

	IEnumerator castFire() // Not void
	{
		//Allow 15 seconds to pass, then disable the 1st paragraph and enable the 2nd
		yield return new WaitForSeconds (15);
		paragraph1.enabled = false;
		paragraph2.enabled = true;

		//Allow 31 seconds to pass, then disable the 2nd paragraph and enable the 3rd
		yield return new WaitForSeconds (31);
		paragraph2.enabled = false;
		paragraph3.enabled = true;
		
		//Allow 20 seconds to pass, then disable the 3rd paragraph and enable the 4th
		yield return new WaitForSeconds (10);
		paragraph3.enabled = false;
		paragraph4.enabled = true;

		//Allow 10 seconds to pass, then enable the button


	}

	// Update is called once per frame
	void Update () {
	
		//If button is clicked, then go to the next scene

	}
}
