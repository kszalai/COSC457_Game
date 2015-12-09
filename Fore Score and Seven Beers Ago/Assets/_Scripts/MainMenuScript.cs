using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Button playButton;
	public Button settingsButton;
	public Button exitButton;

    //index value of first Single Player Level
    private int SPIndexStart = 1;

    //index value of first Multi Player Level
    //private int MPIndexStart = 4;

	// Use this for initialization
	void Start () {

		playButton = playButton.GetComponent<Button> ();
		settingsButton = settingsButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
        PlayerPrefs.SetInt("difficulty", 2);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {

		Application.LoadLevel (2);

	}

	public void ExitGame() {

		Application.Quit ();

	}

	public void OpenSettings() {

		Application.LoadLevel ("SettingsMenu");

	}
}
