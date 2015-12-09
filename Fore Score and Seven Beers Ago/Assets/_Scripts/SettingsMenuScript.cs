using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenuScript : MonoBehaviour {
	
	public Button easyButton;
	public Button normalButton;
	public Button hardButton;
	public Button backButton;
    
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
        backButton = backButton.GetComponent<Button> ();
        setDifficulty(getDifficulty());

    }

    void OnLevelWasLoaded()
    {
        setDifficulty(getDifficulty());
    }
	
	public void EasyGame() {
		
        setDifficulty(easy);
		
	}
	
	public void NormalGame() {
		
        setDifficulty(normal);

    }

	public void HardGame() {
        
        setDifficulty(hard);

    }

	public void BackClick(){

		Application.LoadLevel (0);

	}

    private int getDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", normal);
    }

    private void setDifficulty(int newDifficulty)
    {
        easyButton.GetComponent<Outline>().effectColor = new Color(1, 1, 1);
        normalButton.GetComponent<Outline>().effectColor = new Color(1, 1, 1);
        hardButton.GetComponent<Outline>().effectColor = new Color(1, 1, 1);

        switch (newDifficulty)
        {
            case 1:
                easyButton.GetComponent<Outline>().effectColor = new Color(0, 0, 0);
                break;

            case 2:
                normalButton.GetComponent<Outline>().effectColor = new Color(0, 0, 0);
                break;

            case 3:
                hardButton.GetComponent<Outline>().effectColor = new Color(0, 0, 0);
                break;
        }

        PlayerPrefs.SetInt("difficulty", newDifficulty);
        PlayerPrefs.Save();
    }
}
