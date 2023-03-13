using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using NJsonLoader;

public class reset : MonoBehaviour
{

    ScenarioState scenarioState;

    void Start()
    {
        scenarioState = new ScenarioState();
    }

    /*    public void OnUpdate(double deltaTime)
        {
            if (!this.gameObject.activeInHierarchy) return;

        }
    */
    public void OnClick()
    {
        scenarioState.scenarioScenePeter = ScenarioScenePeter.introduction;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        Debug.Log("êMÇ∂ÇÈ");
    }
}
    