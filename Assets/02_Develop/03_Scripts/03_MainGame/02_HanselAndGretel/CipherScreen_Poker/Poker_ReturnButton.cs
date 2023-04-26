using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;

public class Poker_ReturnButton : MonoBehaviour
{
    [SerializeField]
    PlayableDirector cipherReScreen_Poker;

    void Start()
    {
        //UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void ReturnButton()
    {
        cipherReScreen_Poker.enabled = false;
        cipherReScreen_Poker.enabled = true;
    }
}
