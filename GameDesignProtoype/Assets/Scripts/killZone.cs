using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").SendMessage("gotoCP");
        }
        
        if (other.gameObject.CompareTag("Minion1"))
        {
            GameObject.FindWithTag("Minion1").SendMessage("DeactivateMinion");
        }
        
        if (other.gameObject.CompareTag("Minion2"))
        {
            GameObject.FindWithTag("Minion2").SendMessage("DeactivateMinion");
        }
        
        if (other.gameObject.CompareTag("Minion3"))
        {
            GameObject.FindWithTag("Minion3").SendMessage("DeactivateMinion");
        } //These three perma-kill each minion when they touch it. Needed 1 for each minion because I don't know how to format it more efficiently
    }
}