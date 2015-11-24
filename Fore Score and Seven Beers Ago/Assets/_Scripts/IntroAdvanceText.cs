using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroAdvanceText : MonoBehaviour {

	private Text paragraph1;
	private Text paragraph2;
	private Text paragraph3;
	private Text paragraph4;
	private Text paragraph5;
	private Button playGame;


	// Use this for initialization
	void Start () {
	
		//paragraph1 = GameObject.FindGameObjectWithTag ("Paragraph1YouAreAbe");
		//Transform textTr = paragraph1.transform.Find ("paragraph1");
		//Text text = textTr .GetComponent<Text>();

		paragraph1 = GameObject.FindWithTag("Paragraph1YouAreAbe").GetComponent<Text>() as Text;
		paragraph2 = GameObject.FindWithTag("Paragraph2FreakAccident").GetComponent<Text>() as Text;
		paragraph3 = GameObject.FindWithTag("Paragraph3BarCloses").GetComponent<Text>() as Text;
		paragraph4 = GameObject.FindWithTag("Paragraph4CaddyShows").GetComponent<Text>() as Text;
		paragraph5 = GameObject.FindWithTag("Paragraph5CaddyCannotLeave").GetComponent<Text>() as Text;
		playGame = GameObject.FindWithTag ("PlayGameButton").GetComponent<Button> () as Button;

		//paragraph1 = GetComponent<Text> ();
		//paragraph2 = GetComponent<Text> ();
		//paragraph3 = GetComponent<Text> ();
		//paragraph4 = GetComponent<Text> ();

		//Set first paragraph to be visible, others to be invisible
		paragraph2.enabled = false;
		paragraph3.enabled = false;
		paragraph4.enabled = false;
		paragraph5.enabled = false;
		paragraph1.enabled = true;
		playGame.enabled = true;

		StartCoroutine(advanceText ());

		//Allow 15 seconds to pass, then disable the 1st paragraph and enable the 2nd
		//yield WaitForSeconds (10);
		//if (Time.time >= 5) {
		//	paragraph1.enabled = false;
		//	paragraph2.enabled = true;
		//}




	}

	IEnumerator advanceText() // Not void
	{
		//First paragraph is already showing (1st song plays for 15 seconds)
		//Allow 15 seconds to pass (1st song finishes)
		yield return new WaitForSeconds (17);

		//2nd song starts playing (31 seconds). Disable 1st paragraph, enable 2nd
		paragraph1.enabled = false;
		paragraph2.enabled = true;

		//Allow 2/3 of the song to pass (20 seconds). Disable 2nd paragraph, enable 3rd
		yield return new WaitForSeconds (20);
		paragraph2.enabled = false;
		paragraph3.enabled = true;

		//Allow the last 11 seconds of 2nd song to pass, then disable the 3rd paragraph and enable the 4th
		yield return new WaitForSeconds (9);
		paragraph3.enabled = false;
		paragraph4.enabled = true;
		
		//Allow 20 seconds to pass, then disable the 3rd paragraph and enable the 4th
		yield return new WaitForSeconds (22);
		paragraph4.enabled = false;
		paragraph5.enabled = true;

	}

	// Update is called once per frame
	void Update () {
	
		//If button is clicked, then go to the next scene

	}
}
