using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private UnityEvent<string> CountRed;
    [SerializeField] private UnityEvent<string> CountBlue;
    [SerializeField] private UnityEvent<string> CountYellow;
    [SerializeField] private UnityEvent<string> PowerUpRed;
    private Vector3 startPos;
    private int score;
    private int Redcount;
    private int Bluecount;
    private int Yellowcount;

    private void Start()
    {
        startPos = player.transform.position;
        score = 0;
        UpdateUI();
        //PauseGame();

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    public void RespawnPlayer()
    {
        player.transform.position = startPos;
        score = 0;
        UpdateUI();
    }

    public void AddScore(int scoreAmt)
    {
        score += scoreAmt;
        UpdateUI();
    }

    public void CountUpRed(int countAmtR)
    {
        Redcount = countAmtR ;
        UpdateUI();
    }
    public void CountUpBlue(int countAmtB)
    {
        Bluecount = countAmtB ;
        UpdateUI();
    }
    public void CountUpYellow(int countAmtY)
    {
        Yellowcount = countAmtY ;
        UpdateUI();
    }
    public void PowerupRed()
    {
        Redcount ++;
        UpdateUI();
    }


    private void UpdateUI()
    {
        CountRed.Invoke(Redcount.ToString());
        CountBlue.Invoke(Bluecount.ToString());
        CountYellow.Invoke(Yellowcount.ToString());
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