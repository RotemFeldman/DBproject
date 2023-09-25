using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;

    public int score;
    public string PlayerName;


    private string correctAnswer;


    public void UpdateCorrectAnswer(string text)
    {
        correctAnswer = text;
    }


    public bool IsAnswerCorrect(string text)
    {
        if (correctAnswer == text)
        {
            Debug.Log("Correct");
            score++;
            uiManager.UpdateScore();
            return true;
        }

        return false;
    }

    public void EnterPlayerName(string playerName)
    {
        PlayerName = playerName;
    }
}
