using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private APIManager apiManager;

    public int QuestionNumber = 0;

    public static string PlayerName = "";

    public static int Score = 0;

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
                apiManager.AddPlayerScore(PlayerName);

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
}
