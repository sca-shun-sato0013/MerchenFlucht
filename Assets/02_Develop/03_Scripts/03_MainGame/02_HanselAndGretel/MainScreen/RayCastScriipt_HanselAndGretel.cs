using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using NJsonLoader;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.EventSystems;

public class RayCastScriipt_HanselAndGretel : MonoBehaviour, IUpdateManager
{
    [SerializeField]
    ImageLoadings imageLoadings;

    [SerializeField]
    Fade fade;
    [SerializeField]
    FadeImage fadeImage;
    [SerializeField]
    GameObject scenarioScreen;
    [SerializeField]
    ScenarioScreenHansel hansel;

    [SerializeField]
    Image item3,item4,item5,item6,item7;

    [SerializeField]
    GameObject cipherScreen_Door,shelf,poker;

    [SerializeField]
    GameObject bucket,match,key;
    
    [SerializeField]
    GameObject fireEffect;

    [SerializeField]
    GameObject cipherScreen;

    [SerializeField, Header("���΂������")]
    GameObject grandmotherKichen, grandmotherFurnace;

    [SerializeField]
    BoxCollider furnace_Col;

    [SerializeField,Header("�h�A�̈Í��\���A��\��")]
    PlayableDirector cipherScreen_Door_TimeLine;

    [SerializeField,Header("�I�̈Í��\���A��\��")]
    PlayableDirector cipherScreen_shelf,cipherReScreen_shelf;

    [SerializeField, Header("�΂����_�̈Í��\���A��\��")]
    PlayableDirector cipherScreen_Poker,cipherReScreen_Poker;

    [SerializeField]
    PlayableDirector furnace_Close;

    [SerializeField] 
    ShaftRotation_Hansel check;

    [SerializeField]
    GameObject[] candles;

    ScenarioState scenarioState;

    bool[] flagCandles;
    
    bool flag = true;

