using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMinion : MonoBehaviour
{
    private bool Collided;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                gameObject.SendMessage("Activate");
                GameObject.Find("Player").SendMessage("DeactivateMovement");
                Collided = true;
            }
        }

    }
}
