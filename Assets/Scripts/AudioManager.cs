using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider Volume_Slider; // The volume slider
    
    void Start()
    {
        if(!PlayerPrefs.HasKey("Sound Volume")) // Runs if there's a value in 'Sound Volume' from previous session
        {
            PlayerPrefs.SetFloat("Sound Volume", 1);
            Load();
        }
        
        else
        {
            Load();
        }
    }

    public void Change_Volume()
    {
        AudioListener.volume = Volume_Slider.value; // Sets the volume of the game to the value of the slider
        Save();
    }

    private void Load()
    {
        Volume_Slider.value = PlayerPrefs.GetFloat("Sound Volume"); // Set's the value of volume slider to the value in 'Sound Volume'
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Sound Volume", Volume_Slider.value); // Saves the volume slider value
    }
}
