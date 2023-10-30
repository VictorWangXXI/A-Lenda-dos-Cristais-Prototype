using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        SetEnemyStatsText();
    }

    public void SetEnemyStatsText()
    {
        healthText.text = health + "/" + maxHealth;
    }
}
