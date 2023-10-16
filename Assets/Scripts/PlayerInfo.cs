using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public TMPro.TMP_Text PlayerNameText;

    void Update()
    {
        PlayerNameText.text = GameManager.PlayerName;
    }
}
