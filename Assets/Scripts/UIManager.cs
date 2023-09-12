using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Managers")]
    public APIManager _APIManager;
    public GameManager _GameManager;

    [Header("Player")]
    public TMPro.TMP_InputField playerId;
    public TMPro.TMP_Text playerName;
    public TMPro.TMP_Text scoreText;

    [Header("Question")]
    public TMPro.TMP_InputField questionField;
    public TMPro.TMP_Text questionText;

    public TMP_Text answer1;
    public TMP_Text answer2;
    public TMP_Text answer3;
    public TMP_Text answer4;


    public void GetPlayerButtonClicked()
    {
        _APIManager.GetPlayerName(playerId.text);
    }

    public void GetQuestionButtonClicked()
    {
 
        _APIManager.GetQuestion(questionField.text);
    }


    public void UpdateQuestionText(string text)
    {
        questionText.text = text;
    }

    public void UpdatePlayerName(string name)
    {
        playerName.text = name;
    }

    public void UpdateAnswers(Question q)
    {
        _GameManager.UpdateCorrectAnswer(q.ans1);

        int rnd;

        List<string> answers = new List<string>();
        answers.Add(q.ans1);
        answers.Add(q.ans2);
        answers.Add(q.ans3);
        answers.Add(q.ans4);


        rnd = Random.Range(0, answers.Count -1);
        answer1.text = answers[rnd];
        answers.RemoveAt(rnd);

        rnd = Random.Range(0, answers.Count -1);
        answer2.text = answers[rnd];
        answers.RemoveAt(rnd);

        rnd = Random.Range(0, answers.Count -1);
        answer3.text = answers[rnd];
        answers.RemoveAt(rnd);

        rnd = 0;
        answer4.text = answers[rnd];
        answers.RemoveAt(rnd);


    }

    public void UpdateScore()
    {
        int s = _GameManager.score;

        scoreText.text = s.ToString();
    }
}
