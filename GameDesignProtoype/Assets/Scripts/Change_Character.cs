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

    void Start()
    {
        minionCall1 = GameObject.Find("Minion (1)").gameObject.transform.GetChild(0).gameObject;
        minionCall2 = GameObject.Find("Minion (2)").gameObject.transform.GetChild(0).gameObject;
        minionCall3 = GameObject.Find("Minion (3)").gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        
    }


    public void ChangeCharacter1()
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
    }
    public void ChangeCharacter2()
    {
        gameObject.SendMessage("DeactivateMovement");
        Debug.Log(minionCall1.name);
        GameObject.Find("Minion (1)").SendMessage("ActivateMovement");
        minionCall1.SendMessage("changeColorOn");
        minionCall2.SendMessage("changeColorOff");
        minionCall3.SendMessage("changeColorOff");
        playerCam.SetActive(false);
        minionCam1.SetActive(true);
        minionCam2.SetActive(false);
        minionCam3.SetActive(false);
        
    }
    public void ChangeCharacter3()
    {
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
    }
    public void ChangeCharacter4()
    {
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
    }
}
