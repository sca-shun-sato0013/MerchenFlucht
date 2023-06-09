using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using DesignPattern;
using NJsonLoader;
using UnityEngine.Rendering;

public enum ScenarioScenePeter
{
    //導入
    introduction,
    //棚を調べた
    examineTheShelf,
    //壁の張り紙を調べる
    wallPaper,
    //メモ1をアイテム欄から調べる
    displayMemo1FromTheItemCcolumn,
    //マッチ持ってない時
    dontHaveMatch,
    //マッチ持ってる時
    haveAMatch,
    //指さす影を調べる
    shadowPointing,
    //椅子を調べる
    examineTheChair,
    //壁指す影
    shadowPointingToTheWall,
    //影出た後調べる
    examineAfterTheShadowAppears,
    //影調べる
    examineShadows,
    //絵画を調べる
    examineThePainting,
    //間違いを調べる
    checkForMistakes,
    //ネズミを調べる
    examineTheRat,
    //ネズミからキッチンを調べる
    examineTheKitchenFromRats,
    //チーズを持ってネズミを調べる
    examineTheMouseWithTheCheese,

    examineTheShadowPointingWindow,

    checkTheWindowAfter,
    
    examineMemo2,

    examineTheBookShelf,

    ExamineTheOpenBookshelf,

    tapTheAppropriateBookshelf,

    examineTheBook,

    DevilsBookFromTheItem,

    fairyTaleFromTheiItem,

    ifYouDontHaveTheKey,
    
    ifYouHaveTheKey,

    diaryFromTheItem,

    afterReadingTheDevilsBook,

    afterReadingTheDiary,

    ifYouHaventReadTheDiary,

    examineTheLampWithin,

    ifTimeRunsOut,

    ifYouReadYourDiary,

    diaryReadingLamp,
}

