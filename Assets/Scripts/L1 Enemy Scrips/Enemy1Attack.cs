using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy1Attack : MonoBehaviour
{
    public GameObject mainCameraE;

    public int damage;
    public GameObject targetE;
    private string ansiedade = "Ansiedade";
    public TextMeshProUGUI turnText;
    // Start is called before the first frame update


    public void E1Attack()
    {
        targetE = mainCameraE.GetComponent<UnitSelector>().currentGirlSelected;

        targetE.GetComponent<GirlStats>().health = targetE.GetComponent<GirlStats>().health - damage;



        if (targetE.GetComponent<GirlStats>().health <= 0)
        {
            mainCameraE.GetComponent<ListController>().RemoveFromList(targetE);
        }
        
    }

    public void E1SingleRandomAttack()
    {
        targetE = mainCameraE.GetComponent<ListController>().RandomGirlPicker();

        //Debug.Log(targetE);

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
            Debug.Log("No dmg 1");
            StartCoroutine(ShowText(0));
        }
        StartCoroutine(Atraso());

    }

    IEnumerator ShowText(int dmg)
    {
        turnText.gameObject.SetActive(true);
        turnText.text = ansiedade + " causa " + dmg + " de dano a " + targetE.name;
        yield return new WaitForSeconds(2f);
        turnText.gameObject.SetActive(false);
    }

    IEnumerator Atraso()
    {
        yield return new WaitForSeconds(2f);
        mainCameraE.GetComponent<ListController>().NextTurn();
    }

}
