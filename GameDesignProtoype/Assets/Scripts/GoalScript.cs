using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public GameObject player;
    public GameObject gameEndCanvas;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Player_Movement>().enabled = false;
            gameEndCanvas.SetActive(true);
        }
    }
}
