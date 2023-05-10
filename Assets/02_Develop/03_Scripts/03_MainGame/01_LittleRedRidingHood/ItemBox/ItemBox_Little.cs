using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;
using NJsonLoader;
using UnityEngine.UI;

public class ItemBox_Little : MonoBehaviour, IUpdateManager
{
    [SerializeField]
    GameObject scenarioScreen;

    [SerializeField]
    Image item1, item2;

    [SerializeField]
    Fade fade;

    [SerializeField]
    FadeImage fadeImage;

    [SerializeField]
    ScenarioScreenLittle little;


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
}
