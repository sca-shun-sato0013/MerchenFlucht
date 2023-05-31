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

    [SerializeField]
    GameObject cipherScreen_shelf;

    WaitForSeconds w;
    void Start() 
    {
        w = new WaitForSeconds(0.8f);
    }

    public void Shalf_ReturnButton()
    {
        cipherReScreen_shelf.enabled = false;
        cipherReScreen_shelf.enabled = true;
        StartCoroutine(ScreenCloseWait());
    }

    IEnumerator ScreenCloseWait()
    {
        yield return w;
        Debug.Log("’Ê‚Á‚½");
        cipherScreen_shelf.SetActive(false);
    }
}
    