using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenBehavior : MonoBehaviour
{
    [SerializeField] APIManager apiManager;
    [SerializeField] TMP_Text text;

    private int _playerCount = 0;

    private bool _gameRunning = false;

    private float timer = 0;

    private bool PlayerAdded = false;

    private void Start()
    {
        apiManager.RequestPlayerCount();
    }

    private void AddPlayerData(string name)
    {
        PlayerAdded = true;
        apiManager.AddNewPlayer($"Player{_playerCount}");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            if (_playerCount < 2)
            {
                apiManager.RequestPlayerCount();
            }

            timer = 0;
        }

        if (_playerCount >= 2 && _gameRunning == false)
        {
            _gameRunning = true;
            SceneManager.LoadScene(1);
        }
    }

    public void UpdatePlayerCount(int count)
    {
        _playerCount = count;
        text.text = $"Waiting for players ... {_playerCount}/2";

        if (!PlayerAdded)
        {
            AddPlayerData($"Player{count}");
        }
        else
            return;
    }
}
