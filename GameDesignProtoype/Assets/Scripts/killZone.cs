using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killZone : MonoBehaviour
{
    public GameObject minionDead1;
    public GameObject minionDead2;
    public GameObject minionDead3;
    private bool tempactive = true;
    public bool permanent = false;

    void Start()
    {
        minionDead1 = GameObject.Find("Minion (1)").gameObject.transform.GetChild(0).gameObject;
        minionDead2 = GameObject.Find("Minion (2)").gameObject.transform.GetChild(0).gameObject;
        minionDead3 = GameObject.Find("Minion (3)").gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tempactive || permanent) //If the deathplane hasn't been deactivated or is always active
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameObject.Find("Player").SendMessage("gotoCP");
            }

            if (other.gameObject.CompareTag("Minion1"))
            {
                GameObject.FindWithTag("Minion1").GetComponent<AudioSource>().volume = 0.0f;
                GameObject.FindWithTag("Minion1").SendMessage("DeactivateMinion");
                minionDead1.SendMessage("changeColorDead");
                tempactive = false; //This and other duplicate lines deactivate the death plane, but only when the minions touch it.
                if (!permanent)
                {
                    gameObject.SetActive(false);
                }

                other.gameObject.tag = "Dead";
            }

            if (other.gameObject.CompareTag("Minion2"))
            {
                GameObject.FindWithTag("Minion2").GetComponent<AudioSource>().volume = 0.0f;
                GameObject.FindWithTag("Minion2").SendMessage("DeactivateMinion");
                minionDead2.SendMessage("changeColorDead");
                tempactive = false;
                if (!permanent)
                {
                    gameObject.SetActive(false);
                }
                other.gameObject.tag = "Dead";
            }

            if (other.gameObject.CompareTag("Minion3"))
            {
                GameObject.FindWithTag("Minion3").GetComponent<AudioSource>().volume = 0.0f;
                GameObject.FindWithTag("Minion3").SendMessage("DeactivateMinion");
                minionDead3.SendMessage("changeColorDead");
                tempactive = false;
                if (!permanent)
                {
                    gameObject.SetActive(false);
                }
                other.gameObject.tag = "Dead";

            } //These three perma-kill each minion when they touch it. Needed 1 for each minion because I don't know how to format it more efficiently

            
        }
    }
}