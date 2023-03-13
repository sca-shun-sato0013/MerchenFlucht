using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using NJsonLoader;
using UnityEngine.UI;
using UnityEngine.Playables;

public class ClickScenario : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    ScenarioScreenPeterPan peterPan;
    [SerializeField]
    GameObject scenarioScreen;
    [SerializeField, Header("妖精")]
    GameObject fairy;
    [SerializeField, Header("ボタンからの読むかどうか")]
    GameObject buttonMenuItem2, buttonMenuItem3, buttonMenuItem4, buttonMenuItem6;
    [SerializeField, Header("ボタンのタイムライン")]
    PlayableDirector buttonMenu_TimeLine,buttonReMenu_TimeLine;
    [SerializeField]
    Image item2,item3,item4,item6;
    [SerializeField, Header("ButtonMenuの画像変更")]
    Image item5;
    [SerializeField]
    Fade fade;
    [SerializeField]
    FadeImage fadeImage;
    [SerializeField]
    ImageLoadings imageLoadings;

    ScenarioState scenarioState;

    bool devilBook = false, diary = false;

    public bool DevilBookFlag => devilBook;
    public bool DiaryFlag => diary;
    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);

        scenarioState = new ScenarioState();
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;


    }

    public void Play_TimeLineItem2()
    {
        if (item2.sprite.name == "メモ5(Clone)")
        {
            buttonMenuItem3.SetActive(false);
            buttonMenuItem4.SetActive(false);
            buttonMenuItem6.SetActive(false);
            buttonMenuItem2.SetActive(true);

            buttonMenu_TimeLine.enabled = false;
            buttonMenu_TimeLine.enabled = true;
        }
    }

    public void Play_TimeLineItem3()
    {
        if (item3.sprite.name == "悪魔の本(閉)(Clone)")
        {
            buttonMenuItem2.SetActive(false);
            buttonMenuItem4.SetActive(false);
            buttonMenuItem6.SetActive(false);
            buttonMenuItem3.SetActive(true);

            buttonMenu_TimeLine.enabled = false;
            buttonMenu_TimeLine.enabled = true;
        }
    }

    public void Play_TimeLineItem4()
    {
        if (item4.sprite.name == "絵本(閉)(Clone)")
        {
            buttonMenuItem2.SetActive(false);
            buttonMenuItem3.SetActive(false);
            buttonMenuItem6.SetActive(false);
            buttonMenuItem4.SetActive(true);

            buttonMenu_TimeLine.enabled = false;
            buttonMenu_TimeLine.enabled = true;
        }
    }

    public void Play_TimeLineItem6()
    {
        if (item6.sprite.name == "ピーター日記(閉)(Clone)")
        {
            buttonMenuItem2.SetActive(false);
            buttonMenuItem3.SetActive(false);
            buttonMenuItem4.SetActive(false);
            buttonMenuItem6.SetActive(true);

            buttonMenu_TimeLine.enabled = false;
            buttonMenu_TimeLine.enabled = true;
        }
    }

    public void Return_ButtonMenu()
    {
        buttonReMenu_TimeLine.enabled = false;
        buttonReMenu_TimeLine.enabled = true;

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);

        buttonMenuItem2.SetActive(false);
        buttonMenuItem3.SetActive(false);
        buttonMenuItem4.SetActive(false);
        buttonMenuItem6.SetActive(false);

    }
    public void OnItem2Click()
    {      
          fade.FadeIn(2f);
     
          scenarioState.scenarioScenePeter = ScenarioScenePeter.examineMemo2;
          ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
          StartCoroutine(Change_MainScreen());       
    }

    public void OnItem3Click()
    {
        fade.FadeIn(2f);

        scenarioState.scenarioScenePeter = ScenarioScenePeter.DevilsBookFromTheItem;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        devilBook = true;
        StartCoroutine(Change_MainScreen());
        fairy.SetActive(true);
    }

    public void OnItem4Click()
    {
        fade.FadeIn(2f);

        imageLoadings.AddList(item5,"Assets/LoadingDatas/ScenarioDatas/PeterPan/絵本に挟まってる鍵.png");
        imageLoadings.enabled = false;
        imageLoadings.enabled = true;
        scenarioState.scenarioScenePeter = ScenarioScenePeter.fairyTaleFromTheiItem;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        
        StartCoroutine(Change_MainScreen());
    }

    public void OnItem6Click()
    {
        fade.FadeIn(2f);

        scenarioState.scenarioScenePeter = ScenarioScenePeter.diaryFromTheItem;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        diary = true;
        StartCoroutine(Change_MainScreen());
    }

    IEnumerator Change_MainScreen()
    {
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        scenarioScreen.SetActive(true);
        peterPan.enabled = true;
    }
}

