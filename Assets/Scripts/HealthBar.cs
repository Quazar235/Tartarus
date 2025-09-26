using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider Health_Slider; // The health slider
    public TMP_Text Health_Number; // The health number

    public void Set_Max_Health(int Health) // Sets the health slider to max
    {
        Health_Slider.maxValue = Health; // Sets the health bars max value to 'Health'
        Health_Slider.value = Health; // Sets the health bars value to 'Health'
        Health_Number.text = Health.ToString(); // Sets the health numbers value to 'Health'
    }

    public void Set_Health(int Health) // Makes the health slider update
    {
        Health_Slider.value = Health; // Sets the health bars value to 'Health'
        Health_Number.text = Health.ToString(); // Sets the health numbers value to 'Health'
    }
}
