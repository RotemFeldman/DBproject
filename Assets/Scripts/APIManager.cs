using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class APIManager : MonoBehaviour
{    
    [SerializeField] UIManager uiManager;
    [SerializeField] LoadingScreenBehavior loadingScreenBehavior;

    const string API_URL = "https://localhost:7271/api/";


    public void GetPlayerName (string id) 
    {
        StartCoroutine(GetPlayerNameCor(id));
    }

    public void RequestPlayerCount()
    {
        StartCoroutine(GetPlayerCount());
    }

    IEnumerator GetPlayerCount()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Game/"))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    loadingScreenBehavior.UpdatePlayerCount(int.Parse(request.downloadHandler.text));
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    break;
            }
        }
    }

    IEnumerator GetPlayerNameCor(string id)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Player/" + id))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    uiManager.UpdatePlayerName(request.downloadHandler.text);
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    break;
            }
        }
    }

    public void GetQuestion(string id)
    {
        StartCoroutine(GetQuestionCor(id));
    }

    IEnumerator GetQuestionCor(string id)
    {
  

        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Questions/"+id))
        {
            yield return request.SendWebRequest();
            switch(request.result) 
            { 
                case UnityWebRequest.Result.Success:
                    string jsonQuestion = request.downloadHandler.text;
                    Question q = JsonUtility.FromJson<Question>(jsonQuestion);
                    uiManager.UpdateQuestionText(q.text);
                    uiManager.UpdateAnswers(q);
                    break;
            }
        }
    }
}
