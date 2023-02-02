using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class Scenario : MonoBehaviour, IUpdateManager
{
    [SerializeField]
    ScenarioManager scenarioManager;

    bool check = true;

    void Start()
    {        
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            scenarioManager.PlayScenario(4, 21);
        }
    }
}
