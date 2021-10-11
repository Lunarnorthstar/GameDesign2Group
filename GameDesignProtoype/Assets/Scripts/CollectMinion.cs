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
                
                gameObject.SendMessage("ActivateMinion");
                
                GameObject.Find("Player").SendMessage("DeactivateMovement");
                
                Collided = true;
            }
        }

    }
}
