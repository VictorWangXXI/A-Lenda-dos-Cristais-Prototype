using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GirlStats : MonoBehaviour
{
    public int maxHealth;
    public int maxMana;

    public int health;
    public int mana;

    public GameObject thisGirlMenu;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;


    // Start is called before the first frame update
    void Start()
    {
        SetGirlStatsText();
    }


    public void IncreaseManaAtEndTurn()
    {
        if (mana < maxMana)
        {
            mana++;
            SetGirlStatsText();
        }

    }

    public void myTurn()
    {
        thisGirlMenu.SetActive(true);
    }

    public void SetGirlStatsText()
    {
        if (mana == maxMana)
        {
            manaText.color = Color.green;
        }
        else
        {
            manaText.color = Color.white;
        }

        if (health <= 30)
        {
            healthText.color = Color.red;
        }
        else
        {
            healthText.color = Color.white;
        }
        healthText.text = "Vida: " + health + "/" + maxHealth;
        manaText.text = "Pt. Hab.: " + mana + "/" + maxMana;
    }

}
