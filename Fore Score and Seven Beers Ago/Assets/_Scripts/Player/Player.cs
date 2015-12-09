using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {
    public GameObject SP_Camera;

    //TODO: This should be changed to be more dynamic in the future
    public int numberOfMenus;
    public int numberOfLevels;
    private int numberOfScenes;

    private int currentLane;
    private int minLane;
    private int maxLane;

    public float minSpeed;
    public float restingSpeed;
    public float maxSpeed;
    private float desiredSpeed;
    
	private AudioSource Music;
    public AudioClip MedalMusic;

    private Text SuccessText;
    public Text LoseText;
	private Text ArrowText;

    PlayerHealth PlayerHealth;

    void Awake()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
    }

    void Start()
    {
        numberOfScenes = numberOfMenus + numberOfLevels;

        currentLane = 0;
        minLane = 0;
        maxLane = 5;

        // SCALE SPEED WITH DIFFICULTY

        restingSpeed = restingSpeed * PlayerPrefs.GetInt("difficulty", 2);
        minSpeed = minSpeed * PlayerPrefs.GetInt("difficulty", 2);
        maxSpeed = maxSpeed * PlayerPrefs.GetInt("difficulty", 2);

        Music = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        SuccessText = GameObject.FindWithTag("SuccessText").GetComponent<Text>();
        LoseText = GameObject.FindWithTag("LoseText").GetComponent<Text>();

        try
        {
		    ArrowText = GameObject.FindWithTag ("UseArrowKeysText").GetComponent<Text>();
            ArrowText.enabled = false;
            StartCoroutine(beginFirstLevel());
        }
        catch(NullReferenceException e)
        {
            //ArrowText does not exist
        }

        SuccessText.enabled = false;
    }

    void Update()
    {
        // CHANGE LANES

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changeLane(1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            changeLane(-1);
        }
        else
        {
            //stay in same lane
        }


        // SET SPEED

        desiredSpeed = restingSpeed;

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < SP_Camera.transform.position.x + 4f)
        {
            desiredSpeed = maxSpeed;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > SP_Camera.transform.position.x - (4f + transform.lossyScale.x))
        {
            desiredSpeed = minSpeed;
        }
    }

    void FixedUpdate()
    {
        if (Application.loadedLevelName == "SettingsMenu")
        {
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + 5, transform.rotation.z));
            transform.position = new Vector3(transform.position.x + desiredSpeed, transform.position.y, transform.position.z);
        }
        else
            transform.position = new Vector3(transform.position.x + desiredSpeed, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter (Collider other)
    {
        string tag = other.gameObject.tag;
        if (PlayerHealth.Damaged != true)
        {
            switch (tag)
            {
                case "Alligator":
                {
                    //print("Hit by Alligator");
                    PlayerHealth.ChangeHealth(-25);
                    changeLane(1);
                    break;
                }
                case "CokeCan":
                {
                    //print("Hit by CokeCan");
                    Destroy(other.gameObject);
                    PlayerHealth.ChangeHealth(-10);
                    break;
                }
                case "CokeMachine":
                {
                    //print("Hit by CokeMachine");
                    changeLane(1);
                    PlayerHealth.ChangeHealth(-5);
                    break;
                }
                case "Gopher":
                {
                    //print("Hit by Gopher");
                    changeLane(1);
                    PlayerHealth.ChangeHealth(-25);
                    break;
                }
                case "Pond":
                {
                    //print("Hit by Pond");
                    desiredSpeed = minSpeed;
                    break;
                }
                case "SandTrap":
                {
                    //print("Hit by SandTrap");
                    desiredSpeed = minSpeed;
                    break;
                }
                case "Tees":
                {
                    //print("Hit by Tees");
                    PlayerHealth.ChangeHealth(-50);
                    break;
                }
                case "EndLine":
                {
                    //print("END LINE, BABY");
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    StartCoroutine(endLevel());
                    break;
                }
            }
        }
    }

    private void changeLane(int direction)
    {
        if(direction == 1 && currentLane < maxLane)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            currentLane++;
        }
        else if(direction == -1 && currentLane > minLane)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            currentLane--;
        }
    }

	private IEnumerator beginFirstLevel() 
	{
		ArrowText.enabled = true;

		yield return new WaitForSeconds (5);

		ArrowText.enabled = false;
	}

    private IEnumerator endLevel()
    {
        SuccessText.enabled = true;
        Music.clip = MedalMusic;
        Music.Play();
        

        yield return new WaitForSeconds(5);

        SuccessText.enabled = false;

        if (Application.loadedLevel == numberOfScenes-1)
        {
            Application.LoadLevel(0);
        }
        else
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

    public void setCurrentLane(int lane)
    {
        currentLane = lane;
    }
}
