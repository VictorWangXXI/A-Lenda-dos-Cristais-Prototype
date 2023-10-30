using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl3Skills : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject target;
    public GameObject thisGirl;
    public GameObject thisGirlMenu;

    public int skill1Damage = 3;

    public List<GameObject> alliesToHeal;
    public int healingPower;

    public GameObject noSkillPointsText;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BasicAttack()
    {
        target = mainCamera.GetComponent<UnitSelector>().currentEnemySelected;

        target.GetComponent<EnemyStats>().health = target.GetComponent<EnemyStats>().health - skill1Damage;
        target.GetComponent<EnemyStats>().SetEnemyStatsText();
        if (target.GetComponent<EnemyStats>().health <= 0)
        {
            mainCamera.GetComponent<ListController>().RemoveFromList(target);
        }

        thisGirl.GetComponent<GirlStats>().IncreaseManaAtEndTurn();
        thisGirlMenu.SetActive(false);
        mainCamera.GetComponent<ListController>().NextTurn();
    }

    public void SpAttack()
    {
        if (thisGirl.GetComponent<GirlStats>().maxMana == thisGirl.GetComponent<GirlStats>().mana)
        {
            alliesToHeal = mainCamera.GetComponent<ListController>().girlsInListC;
            foreach (GameObject allyToHeal in alliesToHeal)
            {
                if ((allyToHeal.GetComponent<GirlStats>().health + healingPower) >= allyToHeal.GetComponent<GirlStats>().maxHealth)
                {
                    allyToHeal.GetComponent<GirlStats>().health = allyToHeal.GetComponent<GirlStats>().maxHealth;
                    allyToHeal.GetComponent<GirlStats>().SetGirlStatsText();
                }
                else
                {
                    allyToHeal.GetComponent<GirlStats>().health = allyToHeal.GetComponent<GirlStats>().health + healingPower;
                    allyToHeal.GetComponent<GirlStats>().SetGirlStatsText();
                }
            }

            thisGirl.GetComponent<GirlStats>().mana = 0;
            thisGirl.GetComponent<GirlStats>().SetGirlStatsText();
            thisGirlMenu.SetActive(false);
            mainCamera.GetComponent<ListController>().NextTurn();
        }
        else
        {
            if (noSkillPointsText.activeSelf == false)
            {
                StartCoroutine(MessageNoSkillPoints());
            }
        }
    }

    IEnumerator MessageNoSkillPoints()
    {
        noSkillPointsText.SetActive(true);
        yield return new WaitForSeconds(3f);
        noSkillPointsText.SetActive(false);
    }

}

