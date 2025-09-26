using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Go_To_Scene(string sceneName) // Stuff that happens when you press 'Start'
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit_App() // Stuff that happens when you press 'Quit'
    {
        Application.Quit();
        Debug.Log("Application has Quit.");
    }
}
