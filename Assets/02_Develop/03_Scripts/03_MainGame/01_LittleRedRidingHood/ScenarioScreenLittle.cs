using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using DesignPattern;
using NJsonLoader;
using UnityEngine.Rendering;

public enum ScenarioSceneLittle
{
    introduction,

    frontDoor,

    window,

    basket,

    kichenShelf,

    pot,

    grandMatherDiary,

    grandMatherDiary_Loading,

    familyPhptoGet,

    familyPhpto_Load,

    underFloorStorage_Sucess,

    woodenBoxScreen_Sucess,

    wolf_Normal,

    sleepingPills_Get,

    lockdKey_shelf,

    sleepingPillsTea,

    kitchenKnife,
}
public class ScenarioScreenLittle : MonoBehaviour, IUpdateManager
{
    [SerializeField]
    InputType inputType;
    [SerializeField]
    ScenarioManager scenariosManager;

    [SerializeField]
    AnchoredWindowMove charaMove;

    [SerializeField]
    ImageTransparencyAnimation charaAnimation, backGround;

    [SerializeField]
    Fade fade;

    [SerializeField]
    FadeImage fadeImage;

    [SerializeField]
    GameObject mainScreen;

    [SerializeField]
    SetDisplayImage setDisplayImage;

    [SerializeField]
    Volume volume;

    [SerializeField]
    GameOver_Little gameOver;

    [SerializeField, Header("フェードインの時間")]
    float timer;
    [SerializeField, Header("シナリオの場面")]
    ScenarioSceneLittle scenarioScene;

    ScenarioState scenarioState;

    bool justOnce = true;
    bool justOnce2 = true;

    public ScenarioSceneLittle ScenarioPattarn
    {
        get { return scenarioScene; }
        set { scenarioScene = value; }
    }

    bool check = true;
    bool flag = false;
    int save;

    string imageSave;
    string pastImage;

    private void OnEnable()
    {
        justOnce = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
        mainScreen.SetActive(false);
        save = 0;
        imageSave = "";
        pastImage = "";
    }

    // Update is called once per frame
    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        switch (inputType)
        {
            case InputType.MobileInput:
                OnClickCharaMove(MobileInput.InputState(TouchPhase.Began));
                OnClickBackGroundTransition(MobileInput.InputState(TouchPhase.Began));
                OnClickText(MobileInput.InputState(TouchPhase.Began));
                break;
            case InputType.InputPC:
                OnClickCharaMove(Input.GetMouseButtonDown(0));
                OnClickBackGroundTransition(Input.GetMouseButtonDown(0));
                OnClickText(Input.GetMouseButtonDown(0));
                break;
        }

        if (justOnce)
        {
            justOnce = false;

            StartCoroutine(FadeWait());
            mainScreen.SetActive(false);
            volume.enabled = false;
            SoundManager.Instance.PlayBGM(1, true);
            SoundManager.Instance.FadeOut_BGM(1f);

            scenarioState = new ScenarioState();
            scenarioState = ServiceLocator<IJsonLoader>.Instance.LoadStatusData<ScenarioState>("ScenarioState");

            scenarioScene = scenarioState.scenarioSceneLittle;

            switch (scenarioScene)
            {

                case ScenarioSceneLittle.introduction:

                    scenariosManager.PlayScenario(5,15);

                    break;

                case ScenarioSceneLittle.frontDoor:

                    scenariosManager.PlayScenario(22,23);

                    break;

                case ScenarioSceneLittle.window:

                    scenariosManager.PlayScenario(27,27);

                    break;

                case ScenarioSceneLittle.basket:

                    scenariosManager.PlayScenario(31,31);

                    break;

                case ScenarioSceneLittle.kichenShelf:

                    scenariosManager.PlayScenario(39,39);

                    break;

                case ScenarioSceneLittle.pot:

                    scenariosManager.PlayScenario(43,43);

                    break;

                case ScenarioSceneLittle.grandMatherDiary:

                    scenariosManager.PlayScenario(62,62);

                    break;

                case ScenarioSceneLittle.grandMatherDiary_Loading:

                    scenariosManager.PlayScenario(69,81);

                    break;

                case ScenarioSceneLittle.familyPhptoGet:

                    scenariosManager.PlayScenario(102,105);

                    break;

                case ScenarioSceneLittle.familyPhpto_Load:

                    scenariosManager.PlayScenario(109,110);

                    break;

                case ScenarioSceneLittle.underFloorStorage_Sucess:

                    scenariosManager.PlayScenario(122,126);

                    break;
                
                case ScenarioSceneLittle.woodenBoxScreen_Sucess:

                    scenariosManager.PlayScenario(136,138);

                    break;

                case ScenarioSceneLittle.wolf_Normal:

                    scenariosManager.PlayScenario(145,146);

                    break;

                case ScenarioSceneLittle.sleepingPills_Get:

                    scenariosManager.PlayScenario(98,98);

                    break;

                case ScenarioSceneLittle.lockdKey_shelf:

                    scenariosManager.PlayScenario(87,87);

                    break;

                case ScenarioSceneLittle.sleepingPillsTea:

                    scenariosManager.PlayScenario(46,48);

                    break;

                case ScenarioSceneLittle.kitchenKnife:

                    scenariosManager.PlayScenario(33,34);

                    break;
            }
        }
    }

    private void OnClickCharaMove(bool input)
    {
        if (save + 1 == scenariosManager.CurrentLineNum)
        {
            if (input)
            {
                charaMove.enabled = false;
                charaMove.enabled = true;
                charaAnimation.enabled = false;
                charaAnimation.enabled = true;
            }
        }

        save = scenariosManager.CurrentLineNum;
    }

    private void OnClickBackGroundTransition(bool input)
    {
        imageSave = setDisplayImage.ImageDatas[0];

        if (input || flag)
        {
            flag = true;

            if (imageSave != "" && pastImage != "")
            {
                if (imageSave != pastImage)
                {
                    flag = false;
                    backGround.enabled = false;
                    backGround.enabled = true;
                }
            }

        }

        pastImage = setDisplayImage.ImageDatas[0];
    }

    private void OnClickText(bool input)
    {

        if (input && !scenariosManager.LineEndCheck())
        {
            if (gameOver.GameEnd && justOnce2)
            {
                justOnce2 = false;
                SceneManager.Instance.SceneLoadingAsync("title");
            }
            else if (scenarioState.happyEndHansel && justOnce2)
            {
                justOnce2 = false;
                SceneManager.Instance.SceneLoadingAsync("title");
            }
            else if (scenarioState.trueEndHansel && justOnce2)
            {
                justOnce2 = false;
                SceneManager.Instance.SceneLoadingAsync("EndRollScreen_Hansel");
            }
            else
            {
                fade.FadeIn(timer, () =>
                {
                    if (fadeImage.CutoutRange == 1f)
                    {
                        SoundManager.Instance.FadeIn_BGM();
                        mainScreen.gameObject.SetActive(true);
                        this.gameObject.SetActive(false);
                    }
                });
            }
        }
    }

    IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(1f);
        fade.FadeOut(1f);
    }
}
