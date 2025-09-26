using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBlast : MonoBehaviour
{
    private GameObject Eye_Of_Argus; // The boss
    private Rigidbody2D Soul_Blast_Rigid_Body; // The soul blast
    public float Soul_Blast_Speed; // The soul blast speed

    // Start is called before the first frame update
    void Start()
    {
        Soul_Blast_Rigid_Body = GetComponent<Rigidbody2D>(); // Makes 'Soul_Blast_Rigid_Body' the rigidbody this script is attached to
        Eye_Of_Argus = GameObject.FindGameObjectWithTag("Eye of Argus"); // Makes 'Eye_Of_Argus' the object the one tagged 'Eye of Argus'

        Vector3 Direction = Eye_Of_Argus.transform.position - transform.position; // Makes 'Direction' the direction towards the eye of argus
        Soul_Blast_Rigid_Body.velocity = new Vector2(Direction.x, Direction.y).normalized * Soul_Blast_Speed; // Makes the soul blast move towards the player
                                                                                                              // Also makes the velocity equal to 'Soul_Blast_Speed'

        float Soul_Blast_Rotation = Mathf.Atan2(-Direction.y, -Direction.x) * Mathf.Rad2Deg; // Calculates the rotation the soul blast should be
        transform.rotation = Quaternion.Euler(0, 0, Soul_Blast_Rotation + 180); // Makes the soul blasts's rotation equal 'Soul_Blast_Rotation'
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D trigger) // Runs when a soul blast collides with a trigger
    {
        if (trigger.gameObject.CompareTag("Eye of Argus")) // Runs if the object is tagged 'Eye of Argus'
        {
            trigger.gameObject.GetComponent<EyeOfArgus>().Eye_Take_Damage(1); // Runs the 'Eye_Take_Damage' function in 'EyeOfArgus' script with a value of 1
            Destroy(gameObject);
        }
        if (trigger.gameObject.CompareTag("Crusher")) // Runs if the object is tagged 'Crusher'
        {
            Destroy(gameObject);
        }
        if (trigger.gameObject.CompareTag("Box")) // Runs if the object is tagged 'Box'
        {
            Destroy(gameObject);
        }
    }
}
