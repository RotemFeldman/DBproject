using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    
    public TMPro.TMP_Text answer;

    public GameManager gameManager;


    public void AnswerButtonClicked()
    {
        gameManager.IsAnswerCorrect(answer.text);
    }

}
