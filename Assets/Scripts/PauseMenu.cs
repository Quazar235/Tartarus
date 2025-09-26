using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject Pause_Menu;

    public AudioSource Button_Click_Audio;

    public void Pause()
    {
        Button_Click_Audio.Play();
        Pause_Menu.SetActive(true); // Enable pause menu overlay
        Time.timeScale = 0f; // Freeze time
    }

    public void Resume()
    {
        Button_Click_Audio.Play();
        Pause_Menu.SetActive(false); // Disable pause menu overlay
        Time.timeScale = 1f; // Set time back to normal
    }

    public void Home(string Scene_Name)
    {
        Button_Click_Audio.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(Scene_Name); // Load the scene chosen in Unity (should be 'Main Menu')
    }

}
