using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private GameObject Player; // The player
    private Rigidbody2D Spike_Rigid_Body; // The spike
    public float Spike_Speed; // The spike speed

    // Start is called before the first frame update
    void Start()
    {
        Spike_Rigid_Body = GetComponent<Rigidbody2D>(); // Makes 'Spike_Rigid_Body' the rigidbody this script is attached to
        Player = GameObject.FindGameObjectWithTag("Player"); // Makes 'Player' the object the one tagged 'Player'

        Vector3 Direction = Player.transform.position - transform.position; // Makes 'Direction' the direction towards the player
        Spike_Rigid_Body.velocity = new Vector2(Direction.x, Direction.y).normalized * Spike_Speed; // Makes the spike move towards the player
                                                                                                    // Also makes the velocity equal to 'Spike_Speed'

        float Spike_Rotation = Mathf.Atan2(-Direction.y, -Direction.x) * Mathf.Rad2Deg; // Calculates the rotation the spike should be
        transform.rotation = Quaternion.Euler(0, 0, Spike_Rotation + 90); // Makes the spike's rotation equal 'Spike_Rotation'
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls")) // Runs if the object is tagged 'Walls'
        {
            Destroy(gameObject); // Destroys the spike
        }
        else if (collision.gameObject.CompareTag("Crusher")) // Runs if the object is tagged 'Crusher'
        {
            Destroy(gameObject); // Destroys the spike
        }
        else if (collision.gameObject.CompareTag("Spike")) // Runs if the object is tagged 'Spike'
        {
            Destroy(gameObject); // Destroys the spike
        }
        else if (collision.gameObject.CompareTag("Player")) // Runs if the object is tagged 'Player'
        {
            collision.gameObject.GetComponent<Player>().Take_Damage(20); // Runs the 'Take_Damage' function in 'Player' script
            Destroy(gameObject); // Destroys the spike
        }
    }
}
