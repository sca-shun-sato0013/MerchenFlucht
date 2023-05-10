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

    inspectFrontDoor,

    shelfCipherAnswer,

    examineTheDiary,

    examineThePhoto,

    examineShelf2,

    checkBucket,

    pokerGet,

    grannykitchen,
    //水窯
    waterKiln,

    bucketGet,

    bucketOfWater,

    bonFire,

    fireFighting,

    grandMatherFurnace,

    noMatch,

    keyGet,

    happyEnd,

    matchGet,

    haveAMatch,

    trueEnd,

    badEnd,
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
