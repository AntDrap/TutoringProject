using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBehavior : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI boltText;

    public static UIBehavior instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateHealth(int health, int maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    public void UpdateBolts(int boltAmount)
    {
        boltText.text = "Bolts: " + boltAmount;
    }
}