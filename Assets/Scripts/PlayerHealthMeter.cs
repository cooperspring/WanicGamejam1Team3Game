//Cooper Spring, 11/13/2020, script to control the player's health bar
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthMeter : MonoBehaviour
{
    public static Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
    }

    public static void UpdatePlayerHealth(string currentHealth)
    {
        healthText.text = "Health : " + currentHealth;
    }
}
