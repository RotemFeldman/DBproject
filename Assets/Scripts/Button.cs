using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    
    public TMPro.TMP_Text answer;
    public TMPro.TMP_InputField nameInputField;

    public GameManager gameManager;


    public void AnswerButtonClicked()
    {
        gameManager.IsAnswerCorrect(answer.text);
    }

    public void EnterNameClicked()
    {
        if (nameInputField != null)
        {
            gameManager.EnterPlayerName(nameInputField.text);
            SceneManager.LoadScene("Loading");
        }
    }

}
