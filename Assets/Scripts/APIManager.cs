using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using TMPro;

public class APIManager : MonoBehaviour
{    
    [SerializeField] UIManager uiManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] LoadingScreenBehavior loadingScreenBehavior;
    [SerializeField] EndScreenBehavior endScreenBehavior;

    const string API_URL = "https://localhost:7271/api/";

    public void RequestPlayerCount()
    {
        StartCoroutine(GetPlayerCount());
    }

    public void AddNewPlayer(string name)
    {
        StartCoroutine(AddPlayer(name));
    }

    public void PlayerStatus(string name)
    {
        StartCoroutine(GetPlayerStatus(name));
    }

    public void TotalStatusSum()
    {
        StartCoroutine(GetStatusSum());
    }

    public void GetPlayerScore(string name)
    {
        StartCoroutine(GetScore(name));
    }

    public void AddPlayerScore(string name)
    {
        StartCoroutine(AddScore(name));
    }

    public void GetGameWinner()
    {
        StartCoroutine(GetWinner());
    }

    IEnumerator GetPlayerStatus(string name)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Player/" + "GetStatus/" + name))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    yield return int.Parse(request.downloadHandler.text);
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("ERRORED CONN");
                    break;
            }
        }
    }

    IEnumerator SetPlayerStatus(string name)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Player/" + "SetStatus/" + name))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("ERRORED CONN");
                    break;
            }
        }
    }

    IEnumerator PlayerFinished()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Player/" + "Status/" + name))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    yield return int.Parse(request.downloadHandler.text);
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("ERRORED CONN");
                    break;
            }
        }
    }

    IEnumerator GetWinner()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Game/" + "Winner"))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    endScreenBehavior.winnerName = request.downloadHandler.text;
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("ERRORED CONN");
                    break;
            }
        }
    }

    IEnumerator GetStatusSum()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Game/" + "Statuses"))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    endScreenBehavior.playerStatusSum = int.Parse(request.downloadHandler.text);
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("ERRORED CONN");
                    break;
            }
        }
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
                    Debug.Log("ERRORED CONN");
                    break;
            }
        }
    }

    IEnumerator AddPlayer(string name)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Player/" + "AddPlayer/" + name))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    GameManager.PlayerName = name;
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("ERRORED CONN");
                    break;
            }
        }
    }

    IEnumerator GetScore(string name)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Player/" + "GetScore/" + name))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    GameManager.Score = int.Parse(request.downloadHandler.text);
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("ERRORED CONN");
                    break;
            }
        }
    }

    IEnumerator AddScore(string name)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(API_URL + "Player/" + "AddScore/" + name))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.Success:
                    GameManager.PlayerName = name;
                    GetPlayerScore(name);
                    break;
                case UnityWebRequest.Result.ConnectionError:
                    Debug.Log("ERRORED CONN");
                    break;
            }
        }
    }

    public void GetQuestion(string id)
    {
        StartCoroutine(GetQuestionCor(id));
    }

    public void GetNextQuestion()
    {
        if (gameManager.QuestionNumber == 10)
        {
            StartCoroutine(SetPlayerStatus(GameManager.PlayerName));
            SceneManager.LoadScene(2);
            return;
        }

        gameManager.QuestionNumber++;
        GetQuestion(gameManager.QuestionNumber.ToString());
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
