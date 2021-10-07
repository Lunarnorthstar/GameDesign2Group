using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
   
    private Vector3 startPos;
    private int score;
    private int Redcount;
    private int Bluecount;
    private int Yellowcount;

    private void Start()
    {
        startPos = player.transform.position;
        
        
        PauseGame();

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    public void RespawnPlayer()
    {
        player.transform.position = startPos;
        
        
    }

    public void AddScore()
    {

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

}