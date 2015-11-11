using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Button playButton;
	public Button exitButton;

    //index value of first Single Player Level
    private int SPIndexStart = 1;

    //index value of first Multi Player Level
    //private int MPIndexStart = 4;

	// Use this for initialization
	void Start () {

		playButton = playButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {

		Application.LoadLevel (SPIndexStart);

	}

	public void ExitGame() {

		Application.Quit ();

	}
}
