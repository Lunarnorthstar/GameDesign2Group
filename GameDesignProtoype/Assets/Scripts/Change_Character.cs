using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Character : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject minionCam1;
    public GameObject minionCam2;
    public GameObject minionCam3;

    void Start()
    {
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
    }
    public void ChangeCharacter2()
    {
        gameObject.SendMessage("DeactivateMovement");
        GameObject.Find("Minion (1)").SendMessage("ActivateMovement");
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
    }
    public void ChangeCharacter4()
    {
        gameObject.SendMessage("DeactivateMovement");        
        GameObject.Find("Minion (3)").SendMessage("ActivateMovement");
        playerCam.SetActive(false);
        minionCam1.SetActive(false);
        minionCam2.SetActive(false);
        minionCam3.SetActive(true);
    }
}
