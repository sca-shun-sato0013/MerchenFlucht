using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using NJsonLoader;

public class GameOver : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    Timer countDowntimer;
    [SerializeField]
    ScenarioState scenarioState;
    [SerializeField]
    Fade fade;
    [SerializeField]
    FadeImage fadeImage;
    [SerializeField]
    GameObject scenarioScreen;
    [SerializeField]
    ScenarioScreenPeterPan peterPan;

    bool gameOver = false;

    bool justOnce = true;
    public bool GameEnd => gameOver;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if(countDowntimer.TimeOut && justOnce)
        {
            justOnce = false;

            fade.FadeIn(1f);
            scenarioState.scenarioScenePeter = ScenarioScenePeter.ifTimeRunsOut;
            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
            StartCoroutine(Change_MainScreen());
           
            gameOver = true; 
        }
    }

     IEnumerator Change_MainScreen()
    {
        Debug.Log("フェードイン" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        scenarioScreen.SetActive(true);
        peterPan.enabled = true;
    }
}
    