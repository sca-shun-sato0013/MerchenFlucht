using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using NJsonLoader;
using UnityEngine.UI;
using UnityEngine.Playables;

[System.Serializable]
public class ScenarioState
{
    public ScenarioScenePeter scenarioScenePeter;
    public bool happyEnd = false;
    public bool trueEnd = false;
}

public class RayCastScript : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    ScenarioScreenPeterPan peterPan;
    [SerializeField]
    GameObject scenarioScreen;
    [SerializeField]
    Timer countDownTimer;
    [SerializeField, Header("�Í����")]
    GameObject cipherScreen;
    [SerializeField]
    ClickScenario clickScenario;
    [SerializeField]
    CipherScreen cipherScreenComponent;
    [SerializeField, Header("���G�t�F�N�g")]
    GameObject fireEffect;
    [SerializeField, Header("memo1")]
    GameObject memo1;
    [SerializeField, Header("�e")]
    GameObject shadowHumanChair;
    [SerializeField, Header("�ǎw���e")]
    GameObject shadowHumanWall;
    [SerializeField, Header("�e�m������")]
    GameObject shadowHumanStandUp;
    [SerializeField, Header("�e�������w��")]
    GameObject shadowHumanWindow;

    [SerializeField, Header("�l�Y�~")]
    GameObject mouseOrCat;
    [SerializeField, Header("�l�Y�~�̉摜")]
    Image mouseOrCatImage;
    [SerializeField, Header("�`�[�Y")]
    GameObject chesse;

    [SerializeField]
    Image item2,item5;
    
    [SerializeField]
    Fade fade;
    [SerializeField]
    FadeImage fadeImage;
    [SerializeField, Header("�A�C�e��")]
    Image[] items;
    [SerializeField]
    ImageLoadings imageLoadings;

    [SerializeField]
    BoxCollider keyBox_Collider,window;
    [SerializeField]
    PlayableDirector 
    keyBox_TimeLine,
    keyBoxRe_TimeLine,
    cipherScreenOpen_TimeLine,
    cipherScreenClose_TimeLine,
    keyBox_Open;

    ScenarioState scenarioState;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
        
        scenarioState = new ScenarioState();
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if (MobileInput.InputState(TouchPhase.Began)) // ���N���b�N
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position); // Ray�𐶐�
            Debug.Log(touch.position);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit)) // Ray�𓊎�
            {
                if(hit.collider.gameObject.name == "match")
                {
                    if (memo1.activeSelf == false)
                    {


                        fade.FadeIn(2f);

                        imageLoadings.AddList(items[0], "Assets/LoadingDatas/ScenarioDatas/PeterPan/�}�b�`.png");
                        imageLoadings.enabled = false;
                        imageLoadings.enabled = true;

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.examineTheShelf;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen(mouseOrCat));

                        // �I�u�W�F�N�g��j��
                        Destroy(hit.collider.gameObject);
                    }
                }

                if (hit.collider.gameObject.name == "memo1")
                {
                    fade.FadeIn(2f);

                    imageLoadings.AddList(items[1], "Assets/LoadingDatas/ScenarioDatas/PeterPan/����1.png");
                    imageLoadings.enabled = false;
                    imageLoadings.enabled = true;

                    scenarioState.scenarioScenePeter = ScenarioScenePeter.wallPaper;
                    ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                    StartCoroutine(Change_MainScreen());

                    memo1.gameObject.SetActive(false);
                }

                if (hit.collider.gameObject.name == "ranpu")
                {

                    fade.FadeIn(2f);
                    
                    if(clickScenario.DiaryFlag)
                    {
                        if (countDownTimer.TimerFlag)
                        {
                            scenarioState.trueEnd = true;
                            scenarioState.scenarioScenePeter = ScenarioScenePeter.diaryReadingLamp;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen());
                        }
                    }
                    else
                    {
                        if (countDownTimer.TimerFlag)
                        {
                            scenarioState.happyEnd = true;
                            scenarioState.scenarioScenePeter = ScenarioScenePeter.examineTheLampWithin;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen());
                        }
                        else
                        {
                            if (clickScenario.DevilBookFlag)
                            {
                                scenarioState.scenarioScenePeter = ScenarioScenePeter.afterReadingTheDevilsBook;
                                ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                                StartCoroutine(Change_MainScreen());
                            }
                            else
                            {
                                if (items[0].sprite.name == "�}�b�`(Clone)")
                                {
                                    fireEffect.gameObject.SetActive(true);
                                    scenarioState.scenarioScenePeter = ScenarioScenePeter.haveAMatch;
                                    ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                                    StartCoroutine(Change_MainScreen(shadowHumanChair));
                                }
                                else
                                {
                                    scenarioState.scenarioScenePeter = ScenarioScenePeter.dontHaveMatch;
                                    ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                                    StartCoroutine(Change_MainScreen());
                                }
                            }
                        }
                    }                    
                }

                if (hit.collider.gameObject.name == "shadowHumanChair")
                {
                    fade.FadeIn(2f);
                    //imageLoadings.AddList(items[0], "Assets/LoadingDatas/ScenarioDatas/PeterPan/�ԈႢ�T��.png");
                    //imageLoadings.enabled = false;
                    //imageLoadings.enabled = true;

                    scenarioState.scenarioScenePeter = ScenarioScenePeter.shadowPointing;
                    ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                    StartCoroutine(Change_MainScreen());

                }


                if (hit.collider.gameObject.name == "�֎q.006")
                {
                    if (shadowHumanChair.activeSelf == true)
                    {
                        fade.FadeIn(2f);
                        imageLoadings.AddList(items[1], "Assets/LoadingDatas/ScenarioDatas/PeterPan/����2.png");
                        imageLoadings.enabled = false;
                        imageLoadings.enabled = true;

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.examineTheChair;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen(shadowHumanWall,shadowHumanChair));
                    }

                }

                if (hit.collider.gameObject.name == "shadowHumanWall")
                {                 
                        fade.FadeIn(2f);

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.shadowPointingToTheWall;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    
                }

                if (hit.collider.gameObject.name == "Crack")
                {
                    if(shadowHumanWall.activeSelf == true)
                    {
                        fade.FadeIn(2f);

                        imageLoadings.AddList(items[1], "Assets/LoadingDatas/ScenarioDatas/PeterPan/����3.png");
                        imageLoadings.enabled = false;
                        imageLoadings.enabled = true;

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.examineAfterTheShadowAppears;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen(shadowHumanStandUp,shadowHumanWall));
                    }

                }

                if (hit.collider.gameObject.name == "shadowHumanStandUp")
                {                    
                        fade.FadeIn(2f);

                    if(clickScenario.DiaryFlag)
                    {
                        scenarioState.scenarioScenePeter = ScenarioScenePeter.afterReadingTheDiary;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    }
                    else
                    {
                        scenarioState.scenarioScenePeter = ScenarioScenePeter.examineShadows;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    }
                }

                if (hit.collider.gameObject.name == "Painting")
                {
                    if (shadowHumanStandUp.activeSelf == true)
                    {
                        fade.FadeIn(2f);
                        
                        imageLoadings.SetImage(3, "Assets/LoadingDatas/ScenarioDatas/PeterPan/�l�Y�~(������).png");
                        imageLoadings.AddList(items[1], "Assets/LoadingDatas/ScenarioDatas/PeterPan/����4.png");
                        imageLoadings.enabled = false;
                        imageLoadings.enabled = true;

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.checkForMistakes;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());

                    }
                    else
                    {
                        fade.FadeIn(2f);

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.examineThePainting;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    }

                }

                if (hit.collider.gameObject.name == "MouseOrCat")
                {
                    if(shadowHumanWall.activeSelf == false)
                    {
                        if (mouseOrCatImage.sprite.name == "�l�Y�~(������)(Clone)")
                        {
                            if (chesse.activeSelf == false)
                            {
                                fade.FadeIn(2f);

                                scenarioState.scenarioScenePeter = ScenarioScenePeter.examineTheMouseWithTheCheese;
                                ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                                StartCoroutine(Change_MainScreen(shadowHumanWindow, mouseOrCat));
                            }
                            else
                            {
                                fade.FadeIn(2f);

                                scenarioState.scenarioScenePeter = ScenarioScenePeter.examineTheRat;
                                ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                                StartCoroutine(Change_MainScreen());
                            }
                        }
                    }
                }

                if (hit.collider.gameObject.name == "Chesse")
                {
                    if (mouseOrCatImage.sprite.name == "�l�Y�~(������)(Clone)")
                    {
                        fade.FadeIn(2f);

                        imageLoadings.AddList(items[2], "Assets/LoadingDatas/ScenarioDatas/PeterPan/�`�[�Y.png");
                        imageLoadings.enabled = false;
                        imageLoadings.enabled = true;

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.examineTheKitchenFromRats;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());

                        chesse.SetActive(false);
                    }

                }

                if (hit.collider.gameObject.name == "shadowHumanWindow")
                {                    
                        fade.FadeIn(2f);

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.examineTheShadowPointingWindow;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                }

                if (hit.collider.gameObject.name == "Cube.001")//��
                {
                    if (shadowHumanWindow.activeSelf == true)
                    {
                        fade.FadeIn(2f);

                        window.enabled = false;
                        imageLoadings.AddList(items[1], "Assets/LoadingDatas/ScenarioDatas/PeterPan/����5.png");
                        imageLoadings.enabled = false;
                        imageLoadings.enabled = true;

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.checkTheWindowAfter;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen(shadowHumanStandUp,shadowHumanWindow));
                    }

                }

                if (hit.collider.gameObject.name == "KeyBox")
                {
                    Debug.Log("�ʂ���");
                    if (item2.sprite.name == "����5(Clone)" && keyBox_Open.enabled == false)
                    {
                        Debug.Log("�ʂ���");

                        keyBox_Collider.enabled = false;
                        keyBox_TimeLine.enabled = false;
                        cipherScreenClose_TimeLine.enabled = false;
                        keyBox_TimeLine.enabled = true;

                        StartCoroutine(Open_CipherScreen());
                    }


                }

                if (hit.collider.gameObject.name == "DevilBook")
                {
                    if(keyBox_TimeLine.enabled == true)
                    {
                        hit.collider.gameObject.SetActive(false);
                        fade.FadeIn(2f);

                        imageLoadings.AddList(items[2], "Assets/LoadingDatas/ScenarioDatas/PeterPan/�����̖{(��).png");
                        imageLoadings.enabled = false;
                        imageLoadings.enabled = true;

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.ExamineTheOpenBookshelf;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");

                        StartCoroutine(Return_MainScreen());
                    }

                }

                if (hit.collider.gameObject.name == "Books2")
                {
  
                    fade.FadeIn(2f);

                    scenarioState.scenarioScenePeter = ScenarioScenePeter.tapTheAppropriateBookshelf;
                    ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");

                    StartCoroutine(Change_MainScreen());
                }

                if (hit.collider.gameObject.name == "FairyTaleBook")
                {

                    fade.FadeIn(2f);

                    imageLoadings.AddList(items[3], "Assets/LoadingDatas/ScenarioDatas/PeterPan/�G�{(��).png");
                    imageLoadings.enabled = false;
                    imageLoadings.enabled = true;

                    scenarioState.scenarioScenePeter = ScenarioScenePeter.examineTheBook;
                    ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");

                    StartCoroutine(Change_MainScreen());
                }

                if (hit.collider.gameObject.name == "KeyLock")
                {
                    if(item5.sprite.name == "�G�{�ɋ��܂��Ă錮(Clone)")
                    {
                        fade.FadeIn(2f);

                        imageLoadings.AddList(items[5],"Assets/LoadingDatas/ScenarioDatas/PeterPan/�s�[�^�[���L(��).png");
                        imageLoadings.enabled = false;
                        imageLoadings.enabled = true;

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.ifYouHaveTheKey;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");

                        StartCoroutine(Change_MainScreen());
                    }
                    else
                    {
                        fade.FadeIn(2f);

                        scenarioState.scenarioScenePeter = ScenarioScenePeter.ifYouDontHaveTheKey;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");

                        StartCoroutine(Change_MainScreen());
                    }

                }

                if (hit.collider.gameObject.name == "Fairy")
                {
                    fade.FadeIn(1f);

                    if (clickScenario.DiaryFlag)
                    {
                        countDownTimer.TimerFlag = true;
                        scenarioState.scenarioScenePeter = ScenarioScenePeter.ifYouReadYourDiary;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");

                        StartCoroutine(Change_MainScreen());
                    }
                    else
                    {
                        countDownTimer.TimerFlag = true;
                        scenarioState.scenarioScenePeter = ScenarioScenePeter.ifYouHaventReadTheDiary;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState,"ScenarioState");

                        StartCoroutine(Change_MainScreen());
                    }

                }
            }
        }
    }

    
    public IEnumerator Change_MainScreen()
    {
        Debug.Log("�t�F�[�h�C��"+ fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);
       
        scenarioScreen.SetActive(true);
        peterPan.enabled = true;
    }

    public IEnumerator Change_MainScreen(GameObject obj)
    {
        Debug.Log("�t�F�[�h�C��" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        obj.SetActive(true);
        scenarioScreen.SetActive(true);
        peterPan.enabled = true;
    }

    public IEnumerator Change_MainScreen(GameObject obj,GameObject obj2)
    {
        Debug.Log("�t�F�[�h�C��" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        obj.SetActive(true);
        obj2.SetActive(false);
        scenarioScreen.SetActive(true);
        peterPan.enabled = true;
    }

    IEnumerator Open_CipherScreen()
    {
        yield return new WaitForSeconds(1.2f);

        cipherScreen.SetActive(true);
        cipherScreenOpen_TimeLine.enabled = false;
        cipherScreenOpen_TimeLine.enabled = true;
    }

    IEnumerator Return_MainScreen()
    {
        Debug.Log("�t�F�[�h�C��" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        cipherScreenOpen_TimeLine.enabled = false;
        cipherScreenClose_TimeLine.enabled = false;
        keyBox_Open.enabled = false;
        keyBox_TimeLine.enabled = false;

        keyBoxRe_TimeLine.enabled = false;
        keyBoxRe_TimeLine.enabled = true;

        yield return new WaitForSeconds(1.2f);

        cipherScreen.SetActive(false);
        scenarioScreen.SetActive(true);
        peterPan.enabled = true;


    }
}
    