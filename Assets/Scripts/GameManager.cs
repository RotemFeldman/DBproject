using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private APIManager apiManager;

    public int score;
    public string PlayerName;


    private string correctAnswer;

    [HideInInspector]
    public bool wasQuestionAnswered = false;


    private void Start()
    {
        uiManager = GetComponent<UIManager>();
        apiManager = GetComponent<APIManager>();

        ///Loads the first question
        apiManager.GetNextQuestion();
    }

    public void UpdateCorrectAnswer(string text)
    {
        correctAnswer = text;
    }


    public void IsAnswerCorrect(string text)
    {
        if (!wasQuestionAnswered)
        {
            wasQuestionAnswered = true;

            if (correctAnswer == text)
            {
                Debug.Log("Correct");
                score++;
                uiManager.UpdateScore();
                uiManager.questionText.text = "Correct!";
                uiManager.questionText.color = Color.green;
            }
            else
            {
                uiManager.questionText.text = "Incorrect!";
                uiManager.questionText.color = Color.red;
            }

            uiManager.NextQuestionButton.gameObject.SetActive(true);
        }
    }

    public void EnterPlayerName(string playerName)
    {
        PlayerName = playerName;
    }
}