    void Start()
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);

        furnace_Col.enabled = false;
        grandmotherFurnace.SetActive(false);
        grandmotherKichen.SetActive(true);
        match.SetActive(false);
        key.SetActive(false);

        flagCandles = new bool[candles.Length];
        flagCandles[0] = true;
        flagCandles[1] = true;
        flagCandles[2] = true;
        flagCandles[3] = true;
        flagCandles[4] = true;
        flagCandles[5] = true;

        scenarioState = new ScenarioState();
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
        //Debug.Log(flagCandles[1]);

        if (cipherScreen.activeSelf) return;

        //Ray���΂����ǂ���
        if (check.RayCastON)
        {
            if (MobileInput.InputState(TouchPhase.Began)) // ���N���b�N
            {
                Touch touch = Input.GetTouch(0);

                Ray ray = Camera.main.ScreenPointToRay(touch.position); // Ray�𐶐�


                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) // Ray�𓊎�
                {
                    if (hit.collider.gameObject.name == "FrontDoor")
                    {
                        if(item6.sprite.name == "�G�{�ɋ��܂��Ă錮(Clone)")
                        {
                            if(item7.sprite.name == "�}�b�`(Clone)")
                            {
                                fade.FadeIn(2f);

                                scenarioState.trueEndHansel = true;
                                scenarioState.scenarioSceneHansel = ScenarioSceneHansel.trueEnd;
                                ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                                StartCoroutine(Change_MainScreen());
                            }
                            else
                            {
                                fade.FadeIn(2f);

                                //imageLoadings.AddList(items[1], "Assets/LoadingDatas/ScenarioDatas/PeterPan/����1.png");
                                scenarioState.happyEndHansel = true;
                                scenarioState.scenarioSceneHansel = ScenarioSceneHansel.happyEnd;
                                ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                                StartCoroutine(Change_MainScreen());

                            }
                        }
                        else
                        {
                            fade.FadeIn(2f);

                            //imageLoadings.AddList(items[1], "Assets/LoadingDatas/ScenarioDatas/PeterPan/����1.png")
                            scenarioState.scenarioSceneHansel = ScenarioSceneHansel.inspectFrontDoor;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen());
                        }

                    }

                    if (hit.collider.gameObject.name == "DoorToKitchen")
                    {
                        cipherScreen_Door.SetActive(true);
                        cipherScreen_Door_TimeLine.enabled = false;
                        cipherScreen_Door_TimeLine.enabled = true;
                    }

                    if (hit.collider.gameObject.name == "�I")
                    {
                        shelf.SetActive(true);
                        cipherScreen_shelf.enabled = false;
                        cipherScreen_shelf.enabled = true;
                    }

                    if (hit.collider.gameObject.name == "�I.001")
                    {
                        fade.FadeIn(2f);

                        imageLoadings.AddList(item3, "Assets/LoadingDatas/ScenarioDatas/HanselAndGretel/H&G�G�{(��).png");

                        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.examineShelf2;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    }

                    //�o�P�c
                    if (hit.collider.gameObject.name == "Bucket")
                    {
                        if(item4.sprite.name == "Black(Clone)")
                        {
                            fade.FadeIn(2f);

                            imageLoadings.AddList(item5,"Assets/LoadingDatas/ScenarioDatas/HanselAndGretel/H&G�΂����_�̓䏉���S�̐}.png");
                            
                            bucket.SetActive(false);
                            scenarioState.scenarioSceneHansel = ScenarioSceneHansel.bucketGet;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen());

                        }
                        else
                        {
                            fade.FadeIn(2f);

                            scenarioState.scenarioSceneHansel = ScenarioSceneHansel.checkBucket;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen());
                        }
                    }

                    
                    /*if (hit.collider.gameObject.name == "Bucket")
                    {
                        fade.FadeIn(2f);

                        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.checkBucket;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    }*/

                    if (hit.collider.gameObject.name == "Poker")
                    {
                        poker.SetActive(true);
                        cipherScreen_Poker.enabled = false;
                        cipherScreen_Poker.enabled = true;
                    }

                    if(hit.collider.gameObject.name == "GrandmotherKichen")
                    {
                        fade.FadeIn(2f);

                        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.grannykitchen;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    }

                    if (hit.collider.gameObject.name == "GrandmotherFurnace")
                    {
                        StartCoroutine(Furnace_Close());
                    }

                    if (hit.collider.gameObject.name == "���r")
                    {
                        if(item5.sprite.name == "H&G�΂����_�̓䏉���S�̐}(Clone)")
                        {
                            fade.FadeIn(2f);

                            imageLoadings.AddList(item5, "Assets/LoadingDatas/ScenarioDatas/HanselAndGretel/H&G�΂����_�̓䐳��S�̐}.png");

                            scenarioState.scenarioSceneHansel = ScenarioSceneHansel.bucketOfWater;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen());
                        }
                        else
                        {
                            fade.FadeIn(2f);

                            scenarioState.scenarioSceneHansel = ScenarioSceneHansel.waterKiln;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen());
                        }

                    }

                    if (hit.collider.gameObject.name == "�d")
                    {
                        if(item5.sprite.name == "H&G�΂����_�̓䐳��S�̐}(Clone)")
                        {
                            fade.FadeIn(2f);

                            fireEffect.SetActive(false);
                            scenarioState.scenarioSceneHansel = ScenarioSceneHansel.fireFighting;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen(grandmotherFurnace,grandmotherKichen));
                        }
                        else
                        {
                            fade.FadeIn(2f);

                            scenarioState.scenarioSceneHansel = ScenarioSceneHansel.bonFire;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen());
                        }
                    }

                    if (hit.collider.gameObject.name == "���܂�")
                    {
                        if(item5.sprite.name == "�}�b�`(Clone)")
                        {
                            fade.FadeIn(2f);

                            scenarioState.scenarioSceneHansel = ScenarioSceneHansel.haveAMatch;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen());
                        }
                        else
                        {
                            fade.FadeIn(2f);

                            scenarioState.scenarioSceneHansel = ScenarioSceneHansel.noMatch;
                            ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                            StartCoroutine(Change_MainScreen());

                        }
                    }

                    if (hit.collider.gameObject.name == "Key")
                    {
                        fade.FadeIn(2f);

                        key.SetActive(false);
                        imageLoadings.AddList(item6, "Assets/LoadingDatas/ScenarioDatas/PeterPan/�G�{�ɋ��܂��Ă錮.png");


                        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.keyGet;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    }

                    if (hit.collider.gameObject.name == "match")
                    {
                        fade.FadeIn(2f);

                        imageLoadings.AddList(item7, "Assets/LoadingDatas/ScenarioDatas/PeterPan/�}�b�`.png");

                        match.SetActive(false);
                        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.matchGet;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    }
                }
            }
        }
    }
    

    public void Scenario(ScenarioSceneHansel scenario)
    {
        fade.FadeIn(2f);

        scenarioState.scenarioSceneHansel = scenario;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen());
    }

    public void ScenarioItemGet(ScenarioSceneHansel scenario ,Image img,string str)
    {
        fade.FadeIn(2f);

        scenarioState.scenarioSceneHansel = scenario;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen(img,str));
    }

    private IEnumerator Furnace_Close()
    {

        furnace_Close.enabled = true;

        yield return new WaitForSeconds(2f);

        fade.FadeIn(2f);

        furnace_Col.enabled = true;
        match.SetActive(true);

        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.grandMatherFurnace;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen(key));
    }

    private IEnumerator Change_MainScreen()
    {
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        scenarioScreen.SetActive(true);
        hansel.enabled = true;
    }

    private IEnumerator Change_MainScreen(Image img,string str)
    {
        Debug.Log("�t�F�[�h�C��" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        imageLoadings.AddList(img,str);
        scenarioScreen.SetActive(true);
        hansel.enabled = true;
    }

    private IEnumerator Change_MainScreen(GameObject obj, GameObject obj2)
    {
        Debug.Log("�t�F�[�h�C��" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        obj.SetActive(true);
        obj2.SetActive(false);
        scenarioScreen.SetActive(true);
        hansel.enabled = true;
    }

    private IEnumerator Change_MainScreen(GameObject obj)
    {
        Debug.Log("�t�F�[�h�C��" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        obj.SetActive(true);
        scenarioScreen.SetActive(true);
        hansel.enabled = true;
    }
}
