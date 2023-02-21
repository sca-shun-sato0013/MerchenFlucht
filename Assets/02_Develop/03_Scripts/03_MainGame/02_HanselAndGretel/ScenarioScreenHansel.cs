using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public enum ScenarioSceneHansel
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

public class ScenarioScreenHansel: MonoBehaviour, IUpdateManager
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
    ScenarioSceneHansel scenarioScene;

    public ScenarioSceneHansel ScenarioPattarn
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
            case ScenarioSceneHansel.introduction:

                scenariosManager.PlayScenario(5,22);
                
                break;
            
            case ScenarioSceneHansel.examineTheShelf:

                scenariosManager.PlayScenario(31,31);

                break;
            
            case ScenarioSceneHansel.wallPaper:

                scenariosManager.PlayScenario(34,35);

                break;

            case ScenarioSceneHansel.displayMemo1FromTheItemCcolumn:

                scenariosManager.PlayScenario(38,38);

                break;
           
            case ScenarioSceneHansel.dontHaveMatch:

                scenariosManager.PlayScenario(44,46);

                break;
            
            case ScenarioSceneHansel.haveAMatch:

                scenariosManager.PlayScenario(49,62);

                break;
            
            case ScenarioSceneHansel.shadowPointing:

                scenariosManager.PlayScenario(65,66);

                break;
            
            case ScenarioSceneHansel.examineTheChair:

                scenariosManager.PlayScenario(70,78);

                break;

            case ScenarioSceneHansel.shadowPointingToTheWall:

                scenariosManager.PlayScenario(83,84);

                break;
            
            case ScenarioSceneHansel.examineAfterTheShadowAppears:

                scenariosManager.PlayScenario(88,92);

                break;
            
            case ScenarioSceneHansel.examineShadows:

                scenariosManager.PlayScenario(96,96);

                break;
            
            case ScenarioSceneHansel.examineThePainting:

                scenariosManager.PlayScenario(100,101);

                break;

            case ScenarioSceneHansel.checkForMistakes:

                scenariosManager.PlayScenario(104,108);

                break;
            
            case ScenarioSceneHansel.examineTheRat:

                scenariosManager.PlayScenario(113,114);

                break;
            
            case ScenarioSceneHansel.examineTheKitchenFromRats:

                scenariosManager.PlayScenario(118,121);

                break;
            
            case ScenarioSceneHansel.examineTheMouseWithTheCheese:

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
