using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class Scenarios : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    ScenarioManager scenariosManager;

    [SerializeField]
    GameObject ScenarioScreen;

    [SerializeField]
    AnchoredWindowMove anchoredWindow;

    [SerializeField]
    ImageTransparencyAnimation imageTransparency;
    
    bool check = true;

    int save;
    // Start is called before the first frame update
    void Start()
    {
        save = 0;
        UpdateManager.Instance.Bind(this,FrameControl.ON);   
    }

    // Update is called once per frame
    public void OnUpdate(double deltaTime)
    {
        if( save+1 == scenariosManager.CurrentLineNum)
        {
            if (MobileInput.InputState(TouchPhase.Began))
            {
                anchoredWindow.enabled = false;
                anchoredWindow.enabled = true;
                imageTransparency.enabled = false;
                imageTransparency.enabled = true;
            }
        }

        save = scenariosManager.CurrentLineNum;
   
        if (MobileInput.InputState(TouchPhase.Began) && check)
        {
            check = false;
            scenariosManager.PlayScenario(4, 21);
        }

        if(MobileInput.InputState(TouchPhase.Began) && !scenariosManager.LineEndCheck())
        {
               
        }
    }
}
