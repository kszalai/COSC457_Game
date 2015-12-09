using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenuScript : MonoBehaviour {
	
	public Button easyButton;
	public Button normalButton;
	public Button hardButton;
	public Button cancelButton;
    
    private const int easy = 1;
    private const int normal = 2;
    private const int hard = 3;

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
		cancelButton = cancelButton.GetComponent<Button> ();
		
	}
	
	public void EasyGame() {
		
		Application.LoadLevel (2);
        setDifficulty(easy);
		
	}
	
	public void NormalGame() {
		
		Application.LoadLevel (2);
        setDifficulty(normal);

    }

	public void HardGame() {

		Application.LoadLevel (2);
        setDifficulty(hard);

    }

	public void CancelClick(){

		Application.LoadLevel (0);

	}

    private int getDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", normal);
    }

    private void setDifficulty(int newDifficulty)
    {
        PlayerPrefs.SetInt("difficulty", newDifficulty);
        PlayerPrefs.Save();
    }
}