public class ScenarioScreenPeterPan : MonoBehaviour, IUpdateManager
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
    GameOver gameOver;

    [SerializeField, Header("フェードインの時間")]
    float timer;
    [SerializeField, Header("シナリオの場面")]
    ScenarioScenePeter scenarioScene;

    ScenarioState scenarioState;

    bool justOnce = true;
    bool justOnce2 = true;

    public ScenarioScenePeter ScenarioPattarn
    {
        get { return scenarioScene; }
        set{ scenarioScene = value; }
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

        if(justOnce)
        {
            justOnce = false;

            StartCoroutine(FadeWait());
            mainScreen.SetActive(false);
            volume.enabled = false;
            SoundManager.Instance.PlayBGM(1, true);
            SoundManager.Instance.FadeOut_BGM(1f);

            scenarioState = new ScenarioState();
            scenarioState = ServiceLocator<IJsonLoader>.Instance.LoadStatusData<ScenarioState>("ScenarioState");

            scenarioScene = scenarioState.scenarioScenePeter;

            switch (scenarioScene)
            {
                case ScenarioScenePeter.introduction:

                    scenariosManager.PlayScenario(5, 21);

                    break;

                case ScenarioScenePeter.examineTheShelf:

                    scenariosManager.PlayScenario(30, 31);

                    break;

                case ScenarioScenePeter.wallPaper:

                    scenariosManager.PlayScenario(33, 34);

                    break;

                case ScenarioScenePeter.displayMemo1FromTheItemCcolumn:

                    scenariosManager.PlayScenario(38, 38);

                    break;

                case ScenarioScenePeter.dontHaveMatch:

                    scenariosManager.PlayScenario(43, 45);

                    break;

                case ScenarioScenePeter.haveAMatch:

                    scenariosManager.PlayScenario(48, 59);

                    break;

                case ScenarioScenePeter.shadowPointing:

                    scenariosManager.PlayScenario(63, 64);

                    break;

                case ScenarioScenePeter.examineTheChair:

                    scenariosManager.PlayScenario(68, 76);

                    break;

                case ScenarioScenePeter.shadowPointingToTheWall:

                    scenariosManager.PlayScenario(81, 82);

                    break;

                case ScenarioScenePeter.examineAfterTheShadowAppears:

                    scenariosManager.PlayScenario(86, 90);

                    break;

                case ScenarioScenePeter.examineShadows:

                    scenariosManager.PlayScenario(94, 94);

                    break;

                case ScenarioScenePeter.examineThePainting:

                    scenariosManager.PlayScenario(99,99);

                    break;

                case ScenarioScenePeter.checkForMistakes:

                    scenariosManager.PlayScenario(102, 106);

                    break;

                case ScenarioScenePeter.examineTheRat:

                    scenariosManager.PlayScenario(111, 112);

                    break;

                case ScenarioScenePeter.examineTheKitchenFromRats:

                    scenariosManager.PlayScenario(117,119);

                    break;

                case ScenarioScenePeter.examineTheMouseWithTheCheese:

                    scenariosManager.PlayScenario(123, 125);

                    break;

                case ScenarioScenePeter.examineTheShadowPointingWindow:

                    scenariosManager.PlayScenario(130,130);

                    break;

                case ScenarioScenePeter.checkTheWindowAfter:

                    scenariosManager.PlayScenario(133, 137);

                    break;
                
                case ScenarioScenePeter.examineMemo2:

                    scenariosManager.PlayScenario(141,146);

                    break;

                case ScenarioScenePeter.examineTheBookShelf:

                    scenariosManager.PlayScenario(149,149);

                    break;

                case ScenarioScenePeter.ExamineTheOpenBookshelf:

                    scenariosManager.PlayScenario(163, 164);

                    break;

                case ScenarioScenePeter.tapTheAppropriateBookshelf:

                    scenariosManager.PlayScenario(167,167);

                    break;

                case ScenarioScenePeter.examineTheBook:

                    scenariosManager.PlayScenario(171,172);

                    break;

                case ScenarioScenePeter.DevilsBookFromTheItem:

                    scenariosManager.PlayScenario(177,180);

                    break;

                case ScenarioScenePeter.fairyTaleFromTheiItem:

                    scenariosManager.PlayScenario(186,188);

                    break;

                case ScenarioScenePeter.ifYouDontHaveTheKey:

                    scenariosManager.PlayScenario(195,195);

                    break;

                case ScenarioScenePeter.ifYouHaveTheKey:

                    scenariosManager.PlayScenario(198,199);

                    break;

                case ScenarioScenePeter.diaryFromTheItem:

                    scenariosManager.PlayScenario(204,225);

                    break;

                case ScenarioScenePeter.afterReadingTheDevilsBook:

                    scenariosManager.PlayScenario(230,231);

                    break;

                case ScenarioScenePeter.afterReadingTheDiary:

                    scenariosManager.PlayScenario(236,242);

                    break;

                case ScenarioScenePeter.ifYouHaventReadTheDiary:

                    scenariosManager.PlayScenario(248,258);

                    break;

                case ScenarioScenePeter.examineTheLampWithin:

                    scenariosManager.PlayScenario(322,343);

                    break;

                case ScenarioScenePeter.ifTimeRunsOut:

                    scenariosManager.PlayScenario(271,288);

                    break;

                case ScenarioScenePeter.ifYouReadYourDiary:

                    scenariosManager.PlayScenario(292,305);

                    break;

                case ScenarioScenePeter.diaryReadingLamp:

                    scenariosManager.PlayScenario(348,389);

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

/*    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);

        
        backGround.enabled = false;
        backGround.enabled = true;
    }*/

    private void OnClickText(bool input)
    {
        //        MobileInput.InputState(TouchPhase.Began) && !scenariosManager.LineEndCheck()
        if (input && !scenariosManager.LineEndCheck())
        {
            if(gameOver.GameEnd && justOnce2)
            {
                justOnce2 = false;
                SceneManager.Instance.SceneLoadingAsync("title");
            }
            else if(scenarioState.happyEnd && justOnce2)
            {
                justOnce2 = false;
                SceneManager.Instance.SceneLoadingAsync("title");
            }
            else if(scenarioState.trueEnd && justOnce2)
            {
                justOnce2 = false;
                SceneManager.Instance.SceneLoadingAsync("EndRollScreen");
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
