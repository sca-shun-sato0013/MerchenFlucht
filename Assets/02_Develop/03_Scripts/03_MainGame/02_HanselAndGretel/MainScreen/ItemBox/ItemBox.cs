using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;
using NJsonLoader;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    GameObject scenarioScreen,diaryScreen;

    [SerializeField]
    Image item1,item2;

    [SerializeField]
    Fade fade;

    [SerializeField]
    FadeImage fadeImage;

    [SerializeField]
    ScenarioScreenHansel hansel;

    [SerializeField]
    PlayableDirector open_Item1,close_Item1;

    ScenarioState scenarioState;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);

        scenarioState = new ScenarioState();
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

    }

    public void OnClickItem1()
    {
        if(item1.sprite.name == "H&G日記(閉)(Clone)")
        {
            diaryScreen.SetActive(true);
            open_Item1.enabled = false;
            open_Item1.enabled = true;
        }
    }

    public void OnClickItem2()
    {
        if(item2.sprite.name == "H&G写真(Clone)")
        {
            fade.FadeIn(2f);

            scenarioState.scenarioSceneHansel = ScenarioSceneHansel.examineThePhoto;
            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
            StartCoroutine(Change_MainScreen());
        }
    }

    public void OnClickReadBook()
    {
        fade.FadeIn(2f);

        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.examineTheDiary;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen());
    }

    public void ReturnButton()
    {
        close_Item1.enabled = false;
        close_Item1.enabled = true;
    }

    private IEnumerator Change_MainScreen()
    {
        Debug.Log("フェードイン" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        scenarioScreen.SetActive(true);
        hansel.enabled = true;
    }
}
    