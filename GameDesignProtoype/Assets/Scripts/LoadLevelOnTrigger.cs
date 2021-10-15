using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevelOnTrigger : MonoBehaviour //This script loads a given level when a trigger is entered. Goes on the trigger object. Dependencies; None.
{
    [SerializeField] private int nextScene; //Keep track of the scene index of the "next" scene.
    private void OnTriggerEnter2D(Collider2D other) //When something bumps into you...
    {
        if (other.gameObject.tag == "Player") //If it's the player...
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the next scene in the build index.
        }
    }

    private void OnCollisionEnter2D(Collision2D other) //I'm honestly not sure why this is here. Maybe so it can be used to reset the current scene as well?
    {
        ReloadLevel();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reload the current scene.
    }
}