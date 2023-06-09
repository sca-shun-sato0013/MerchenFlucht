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

public class RayCastScript_Little : MonoBehaviour, IUpdateManager
{
    [SerializeField]
    ImageLoadings imageLoadings;

    [SerializeField]
    Fade fade;
    [SerializeField]
    FadeImage fadeImage;
    [SerializeField,Header("�X�N���[���n")]
    GameObject scenarioScreen,cabinetScreen;

    [SerializeField]
    ScenarioScreenLittle little;

    [SerializeField]
    PlayableDirector cabinet_Open,carpetMove,carpetReMove,underFloorStorageScreen_Open,woodenBoxScreen_Open,medicineBoxScrenn_Open;

    [SerializeField,Header("BoxColider")]
    BoxCollider frontDoor_BoxCol;

    [SerializeField]
    Image item1,item3, item4, item5, item6;

    [SerializeField]
    ShaftRotation_Little check;
    [SerializeField]
    YesButton yesButton;

    ScenarioState scenarioState;

    int count = 1;

    int basketCount = 0;

    bool diaryLoadCheck = false;

    void Start()
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);

        scenarioState = new ScenarioState();
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

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
                    //����
                    if (hit.collider.gameObject.name == "FrontDoor")
                    {
                        ScenarioLoad(ScenarioSceneLittle.frontDoor);
                    }
                    //�T
                    else if (hit.collider.gameObject.name == "Wolf")
                    {
                        if(item5.sprite.name == "TeaSleepingPills(Clone)")
                        {
                            if(item6.sprite.name == "Knife(Clone)")
                            {
                                //true�G���h
                                scenarioState.trueEndLittle = true;
                                ScenarioLoad(ScenarioSceneLittle.trueEnd);
                            }
                            else
                            {
                                //happy�G���h
                                scenarioState.happyEndLittle = true;
                                ScenarioLoad(ScenarioSceneLittle.happyEnd);
                            }
                        }
                        else
                        {
                            ScenarioLoad(ScenarioSceneLittle.wolf_Normal);
                        }
                    }
                    //�����̑�
                    else if(hit.collider.CompareTag("Window"))
                    {
                        ScenarioLoad(ScenarioSceneLittle.window);
                    }
                    //��
                    else if (hit.collider.gameObject.name == "basket")
                    {
                        basketCount++;

                        if(basketCount > 2)
                        {
                            ScenarioLoad_ItemGet(ScenarioSceneLittle.kitchenKnife,item6, "Assets/LoadingDatas/ScenarioDatas/LittleRedRidingHood/Knife.png");
                        }
                        else
                        {
                            ScenarioLoad(ScenarioSceneLittle.basket);
                        }
                    }
                    //�L�b�`���̒I
                    else if (hit.collider.gameObject.name == "teaCup")
                    {
                        ScenarioLoad_ItemGet(ScenarioSceneLittle.kichenShelf, item1, "Assets/LoadingDatas/ScenarioDatas/LittleRedRidingHood/TeaCup.png");
                    }
                    //�|�b�g
                    else if (hit.collider.gameObject.name == "pot")
                    {
                        if(item1.sprite.name == "TeaCup(Clone)" && item3.sprite.name == "��r(Clone)")
                        {
                           ScenarioLoad_ItemGet(ScenarioSceneLittle.sleepingPillsTea,item5, "Assets/LoadingDatas/ScenarioDatas/LittleRedRidingHood/TeaSleepingPills.png");
                        }
                        else
                        {
                            ScenarioLoad(ScenarioSceneLittle.pot);
                        }
                    }
                    //�L���r�l�b�g
                    else if (hit.collider.gameObject.name == "Cabinet")
                    {
                        cabinetScreen.SetActive(true);
                        cabinet_Open.enabled = false;
                        cabinet_Open.enabled = true;
                    }
                    //�Ƒ��ʐ^
                    else if(hit.collider.gameObject.name == "FamilyPhoto")
                    {
                        ScenarioLoad_ItemGet(ScenarioSceneLittle.familyPhptoGet,item4, "Assets/LoadingDatas/ScenarioDatas/LittleRedRidingHood/�Ƒ��ʐ^�\.png");
                    }
                    //�J�[�y�b�g
                    else if (hit.collider.gameObject.name == "Carpet")
                    {
                        count++;

                        if(count % 2 == 0)
                        {
                            fade.FadeIn(1f);

                            StartCoroutine(CarpetMove(carpetMove));
                        }
                        else
                        {
                            fade.FadeIn(1f);

                            StartCoroutine(CarpetMove(carpetReMove));
                        }                    
                    }
                    //�����q��
                    else if(hit.collider.gameObject.name == "UnderFloorStorage")
                    {
                        underFloorStorageScreen_Open.enabled = false;
                        underFloorStorageScreen_Open.enabled = true;
                    }
                    //�ؔ�
                    else if(hit.collider.gameObject.name == "WoodenBox")
                    {
                        woodenBoxScreen_Open.enabled = false;
                        woodenBoxScreen_Open.enabled = true;
                    }
                    //��
                    else if (hit.collider.gameObject.name == "medicineBox")
                    {
                        if(yesButton.DiaryLoadCheck)
                        {
                            medicineBoxScrenn_Open.enabled = false;
                            medicineBoxScrenn_Open.enabled = true;
                        }
                        else
                        {
                            ScenarioLoad(ScenarioSceneLittle.lockdKey_shelf);
                        }
                    }
                }
            }
        }
    }


    public void ScenarioLoad(ScenarioSceneLittle scene)
    {
        fade.FadeIn(0.5f);
        scenarioState.scenarioSceneLittle = scene;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen());
    }

    public void ScenarioLoad_ObjectActiv(ScenarioSceneLittle scene,GameObject obj)
    {
        fade.FadeIn(0.5f);
        scenarioState.scenarioSceneLittle = scene;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen(obj));
    }

    public void ScenarioLoad_ItemGet(ScenarioSceneLittle scene,Image getItem,string str)
    {
        fade.FadeIn(0.5f);
        scenarioState.scenarioSceneLittle = scene;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen(getItem,str));
    }

    private IEnumerator CarpetMove(PlayableDirector p)
    {
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        p.enabled = false;
        p.enabled = true;

        fade.FadeOut(0.5f);
    }
    private IEnumerator Change_MainScreen()
    {
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        scenarioScreen.SetActive(true);
        little.enabled = true;
    }

    private IEnumerator Change_MainScreen(Image img, string str)
    {
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        imageLoadings.AddList(img, str);
        scenarioScreen.SetActive(true);
        little.enabled = true;
    }

    private IEnumerator Change_MainScreen(GameObject obj, GameObject obj2)
    {
        Debug.Log("�t�F�[�h�C��" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        obj.SetActive(true);
        obj2.SetActive(false);
        scenarioScreen.SetActive(true);
        little.enabled = true;
    }

    private IEnumerator Change_MainScreen(GameObject obj)
    {
        Debug.Log("�t�F�[�h�C��" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        obj.SetActive(true);
        scenarioScreen.SetActive(true);
        little.enabled = true;
    }
}
