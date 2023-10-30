using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListController : MonoBehaviour
{
    public GameObject sameCamera;

    [SerializeField] public List<GameObject> enemiesInListC;
    [SerializeField] public List<GameObject> girlsInListC;

    public int enemiesLeft;
    public int girlsLeft;

    
    [SerializeField] private List<GameObject> allUnitsList;

    public GameObject g1menu;
    public GameObject g2menu;
    public GameObject g3menu;

    public int turnIndex;

    public bool girlsInvincibility;

    // Start is called before the first frame update
    void Start()
    {
        allUnitsList.AddRange(girlsInListC);
        allUnitsList.AddRange(enemiesInListC);

        turnIndex = 0;
        girlsInvincibility = false;

        g2menu.gameObject.SetActive(false);
        g3menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RemoveFromList(GameObject aRemover)
    {


        if (aRemover.tag == "Enemy")
        {
            Debug.Log(aRemover + "morreu");
            enemiesInListC.Remove(aRemover);
            allUnitsList.Remove(aRemover);
            enemiesLeft--;
            aRemover.GetComponent<EnemyStats>().healthText.gameObject.SetActive(false);
            aRemover.gameObject.SetActive(false);

            if (enemiesLeft <= 0)
            {
                sameCamera.GetComponent<UnitSelector>().DisableEnemyIcon();
            }
            else
            {
                sameCamera.GetComponent<UnitSelector>().CheckWichEnemy(enemiesInListC[0]);
            }
        }
        else
        {
            Debug.Log(aRemover + "morreu");
            girlsInListC.Remove(aRemover);
            allUnitsList.Remove(aRemover);
            girlsLeft--;
            aRemover.gameObject.SetActive(false);

            if (girlsLeft <= 0)
            {
                sameCamera.GetComponent<UnitSelector>().DisableGirlIcon();
            }
            else
            {
                sameCamera.GetComponent<UnitSelector>().CheckWichGirl(girlsInListC[0]);
            }
        }

    }

    public GameObject RandomGirlPicker()
    {
        GameObject girlpicked = girlsInListC[Random.Range(0, girlsInListC.Count)];
        return girlpicked;
    }

    public GameObject RandomEnemyPicker()
    {
        GameObject enemypicked = enemiesInListC[Random.Range(0, enemiesInListC.Count)];
        return enemypicked;
    }



    public void NextTurn()
    {
        if((enemiesLeft == 0) || (girlsLeft == 0))
        {
            if (enemiesLeft == 0)
            {
                sameCamera.GetComponent<PauseMenu>().Win();
            }
            if (girlsLeft == 0)
            {
                sameCamera.GetComponent<PauseMenu>().Derrota();
            }
        }
        else if (turnIndex >= (enemiesLeft+girlsLeft-1))
        {
            turnIndex = 0;
            EndTurnClearEffects();
            TriggerTurn();
        }
        else 
        {
            turnIndex++;
            TriggerTurn();
        }
    }


    public void EndTurnClearEffects()
    {
        girlsInvincibility = false;
    }


    public void TriggerTurn()
    {
        if (allUnitsList[turnIndex].tag == "Girl")
        {
            //Debug.Log("turno de " + allUnitsList[turnIndex].name);
            allUnitsList[turnIndex].GetComponent<GirlStats>().myTurn();
        }
        else if (allUnitsList[turnIndex].tag == "Enemy")
        {
            sameCamera.GetComponent<GlobalEnemiesController>().CheckEnemy(allUnitsList[turnIndex].name);
        }
    }
}
