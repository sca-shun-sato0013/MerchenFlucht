using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public enum ScenarioSceneLittle
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
}

public class ScenarioScreenLittleRedRidingHood : MonoBehaviour, IUpdateManager
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

    [SerializeField, Header("フェードインの時間")]
    float timer;
    [SerializeField, Header("シナリオの場面")]
    ScenarioSceneLittle scenarioScene;

    public ScenarioSceneLittle ScenarioPattarn
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
        switch (scenarioScene)
        {
            case ScenarioSceneLittle.introduction:

                scenariosManager.PlayScenario(4,16);
                
                break;
            
            case ScenarioSceneLittle.examineTheShelf:

                scenariosManager.PlayScenario(31,31);

                break;
            
            case ScenarioSceneLittle.wallPaper:

                scenariosManager.PlayScenario(34,35);

                break;

            case ScenarioSceneLittle.displayMemo1FromTheItemCcolumn:

                scenariosManager.PlayScenario(38,38);

                break;
           
            case ScenarioSceneLittle.dontHaveMatch:

                scenariosManager.PlayScenario(44,46);

                break;
            
            case ScenarioSceneLittle.haveAMatch:

                scenariosManager.PlayScenario(49,62);

                break;
            
            case ScenarioSceneLittle.shadowPointing:

                scenariosManager.PlayScenario(65,66);

                break;
            
            case ScenarioSceneLittle.examineTheChair:

                scenariosManager.PlayScenario(70,78);

                break;

            case ScenarioSceneLittle.shadowPointingToTheWall:

                scenariosManager.PlayScenario(83,84);

                break;
            
            case ScenarioSceneLittle.examineAfterTheShadowAppears:

                scenariosManager.PlayScenario(88,92);

                break;
            
            case ScenarioSceneLittle.examineShadows:

                scenariosManager.PlayScenario(96,96);

                break;
            
            case ScenarioSceneLittle.examineThePainting:

                scenariosManager.PlayScenario(100,101);

                break;

            case ScenarioSceneLittle.checkForMistakes:

                scenariosManager.PlayScenario(104,108);

                break;
            
            case ScenarioSceneLittle.examineTheRat:

                scenariosManager.PlayScenario(113,114);

                break;
            
            case ScenarioSceneLittle.examineTheKitchenFromRats:

                scenariosManager.PlayScenario(118,121);

                break;
            
            case ScenarioSceneLittle.examineTheMouseWithTheCheese:

                scenariosManager.PlayScenario(125,127);

                break;
        }
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
            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            fade.FadeIn(timer,() => 
            {
                if (fadeImage.CutoutRange == 1f)
                {
                    mainScreen.gameObject.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            });
        }
    }
}
