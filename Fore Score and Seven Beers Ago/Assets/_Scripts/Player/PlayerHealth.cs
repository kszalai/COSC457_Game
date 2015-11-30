using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public GameObject GolfCartModel;

    public int StartingHealth = 100;
    public int CurrentHealth;
    public Slider HealthSlider;
    public CameraMovement GameCamera;
    //Reference to Game Time here

    private float OldCameraSpeed;
    private bool IsDead;
    private bool Damaged;
    private int DamageFlashCount = 0;

    void Awake()
    {
        CurrentHealth = StartingHealth;
    }
	
	void Update ()
    {
        //If we are damaged, blink the player
        if (Damaged)
        {
            DamageFlashCount = 0;
            InvokeRepeating("FlashingDamage", 0f, 0.5f);
        }
        Damaged = false;
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
            GolfCartModel.SetActive(true);

        if (DamageFlashCount == 3)
            CancelInvoke("FlashingDamage");
    }

    //Other scripts and components call this function
    public void TakeDamage(int amount)
    {
        //Player took damage, blink player
        Damaged = true;

        //Take away health
        CurrentHealth -= amount;

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
        //Respawn behind where we died
        GolfCartModel.transform.position = new Vector3(GolfCartModel.transform.position.x - 10,
            GolfCartModel.transform.position.y, GolfCartModel.transform.position.z);

        //Move GameCamera back to where player is
        GameCamera.transform.position = new Vector3(GameCamera.transform.position.x - 10,
            GameCamera.transform.position.y, GameCamera.transform.position.z);

        //Turn back on our player
        GolfCartModel.SetActive(true);

        //Give player full health again
        CurrentHealth = StartingHealth;

        //Start camera at old speed it was at
        GameCamera.cameraSpeed = OldCameraSpeed;
    }
}