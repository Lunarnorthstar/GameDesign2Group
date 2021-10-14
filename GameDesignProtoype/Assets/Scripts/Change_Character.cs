using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Character : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject minionCam1;
    public GameObject minionCam2;
    public GameObject minionCam3;
    public GameObject minionCall1;
    public GameObject minionCall2;
    public GameObject minionCall3;
    public bool canChangeTo1 = true;
    public bool canChangeTo2 = false;
    public bool canChangeTo3 = false;
    public bool canChangeTo4 = false;
    public GameObject playerTag;
    public GameObject minionTag1;
    public GameObject minionTag2;
    public GameObject minionTag3;

    void Start()
    {
        minionCall1 = GameObject.Find("Minion (1)").gameObject.transform.GetChild(0).gameObject;
        minionCall2 = GameObject.Find("Minion (2)").gameObject.transform.GetChild(0).gameObject;
        minionCall3 = GameObject.Find("Minion (3)").gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        
    }

    public void TurnChangeOn(int number)
    {
        switch(number)
        {
            case 1:
                canChangeTo1 = true;
                break;
            case 2:
                canChangeTo2 = true;
                break;
            case 3:
                canChangeTo3 = true;
                break;
            case 4:
                canChangeTo4 = true;
                break;
            default:
                break;


        }

    }
    public void TurnChangeOff(int number)
    {
        switch (number)
        {
            case 1:
                canChangeTo1 = false;
                break;
            case 2:
                canChangeTo2 = false;
                break;
            case 3:
                canChangeTo3 = false;
                break;
            case 4:
                canChangeTo4 = false;
                break;
            default:
                break;


        }

    }
    public void ChangeCharacter1()
    {
        if (canChangeTo1 == true)
        {
            gameObject.SendMessage("DeactivateMovement");
            GameObject.Find("Player").SendMessage("ActivateMovement");
            playerCam.SetActive(true);
            minionCam1.SetActive(false);
            minionCam2.SetActive(false);
            minionCam3.SetActive(false);
            minionCall1.SendMessage("changeColorOff");
            minionCall2.SendMessage("changeColorOff");
            minionCall3.SendMessage("changeColorOff");
            playerTag.SetActive(true);
            minionTag1.SetActive(false);
            minionTag2.SetActive(false);
            minionTag3.SetActive(false);
        }
    }
    public void ChangeCharacter2()
    {
        if (transform.CompareTag("Minion1"))
        {
            if (canChangeTo2 == true)
            {
                gameObject.SendMessage("DeactivateMovement");
                GameObject.Find("Player").SendMessage("DeactivateMovement");
                Debug.Log(minionCall1.name);
                GameObject.Find("Minion (1)").SendMessage("ActivateMovement");
                minionCall1.SendMessage("changeColorOn");
                minionCall2.SendMessage("changeColorOff");
                minionCall3.SendMessage("changeColorOff");
                playerCam.SetActive(false);
                minionCam1.SetActive(true);
                minionCam2.SetActive(false);
                minionCam3.SetActive(false);
                playerTag.SetActive(false);
                minionTag1.SetActive(true);
                minionTag2.SetActive(false);
                minionTag3.SetActive(false);
            }
        }
    }
    public void ChangeCharacter3()
    {

        if (transform.CompareTag("Minion2"))
        {
            if (canChangeTo3 == true)
            {
                GameObject.Find("Player").SendMessage("DeactivateMovement");
                gameObject.SendMessage("DeactivateMovement");
                GameObject.Find("Minion (2)").SendMessage("ActivateMovement");
                playerCam.SetActive(false);
                minionCam1.SetActive(false);
                minionCam2.SetActive(true);
                minionCam3.SetActive(false);
                GameObject.Find("Minion (1)").gameObject.transform.GetChild(0).gameObject.SendMessage("changeColorOff", gameObject.name);
                minionCall1.SendMessage("changeColorOff");
                minionCall2.SendMessage("changeColorOn");
                minionCall3.SendMessage("changeColorOff");
                playerTag.SetActive(false);
                minionTag1.SetActive(false);
                minionTag2.SetActive(true);
                minionTag3.SetActive(false);
            }
        }
    }
    public void ChangeCharacter4()
    {

        if (transform.CompareTag("Minion3"))
        {
            if (canChangeTo4 == true)
            {
                GameObject.Find("Player").SendMessage("DeactivateMovement");
                gameObject.SendMessage("DeactivateMovement");
                GameObject.Find("Minion (3)").SendMessage("ActivateMovement");
                playerCam.SetActive(false);
                minionCam1.SetActive(false);
                minionCam2.SetActive(false);
                minionCam3.SetActive(true);
                GameObject.Find("Minion (1)").gameObject.transform.GetChild(0).gameObject.SendMessage("changeColorOff", gameObject.name);
                minionCall1.SendMessage("changeColorOff");
                minionCall2.SendMessage("changeColorOff");
                minionCall3.SendMessage("changeColorOn");
                playerTag.SetActive(false);
                minionTag1.SetActive(false);
                minionTag2.SetActive(false);
                minionTag3.SetActive(true);
            }
        }
    }
}
