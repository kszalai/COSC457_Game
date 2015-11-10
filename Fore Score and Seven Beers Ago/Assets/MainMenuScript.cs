using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Button playButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {

		playButton = playButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {

		Application.LoadLevel (1);

	}

	public void ExitGame() {

		Application.Quit ();

	}
}
