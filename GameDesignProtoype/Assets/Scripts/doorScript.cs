using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This goes on the BUTTON, not the DOOR
public class doorScript : MonoBehaviour
{
    public Boolean IsToggleDoor = false;
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Minion1")) //If the player bumps into you...
        {
            door.SetActive(false); //Make door go away
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsToggleDoor == true) //If a box in the editor is checked...
        {
            door.SetActive(true); //Come back when they stop bumping you
        }
    }
}