using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeOfArgus : MonoBehaviour
{
    public GameObject Spike; // The spike
    public Transform Spike_Position; // The spikes positional data

    private float Timer;

    private GameObject Player; // The player

    public int Eye_Of_Argus_Current_Health; // The eye's current health
    public int Eye_Of_Argus_Max_Health = 5; // The eye's max health

    public GameOver Game_Over_Script; // Allows stuff from 'GameOver' script to be used in this script

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // Makes 'Player' the object the one tagged 'Player'

        Eye_Of_Argus_Current_Health = Eye_Of_Argus_Max_Health; // Resets the eye's health to max at the start of the game
    }

    // Update is called once per frame
    void Update()
    {
        float Spike_Range = Vector2.Distance(transform.position, Player.transform.position); // Checks the distance from the boss to the player

        if(Spike_Range < 10) // Runs if 'Spike_Range' is less than 10
        {
            Timer += Time.deltaTime; // Makes 'Timer' variable go up in seconds

            if (Timer > 1f) // Runs if the 'Timer' variable is less than or equal to 1
            {
                Timer = 0f; // Resets 'Timer' variable
                Shoot();
            }
        }
    }
    
    void Shoot()
    {
        Instantiate(Spike, Spike_Position.position, Quaternion.identity); // Spawns spike at 'Spike_Position'
    }

    public void Eye_Take_Damage(int Eye_Damage)
    {
        if (Eye_Of_Argus_Current_Health > Eye_Damage) // Runs if 'Eye_Of_Argus_Current_Health' is more than the incoming damage
        {
            Eye_Of_Argus_Current_Health -= Eye_Damage;
        }
        else if (Eye_Of_Argus_Current_Health <= Eye_Damage) // Runs if 'Eye_Of_Argus_Current_Health' is less than the incoming damage
        {
            Eye_Of_Argus_Current_Health -= Eye_Damage;
            Game_Over_Script.You_Win(); // Runs the 'You_Win' function in the 'GameOver' script
        }
    }
}
