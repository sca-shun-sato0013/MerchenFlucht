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
    [SerializeField,Header("スクリーン系")]
    GameObject scenarioScreen,cabinetScreen;
    [SerializeField]
    ScenarioScreenLittle little;

    [SerializeField]
    PlayableDirector cabinet_Open,carpetMove,carpetReMove;

    [SerializeField,Header("BoxColider")]
    BoxCollider frontDoor_BoxCol;

    [SerializeField]
    Image item1,item3, item4, item5, item6;

    [SerializeField]
    ShaftRotation_Little check;

    ScenarioState scenarioState;

    int count = 1;

    void Start()
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);

        scenarioState = new ScenarioState();
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        //Rayを飛ばすかどうか
        if (check.RayCastON)
        {
            if (MobileInput.InputState(TouchPhase.Began)) // 左クリック
            {
                Touch touch = Input.GetTouch(0);

                Ray ray = Camera.main.ScreenPointToRay(touch.position); // Rayを生成

                
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) // Rayを投射
                {

                    if (hit.collider.gameObject.name == "FrontDoor")
                    {
                        ScenarioLoad(ScenarioSceneLittle.frontDoor);

                        /*                        if (item6.sprite.name == "絵本に挟まってる鍵(Clone)")
                                                {
                                                    if (item5.sprite.name == "マッチ(Clone)")
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

                                                        //imageLoadings.AddList(items[1], "Assets/LoadingDatas/ScenarioDatas/PeterPan/メモ1.png");
                                                        scenarioState.happyEndHansel = true;
                                                        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.happyEnd;
                                                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                                                        StartCoroutine(Change_MainScreen());

                                                    }
                                                }
                                                else
                                                {
                                                    fade.FadeIn(2f);

                                                    //imageLoadings.AddList(items[1], "Assets/LoadingDatas/ScenarioDatas/PeterPan/メモ1.png")
                                                    scenarioState.scenarioSceneHansel = ScenarioSceneHansel.inspectFrontDoor;
                                                    ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                                                    StartCoroutine(Change_MainScreen());
                                                }
                                                */
                    }

                    if(hit.collider.CompareTag("Window"))
                    {
                        ScenarioLoad(ScenarioSceneLittle.window);
                    }

                    if (hit.collider.gameObject.name == "basket")
                    {
                        ScenarioLoad(ScenarioSceneLittle.basket);
                    }

                    if (hit.collider.gameObject.name == "KichenShelf")
                    {
                        ScenarioLoad_ItemGet(ScenarioSceneLittle.kichenShelf, item1, "Assets/LoadingDatas/ScenarioDatas/LittleRedRidingHood/エンドロール１.png");
                    }

                    if (hit.collider.gameObject.name == "pot")
                    {
                        ScenarioLoad(ScenarioSceneLittle.pot);
                    }

                    if (hit.collider.gameObject.name == "Cabinet")
                    {
                        cabinetScreen.SetActive(true);
                        cabinet_Open.enabled = false;
                        cabinet_Open.enabled = true;
                    }

                    if(hit.collider.gameObject.name == "FamilyPhoto")
                    {
                        ScenarioLoad_ItemGet(ScenarioSceneLittle.familyPhptoGet,item4, "Assets/LoadingDatas/ScenarioDatas/LittleRedRidingHood/家族写真表.png");
                    }

                    if (hit.collider.gameObject.name == "Carpet")
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
                }
            }
        }
    }


    public void ScenarioLoad(ScenarioSceneLittle scene)
    {
        fade.FadeIn(1f);
        scenarioState.scenarioSceneLittle = scene;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen());
    }

    public void ScenarioLoad_ItemGet(ScenarioSceneLittle scene,Image getItem,string str)
    {
        fade.FadeIn(1f);
        scenarioState.scenarioSceneLittle = scene;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen(getItem,str));
    }

    public void ScenarioItemGet(ScenarioSceneHansel scenario, Image img, string str)
    {
        fade.FadeIn(2f);

        scenarioState.scenarioSceneHansel = scenario;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen(img, str));
    }

    private IEnumerator CarpetMove(PlayableDirector p)
    {
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        p.enabled = false;
        p.enabled = true;

        fade.FadeOut(1f);
    }
    private IEnumerator Change_MainScreen()
    {
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        scenarioScreen.SetActive(true);
        little.enabled = true;
    }

    private IEnumerator Change_MainScreen(Image img, string str)
    {
        Debug.Log("フェードイン" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        imageLoadings.AddList(img, str);
        scenarioScreen.SetActive(true);
        little.enabled = true;
    }

    private IEnumerator Change_MainScreen(GameObject obj, GameObject obj2)
    {
        Debug.Log("フェードイン" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        obj.SetActive(true);
        obj2.SetActive(false);
        scenarioScreen.SetActive(true);
        little.enabled = true;
    }

    private IEnumerator Change_MainScreen(GameObject obj)
    {
        Debug.Log("フェードイン" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        obj.SetActive(true);
        scenarioScreen.SetActive(true);
        little.enabled = true;
    }
}
