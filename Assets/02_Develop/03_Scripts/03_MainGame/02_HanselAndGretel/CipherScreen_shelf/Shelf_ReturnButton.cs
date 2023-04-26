using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;

public class Shelf_ReturnButton : MonoBehaviour
{
    [SerializeField]
    PlayableDirector cipherReScreen_shelf;

    void Start() 
    {
        //UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void Shalf_ReturnButton()
    {
        cipherReScreen_shelf.enabled = false;
        cipherReScreen_shelf.enabled = true;
    }
}
    