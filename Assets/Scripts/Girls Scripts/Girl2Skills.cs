using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Girl2Skills : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject target;
    public GameObject thisGirl;
    public GameObject thisGirlMenu;

    public int skill1Damage = 2;

    public int spSkillDamage;

    public List<GameObject> enemiesToAttack;
    public GameObject[] enemiesToRemove;
    public int i = 0;

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
            enemiesToAttack = mainCamera.GetComponent<ListController>().enemiesInListC;
            foreach(GameObject enemyTA in enemiesToAttack)
            {
                enemyTA.GetComponent<EnemyStats>().health = enemyTA.GetComponent<EnemyStats>().health - spSkillDamage;
                enemyTA.GetComponent<EnemyStats>().SetEnemyStatsText();
                if (enemyTA.GetComponent<EnemyStats>().health <= 0)
                {
                    //mainCamera.GetComponent<ListController>().RemoveFromList(enemyTA);
                    //Debug.Log(enemyTA);
                    enemiesToRemove[i] = enemyTA;
                    i++;
                }
            }

            if (i != 0)
            {
                Debug.Log("remove start");
                for (int count=0; count != i; count++)
                {
                    Debug.Log(enemiesToRemove[count]);
                    mainCamera.GetComponent<ListController>().RemoveFromList(enemiesToRemove[count]);
                }
                i = 0;
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

