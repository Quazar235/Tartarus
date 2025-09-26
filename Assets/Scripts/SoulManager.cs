using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoulManager : MonoBehaviour
{
    public int Soul_Amount;
    public int Divine_Soul_Amount;

    public TMP_Text Soul_Text;
    public TMP_Text Divine_Soul_Text;

    // Update is called once per frame
    void Update()
    {
        Soul_Text.text = Soul_Amount.ToString(); // Updates text to show Soul amount
        Divine_Soul_Text.text = Divine_Soul_Amount.ToString(); // Updates text to show Divine Soul amount
    }
}
