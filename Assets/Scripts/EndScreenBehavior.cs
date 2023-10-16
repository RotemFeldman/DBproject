using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenBehavior : MonoBehaviour
{
    public APIManager apiManager;
    public TMPro.TMP_Text AwaitingFinishText;

    public int playerStatusSum = 0;

    public string winnerName = "";

    private float timer;

    private void Start()
    {
        apiManager.TotalStatusSum();
        apiManager.GetGameWinner();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.5)
        {
            apiManager.TotalStatusSum();
            apiManager.GetGameWinner();

            timer = 0;
        }

        if (playerStatusSum == 2)
        {
            AwaitingFinishText.text = $"Winner: {winnerName}";
        } 
        else
        {
            AwaitingFinishText.text = "Awaiting all players..";
        }
    }
}
