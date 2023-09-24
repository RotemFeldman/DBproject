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

    void Update()
    {    
        if (_playerCount < 2)
        {
            apiManager.RequestPlayerCount();
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
    }
}
