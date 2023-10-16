using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    
    public TMPro.TMP_Text answer;

    public GameManager gameManager;


    public void AnswerButtonClicked()
    {
        gameManager.IsAnswerCorrect(answer.text);
    }
}
