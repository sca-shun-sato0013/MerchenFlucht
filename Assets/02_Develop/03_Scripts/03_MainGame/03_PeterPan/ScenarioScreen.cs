using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public enum ScenarioScene
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

public class ScenarioScreen : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    ScenarioManager scenariosManager;

    [SerializeField]
    AnchoredWindowMove charaMove;

    [SerializeField]
    ImageTransparencyAnimation charaAnimation,backGround;

    [SerializeField]
    Fade fade;

    [SerializeField]
    FadeImage fadeImage;

    [SerializeField]
    GameObject mainScreen;

    [SerializeField]
    SetDisplayImage setDisplayImage;

    [SerializeField,Header("フェードインの時間")]
    float timer;
    [SerializeField,Header("シナリオの場面")]
    ScenarioScene scenarioScene;

    bool check = true;
    bool flag = false;
    int save;

    string imageSave;
    string pastImage;

    private void OnEnable()
    {
        switch (scenarioScene)
        {
            case ScenarioScene.introduction:

                scenariosManager.PlayScenario(5,22);
                
                break;
            
            case ScenarioScene.examineTheShelf:

                scenariosManager.PlayScenario(31,31);

                break;
            
            case ScenarioScene.wallPaper:

                scenariosManager.PlayScenario(34,35);

                break;

            case ScenarioScene.displayMemo1FromTheItemCcolumn:

                scenariosManager.PlayScenario(38,38);

                break;
           
            case ScenarioScene.dontHaveMatch:

                scenariosManager.PlayScenario(44,46);

                break;
            
            case ScenarioScene.haveAMatch:

                scenariosManager.PlayScenario(49,62);

                break;
            
            case ScenarioScene.shadowPointing:

                scenariosManager.PlayScenario(65,66);

                break;
            
            case ScenarioScene.examineTheChair:

                scenariosManager.PlayScenario(70,78);

                break;

            case ScenarioScene.shadowPointingToTheWall:

                scenariosManager.PlayScenario(83,84);

                break;
            
            case ScenarioScene.examineAfterTheShadowAppears:

                scenariosManager.PlayScenario(88,92);

                break;
            
            case ScenarioScene.examineShadows:

                scenariosManager.PlayScenario(96,96);

                break;
            
            case ScenarioScene.examineThePainting:

                scenariosManager.PlayScenario(100,101);

                break;

            case ScenarioScene.checkForMistakes:

                scenariosManager.PlayScenario(104,108);

                break;
            
            case ScenarioScene.examineTheRat:

                scenariosManager.PlayScenario(113,114);

                break;
            
            case ScenarioScene.examineTheKitchenFromRats:

                scenariosManager.PlayScenario(118,121);

                break;
            
            case ScenarioScene.examineTheMouseWithTheCheese:

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

        OnClickCharaMove();

        OnClickBackGroundTransition();

        OnClickText();
    }

    private void OnClickCharaMove()
    {
        if (save + 1 == scenariosManager.CurrentLineNum)
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
    }

    private void OnClickBackGroundTransition()
    {
        imageSave = setDisplayImage.ImageDatas[0];
        
        if (MobileInput.InputState(TouchPhase.Began) || flag)
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

    private void OnClickText()
    {
        //        MobileInput.InputState(TouchPhase.Began) && !scenariosManager.LineEndCheck()
        if (MobileInput.InputState(TouchPhase.Began) && !scenariosManager.LineEndCheck())
        {
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
