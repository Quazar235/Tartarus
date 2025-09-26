using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Soul_Blast; // The soul blast
    public Transform Soul_Blast_Position; // The soul blast's positional data
    public float Soul_Blast_Speed; // Speed of the soul blast

    public Player Player_Script; // Allows stuff from Player script to be used in this script
    public SoulManager Soul_Manager_Script; // Allows stuff from SoulManager script to be used in this script

    public GameObject Pause_Menu_Script;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0)) && (!Pause_Menu_Script.activeSelf))// Runs if the left mouse button is clicked
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(Soul_Blast, Soul_Blast_Position.position, Quaternion.identity);
    }
}
