using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public GameObject GolfCartModel;

    public int StartingHealth = 100;
    public int CurrentHealth;
    public Slider HealthSlider;
    public CameraMovement GameCamera;

    private float OldCameraSpeed;
    private Vector3 DefaultPlayerStart;
    private Vector3 DefaultCameraStart;
    private bool IsDead;
    public bool Damaged;
    private int DamageFlashCount = 0;

    Player Player;

    void Awake()
    {
        CurrentHealth = StartingHealth;
        DefaultCameraStart = GameCamera.transform.position;
        DefaultPlayerStart = transform.position;
        Player = GetComponent<Player>();
    }
	
	void FixedUpdate()
    {
        //If we are damaged, blink the player
        if (Damaged && !IsDead)
        {
            DamageFlashCount = 0;
            InvokeRepeating("FlashingDamage", 0f, .1f);
        }
	}

    void FlashingDamage()
    {
        //Count how many times we flashed
        DamageFlashCount++;
        if (DamageFlashCount % 2 == 1)
        {
            GolfCartModel.SetActive(false);
        }
        else
        {
            GolfCartModel.SetActive(true);
        }

        if (DamageFlashCount == 10)
        {
            CancelInvoke("FlashingDamage");
            Damaged = false;
        }
    }

    //Other scripts and components call this function
    public void ChangeHealth(int amount)
    {
        //Player took damage, blink player
        Damaged = true;

        //Take away health
        if((CurrentHealth + amount) <= 0)
        {
            CurrentHealth = 0;
        }
        else if((CurrentHealth + amount) >= 100)
        {
            CurrentHealth = StartingHealth;
        }
        else
        {
            CurrentHealth += amount;
        }

        //Update slider in Game
        HealthSlider.value = CurrentHealth;

        //Check to see if the player is dead
        if(CurrentHealth <= 0 && !IsDead)
        {
            Death();
        }
    }

    void Death()
    {
        //Player is dead
        IsDead = true;

        //Stop camera from moving
        OldCameraSpeed = GameCamera.cameraSpeed;
        GameCamera.cameraSpeed = 0;
        GolfCartModel.SetActive(false);

        //Once we get reference to Game Time, check to see if we're out of time,
        //or about to be out of time by the time we respawn
        
        //Wait for 5 seconds
        Invoke("Respawn", 5f);
    }

    void Respawn()
    {
        //Respawn at beginning of level where we died
        transform.position = DefaultPlayerStart;
        Player.setCurrentLane(0);

        //Move GameCamera back to where player is
        GameCamera.transform.position = DefaultCameraStart;

        //Turn back on our player
        GolfCartModel.SetActive(true);

        //Give player full health again
        ChangeHealth(StartingHealth);

        //Start camera at old speed it was at
        GameCamera.cameraSpeed = OldCameraSpeed;

        IsDead = false;
    }
}