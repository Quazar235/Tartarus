using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Game_Over_Menu;
    [SerializeField] GameObject You_Win_Menu;

    public void Game_Over()
    {
        Game_Over_Menu.SetActive(true); // Enables the 'Game_Over_Menu'
        Time.timeScale = 0f; // Freezes time
    }

    public void Home(string Scene_Name)
    {
        Time.timeScale = 1f; // Freezes time
        SceneManager.LoadScene(Scene_Name); // Load the scene chosen in Unity (should be 'Main Menu')
    }

    public void You_Win()
    {
        You_Win_Menu.SetActive(true); // Enables the 'You_Win_Menu'
        Time.timeScale = 0f; // Freezes time
    }
}
