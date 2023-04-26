using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;


public class CipherScreen_Door : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    GameObject[] candles_Array;

    [SerializeField]
    GameObject kitchenMoveButton;
    [SerializeField]
    BoxCollider doorToKitchen;
    [SerializeField]
    PlayableDirector CipherScreenReDoor, Door_Open_TimeLine;

    bool flag = true;

    private void OnEnable()
    {
        doorToKitchen.enabled = false;
    }
    private void OnDisable()
    {
        doorToKitchen.enabled = true;
    }
    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;


        if(candles_Array[1].activeSelf == true 
          && candles_Array[3].activeSelf == true
          && candles_Array[5].activeSelf == false
          && candles_Array[7].activeSelf == false
          && candles_Array[9].activeSelf == true
          && candles_Array[11].activeSelf == false
          && flag)
        {
            flag = false;

            CipherScreenReDoor.enabled = false;
            CipherScreenReDoor.enabled = true;

            StartCoroutine(Door_Open());
        }
   
    }

    IEnumerator Door_Open()
    {
        yield return new WaitForSeconds(1.2f);

        Door_Open_TimeLine.enabled = true;

        yield return new WaitForSeconds(1.0f);

        doorToKitchen.enabled = false;
        kitchenMoveButton.SetActive(true);
    }
    public void Candle1()
    {
        candles_Array[0].SetActive(false);
        candles_Array[1].SetActive(true);
    }

    public void Candle1Fire()
    {
        candles_Array[1].SetActive(false);
        candles_Array[0].SetActive(true);
    }

    public void Candle2()
    {
        candles_Array[2].SetActive(false);
        candles_Array[3].SetActive(true);
    }

    public void Candle2Fire()
    {
        candles_Array[3].SetActive(false);
        candles_Array[2].SetActive(true);
    }

    public void Candle3()
    {
        candles_Array[4].SetActive(false);
        candles_Array[5].SetActive(true);
    }

    public void Candle3Fire()
    {
        candles_Array[5].SetActive(false);
        candles_Array[4].SetActive(true);
    }

    public void Candle4()
    {
        candles_Array[6].SetActive(false);
        candles_Array[7].SetActive(true);
    }

    public void Candle4Fire()
    {
        candles_Array[7].SetActive(false);
        candles_Array[6].SetActive(true);
    }

    public void Candle5()
    {
        candles_Array[8].SetActive(false);
        candles_Array[9].SetActive(true);
    }

    public void Candle5Fire()
    {
        candles_Array[9].SetActive(false);
        candles_Array[8].SetActive(true);
    }

    public void Candle6()
    {
        candles_Array[10].SetActive(false);
        candles_Array[11].SetActive(true);
    }

    public void Candle6Fire()
    {
        candles_Array[11].SetActive(false);
        candles_Array[10].SetActive(true);
    }

    public void ReturnButton()
    {
        for(int i = 0; i < candles_Array.Length; i++)
        {
            candles_Array [i].SetActive(false);
        }

        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);

        gameObject.SetActive(false);

    }
}
    