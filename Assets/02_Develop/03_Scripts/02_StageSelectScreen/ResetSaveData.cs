using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using NJsonLoader;

public class ResetSaveData : MonoBehaviour
{

    ScenarioState scenarioState;

    void Start()
    {
        scenarioState = new ScenarioState();
        scenarioState.scenarioScenePeter = ScenarioScenePeter.introduction;
        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.introduction;
        scenarioState.scenarioSceneLittle = ScenarioSceneLittle.introduction;

        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
    }
}
    