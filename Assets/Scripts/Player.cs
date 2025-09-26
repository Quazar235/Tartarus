using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D Player_Rigid_Body; // Letting the players RigidBody2D be accessd from anywhere
    public float Speed = 5; // Players movement speed
    private float Vertical; // Players vertical value (1 or -1)
    private float Horizontal; // Players horizontal value (1 or -1)

    public SoulManager Soul_Manager; // Allows stuff from 'SoulManager' script to be used in this script

    public HealthBar Health_Bar; // Allows stuff from 'HealthBar' script to be used in this script
    public int Max_Health = 100;
    public int Current_Health;

    private float Timer;

    public GameOver Game_Over; // Allows stuff from 'GameOver' script to be used in this script

    public AudioSource Heart_Pickup_Audio;
    public AudioSource Golden_Heart_Pickup_Audio;
    public AudioSource Soul_Pickup_Audio;
    public AudioSource Death_Audio;

    public Transform Player_Tranform; // Location data of Player

    void Start() // Start is called before the first frame update
    {
        Player_Rigid_Body = GetComponent<Rigidbody2D>(); // Makes the 'Player_Rigid_Body' gameobject the Rigiddbody that is attatched to this script

        Current_Health = Max_Health; // Sets player health to max when game starts
        Health_Bar.Set_Max_Health(Max_Health); // Sets the Health Bar to display Max Health when game starts
    }

    void Update() // Update is called once per frame
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); // Checks the horizontal direction the player is moving every frame
        Vertical = Input.GetAxisRaw("Vertical"); // Checks the vertical direction the player is moving every frame
        /*  
         * Horizontal:
         * Left Key = -1
         * Right Key = 1
         * 
         * Veritcal:
         * Up Key = 1
         * Down Key = -1
         */
    }

    public void Gain_Max_Health()
    {
        Golden_Heart_Pickup_Audio.Play(); // Plays golden heart pickup audio clip
        Max_Health += 10; // Adds 10 to the players max health
        Gain_Health();
    }

    public void Gain_Health()
    {
        Heart_Pickup_Audio.Play(); // Plays heart pickup audio clip
        Current_Health = Max_Health; // Makes players health max
        Health_Bar.Set_Health(Max_Health); // Updated health bar when health is gained
    }

    public void Take_Damage(int Damage)
    {
        if (Current_Health > Damage) // Runs if the damage taken is less than current health
        {
            Current_Health -= Damage;
            Health_Bar.Set_Health(Current_Health); // Updated health bar when damage is taken
        }

        else if (Current_Health <= Damage) // Runs if the damage taken is more than current health
        {
            Current_Health -= Damage;
            Health_Bar.Set_Health(Current_Health); // Updated health bar when damage is taken
            Death();
        }
    }

    public void Death()
    {
        Death_Audio.Play(); // Plays the death audio clip
        Game_Over.Game_Over(); // Runs 'Game_Over' function in 'GameOver' script
    }

    void FixedUpdate() // Used to calcuate physics
    {
        Player_Rigid_Body.velocity = new Vector2(Horizontal * Speed, Vertical * Speed); // Calculates player movement
    }

    void OnTriggerEnter2D(Collider2D trigger) // Runs when player collides with a trigger
    {
        if (trigger.gameObject.CompareTag("Soul")) // Runs if the object is tagged 'Soul'
        {
            Soul_Pickup_Audio.Play(); // Plays the soul pickup audio clip
            Destroy(trigger.gameObject); // Destroy the object
            Soul_Manager.Soul_Amount += 1; // Adds 1 soul
        }
        else if (trigger.gameObject.CompareTag("Divine Soul")) // Runs if the object is tagged 'Divine Soul'
        {
            Soul_Pickup_Audio.Play(); // Plays the soul pickup audio clip
            Destroy(trigger.gameObject); // Destroy the object
            Soul_Manager.Divine_Soul_Amount += 1; // Adds 1 divine soul
        }
        else if (trigger.gameObject.CompareTag("Heart")) // Runs if the object is tagged 'Heart'
        {
            Destroy(trigger.gameObject); // Destroy the object
            Gain_Health();
        }
        else if (trigger.gameObject.CompareTag("Golden Heart")) // Runs if the object is tagged 'Golden Heart'
        {
            Destroy(trigger.gameObject); // Destroy the object
            Gain_Max_Health();
        }
        else if (trigger.gameObject.CompareTag("Magma")) // Runs if the object is tagged 'Magma'
        {
            Take_Damage(10);
        }
        else if (trigger.gameObject.CompareTag("Crusher")) // Runs if the object is tagged 'Crusher'
        {
            Death();
        }
        else if (trigger.gameObject.CompareTag("Teleport A")) // Runs if the object is tagged 'Teleport A'
        {
            Player_Tranform.transform.position = new Vector2(9.5f, -75f); // Teleports Player to the coordinates
        }
        else if (trigger.gameObject.CompareTag("Teleport B")) // Runs if the object is tagged 'Teleport B'
        {
            Player_Tranform.transform.position = new Vector2(-9.5f, -75f); // Teleports Player to the coordinates
        }
    }

    void OnTriggerStay2D(Collider2D trigger) // Runs while the player is colliding with a trigger
    {
        if (trigger.gameObject.CompareTag("Magma")) // Runs if the object is tagged 'Magma'
        {
            Timer += Time.deltaTime; // Makes 'Timer' variable go up in seconds

            if (Timer >= 0.5f) // Runs if the 'Timer' variable is less than or equal to 0.5
            {
                Take_Damage(5);
                Timer = 0f; // Sets 'Timer' variable back to 0
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) // Runs when player collides with something
    {
        if (collision.gameObject.CompareTag("Spike")) // Runs if the object is tagged 'Spike'
        {
            Take_Damage(5);
        }
    }

    void OnCollisionStay2D(Collision2D collision) // Runs while player is colliding with something
    {
        if (collision.gameObject.CompareTag("Spike")) // Runs if the object is tagged 'Spike'
        {
            Timer += Time.deltaTime; // Makes 'Timer' variable go up in seconds

            if (Timer >= 0.5f) // Runs if the 'Timer' variable is less than or equal to 0.5
            {
                Take_Damage(5);
                Timer = 0f; // Sets 'Timer' variable back to 0
            }
        }
    }
}
