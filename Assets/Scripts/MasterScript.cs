using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MasterScript : MonoBehaviour
{
    static public bool gameEnded;
    private int player1Score;
    private int player2Score;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text winText;

    private void Start()
    {
        player1Score = 0;
        player2Score = 0;
        gameEnded = false;
        winText.text = "";
    }

    public void AddScore(bool p1)
    {
        if(p1)
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
        }
        else
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
        }

        if(player1Score >= Settings.rounds)
        {
            gameEnded = true;
            winText.text = "Player 1 won";
        }
        else if(player2Score >= Settings.rounds)
        {
            gameEnded = true;
            winText.text = "Player 2 won";
        }
        if (gameEnded) StartCoroutine(LoadMenuDelay());
    }

    private IEnumerator LoadMenuDelay()
    {
        yield return new WaitForSeconds(3.0f);
        winText.text = "";
        SceneManager.LoadScene(0);
    }


    public void Update()
    {

    }
}
