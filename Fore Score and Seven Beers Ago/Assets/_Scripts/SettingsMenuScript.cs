using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenuScript : MonoBehaviour {
	
	public Button easyButton;
	public Button normalButton;
	public Button hardButton;

	private GameObject Lev1;
	
	//index value of first Single Player Level
	private int SPIndexStart = 1;

	//index value of first Multi Player Level
	//private int MPIndexStart = 4;
	
	// Use this for initialization
	void Start () {
		
		easyButton = easyButton.GetComponent<Button> ();
		normalButton = normalButton.GetComponent<Button> ();
		hardButton = hardButton.GetComponent<Button> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void EasyGame() {
		
		Application.LoadLevel (SPIndexStart);

		
	}
	
	public void NormalGame() {
		
		Application.LoadLevel (SPIndexStart);
		
	}

	public void HardGame() {

		Application.LoadLevel (SPIndexStart);
	
	}
}
