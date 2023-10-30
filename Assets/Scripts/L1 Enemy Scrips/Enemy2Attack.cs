using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy2Attack : MonoBehaviour
{
    public GameObject mainCameraE;

    public int damage;
    public GameObject targetE;
    private string fome = "Fome";
    public TextMeshProUGUI turnText;

    public void E2SingleRandomAttack()
    {
        targetE = mainCameraE.GetComponent<ListController>().RandomGirlPicker();

        if (mainCameraE.GetComponent<ListController>().girlsInvincibility == false)
        {
            targetE.GetComponent<GirlStats>().health = targetE.GetComponent<GirlStats>().health - damage;
            targetE.GetComponent<GirlStats>().SetGirlStatsText();
            StartCoroutine(ShowText(damage));
            if (targetE.GetComponent<GirlStats>().health <= 0)
            {
                mainCameraE.GetComponent<ListController>().RemoveFromList(targetE);
            }
        }
        else
        {
            Debug.Log("No dmg 2");
            StartCoroutine(ShowText(0));
        }

        StartCoroutine(Atraso());

    }

    IEnumerator ShowText(int dmg)
    {
        turnText.gameObject.SetActive(true);
        turnText.text = fome + " causa " + dmg + " de dano a " + targetE.name;
        yield return new WaitForSeconds(2f);
        turnText.gameObject.SetActive(false);
    }

    IEnumerator Atraso()
    {
        yield return new WaitForSeconds(2f);
        mainCameraE.GetComponent<ListController>().NextTurn();
    }
}
