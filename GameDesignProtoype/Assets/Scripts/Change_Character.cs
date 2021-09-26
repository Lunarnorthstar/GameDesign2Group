using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeCharacter1()
    {
        gameObject.SendMessage("DeactivateMovement");
        GameObject.Find("Player").SendMessage("ActivateMovement");
    }
    public void ChangeCharacter2()
    {
        gameObject.SendMessage("DeactivateMovement");
        GameObject.Find("Minion1").SendMessage("ActivateMovement");
    }
    public void ChangeCharacter3()
    {
        gameObject.SendMessage("DeactivateMovement");       
        GameObject.Find("Minion2").SendMessage("ActivateMovement");        
    }
    public void ChangeCharacter4()
    {
        gameObject.SendMessage("DeactivateMovement");        
        GameObject.Find("Minion3").SendMessage("ActivateMovement");        
    }
}
