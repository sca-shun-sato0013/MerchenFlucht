using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class ScenarioScreen : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    ScenarioManager scenariosManager;

    [SerializeField]
    AnchoredWindowMove charaMove;

    [SerializeField]
    ImageTransparencyAnimation charaAnimation;

    [SerializeField]
    Fade fade;

    [SerializeField]
    GameObject mainScreen;

    [SerializeField, Header("フェードインの時間")]
    float timer;

    bool check = true;

    int save;


    private void OnEnable()
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    private void OnDisable()
    {
        UpdateManager.Instance.UnBind(this, FrameControl.ON);
    }

    // Start is called before the first frame update
    void Start()
    {
        mainScreen.SetActive(false);
        save = 0;
    }

    // Update is called once per frame
    public void OnUpdate(double deltaTime)
    {
        if( save+1 == scenariosManager.CurrentLineNum)
        {
            if (MobileInput.InputState(TouchPhase.Began))
            {
                charaMove.enabled = false;
                charaMove.enabled = true;
                charaAnimation.enabled = false;
                charaAnimation.enabled = true;
            }
        }

        save = scenariosManager.CurrentLineNum;
   
        if (MobileInput.InputState(TouchPhase.Began) && check)
        {
            check = false;
            scenariosManager.PlayScenario(4, 21);
        }
//        MobileInput.InputState(TouchPhase.Began) && !scenariosManager.LineEndCheck()
        if (MobileInput.InputState(TouchPhase.Began) && !scenariosManager.LineEndCheck())
        {
            fade.FadeIn(timer,() => mainScreen.SetActive(true));
            this.gameObject.SetActive(false);
        }
    }
}
