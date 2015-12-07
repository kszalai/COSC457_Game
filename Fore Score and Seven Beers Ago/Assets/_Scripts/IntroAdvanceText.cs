using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroAdvanceText : MonoBehaviour {

	private Text paragraph1;
	private Text paragraph2;
	private Text paragraph3;
	private Text paragraph4;
	private Text paragraph5;
	private Button goToParagraph2Button;
	private Button goToParagraph3Button;
	private Button goToParagraph4Button;
	private Button goToParagraph5Button;
	private Button playGame;
	private AudioSource first, second, third, fourth, fifth;


	// Use this for initialization
	public void Start () {

		//Link all the components on the screen with the variables listed above
		paragraph1 = GameObject.FindWithTag("Paragraph1YouAreAbe").GetComponent<Text>() as Text;
		paragraph2 = GameObject.FindWithTag("Paragraph2FreakAccident").GetComponent<Text>() as Text;
		paragraph3 = GameObject.FindWithTag("Paragraph3BarCloses").GetComponent<Text>() as Text;
		paragraph4 = GameObject.FindWithTag("Paragraph4CaddyShows").GetComponent<Text>() as Text;
		paragraph5 = GameObject.FindWithTag("Paragraph5CaddyCannotLeave").GetComponent<Text>() as Text;
		goToParagraph2Button = GameObject.FindWithTag ("goToParagraph2").GetComponent<Button> () as Button;
		goToParagraph3Button = GameObject.FindWithTag ("goToParagraph3").GetComponent<Button> () as Button;
		goToParagraph4Button = GameObject.FindWithTag ("goToParagraph4").GetComponent<Button> () as Button;
		goToParagraph5Button = GameObject.FindWithTag ("goToParagraph5").GetComponent<Button> () as Button;
		playGame = GameObject.FindWithTag ("PlayGameButton").GetComponent<Button> () as Button;
		first = GameObject.FindWithTag ("introMusic1").GetComponent<AudioSource> () as AudioSource;
		second = GameObject.FindWithTag ("introMusic2").GetComponent<AudioSource> () as AudioSource;
		third = GameObject.FindWithTag ("introMusic3").GetComponent<AudioSource> () as AudioSource;
		fourth = GameObject.FindWithTag ("introMusic4").GetComponent<AudioSource> () as AudioSource;
		fifth = GameObject.FindWithTag ("introMusic5").GetComponent<AudioSource> () as AudioSource;


		//Set first paragraph to be visible, others to be invisible
		paragraph2.enabled = false;
		paragraph3.enabled = false;
		paragraph4.enabled = false;
		paragraph5.enabled = false;
		paragraph1.enabled = true;
		//Set first "Next" button to be visisble, others to be invisible
		goToParagraph3Button.enabled = false;
		goToParagraph4Button.enabled = false;
		goToParagraph5Button.enabled = false;
		goToParagraph2Button.enabled = true;
		//Set "Play Game" button to be visible
		playGame.enabled = true;


		//Start advancing through the text automatically
		//StartCoroutine(advanceText ());

	}

	public IEnumerator advanceText() // Not void, IEnumerator necessary to WaitForSeconds
	{
		yield return new WaitForSeconds (17);
		goToParagraph2 ();
		yield return new WaitForSeconds (20);
		goToParagraph3 ();
		yield return new WaitForSeconds (9);
		goToParagraph4 ();
		yield return new WaitForSeconds (22);
		goToParagraph5 ();


		/*Original Code to Control Advancement of Text

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

		*/

	}

	//Hide all paragraphs/next buttons and start fresh
	public void hideAllParagraphsAndNextButtons() {
		paragraph2.enabled = false;
		paragraph3.enabled = false;
		paragraph4.enabled = false;
		paragraph5.enabled = false;
		paragraph1.enabled = false;
		goToParagraph2Button.enabled = false;
		goToParagraph3Button.enabled = false;
		goToParagraph4Button.enabled = false;
		goToParagraph5Button.enabled = false;
	}

	public void goToParagraph2() {
		hideAllParagraphsAndNextButtons ();
		paragraph2.enabled = true;
		second.Play ();
		goToParagraph3Button.enabled = true;

		//yield return new WaitForSeconds (20);
		//goToParagraph3 ();
	}

	public void goToParagraph3() {
		hideAllParagraphsAndNextButtons ();
		paragraph3.enabled = true;
		third.Play ();
		goToParagraph4Button.enabled = true;

		//yield return new WaitForSeconds (9);
		//goToParagraph4 ();
	}

	public void goToParagraph4() {
		hideAllParagraphsAndNextButtons ();
		paragraph4.enabled = true;
		fourth.Play ();
		goToParagraph5Button.enabled = true;

		//yield return new WaitForSeconds (22);
		//goToParagraph5 ();
	}

	public void goToParagraph5() {
		hideAllParagraphsAndNextButtons ();
		fifth.Play ();
		paragraph5.enabled = true;
	}

	// Update is called once per frame
	public void Update () {
	
		//If button is clicked, then go to the next scene

	}
}
