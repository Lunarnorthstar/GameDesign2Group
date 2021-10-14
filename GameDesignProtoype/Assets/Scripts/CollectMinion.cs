using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMinion : MonoBehaviour
{
    private bool Collided;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Collided == true)
            {

            }
            else
            {
                GameObject.Find("Minion (1)").SendMessage("TurnChangeOff", 2);
                GameObject.Find("Minion (2)").SendMessage("TurnChangeOff", 3);
                GameObject.Find("Minion (3)").SendMessage("TurnChangeOff", 4);
                gameObject.SendMessage("ActivateMinion");
                
                GameObject.Find("Player").SendMessage("DeactivateMovement");
                
                Collided = true;
                gameObject.GetComponent<AudioSource>().volume = 1.0f;
            }
        }

    }
}
