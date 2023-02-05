using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public enum ScenarioScenePeter
{
    //����
    introduction,
    //�I�𒲂ׂ�
    examineTheShelf,
    //�ǂ̒��莆�𒲂ׂ�
    wallPaper,
    //����1���A�C�e�������璲�ׂ�
    displayMemo1FromTheItemCcolumn,
    //�}�b�`�����ĂȂ���
    dontHaveMatch,
    //�}�b�`�����Ă鎞
    haveAMatch,
    //�w�����e�𒲂ׂ�
    shadowPointing,
    //�֎q�𒲂ׂ�
    examineTheChair,
    //�ǎw���e
    shadowPointingToTheWall,
    //�e�o���㒲�ׂ�
    examineAfterTheShadowAppears,
    //�e���ׂ�
    examineShadows,
    //�G��𒲂ׂ�
    examineThePainting,
    //�ԈႢ�𒲂ׂ�
    checkForMistakes,
    //�l�Y�~�𒲂ׂ�
    examineTheRat,
    //�l�Y�~����L�b�`���𒲂ׂ�
    examineTheKitchenFromRats,
    //�`�[�Y�������ăl�Y�~�𒲂ׂ�
    examineTheMouseWithTheCheese,
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

    [SerializeField, Header("�t�F�[�h�C���̎���")]
    float timer;
    [SerializeField, Header("�V�i���I�̏��")]
    ScenarioScenePeter scenarioScene;

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
        switch (scenarioScene)
        {
            case ScenarioScenePeter.introduction:

                scenariosManager.PlayScenario(5,22);
                
                break;
            
            case ScenarioScenePeter.examineTheShelf:

                scenariosManager.PlayScenario(31,31);

                break;
            
            case ScenarioScenePeter.wallPaper:

                scenariosManager.PlayScenario(34,35);

                break;

            case ScenarioScenePeter.displayMemo1FromTheItemCcolumn:

                scenariosManager.PlayScenario(38,38);

                break;
           
            case ScenarioScenePeter.dontHaveMatch:

                scenariosManager.PlayScenario(44,46);

                break;
            
            case ScenarioScenePeter.haveAMatch:

                scenariosManager.PlayScenario(49,62);

                break;
            
            case ScenarioScenePeter.shadowPointing:

                scenariosManager.PlayScenario(65,66);

                break;
            
            case ScenarioScenePeter.examineTheChair:

                scenariosManager.PlayScenario(70,78);

                break;

            case ScenarioScenePeter.shadowPointingToTheWall:

                scenariosManager.PlayScenario(83,84);

                break;
            
            case ScenarioScenePeter.examineAfterTheShadowAppears:

                scenariosManager.PlayScenario(88,92);

                break;
            
            case ScenarioScenePeter.examineShadows:

                scenariosManager.PlayScenario(96,96);

                break;
            
            case ScenarioScenePeter.examineThePainting:

                scenariosManager.PlayScenario(100,101);

                break;

            case ScenarioScenePeter.checkForMistakes:

                scenariosManager.PlayScenario(104,108);

                break;
            
            case ScenarioScenePeter.examineTheRat:

                scenariosManager.PlayScenario(113,114);

                break;
            
            case ScenarioScenePeter.examineTheKitchenFromRats:

                scenariosManager.PlayScenario(118,121);

                break;
            
            case ScenarioScenePeter.examineTheMouseWithTheCheese:

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
