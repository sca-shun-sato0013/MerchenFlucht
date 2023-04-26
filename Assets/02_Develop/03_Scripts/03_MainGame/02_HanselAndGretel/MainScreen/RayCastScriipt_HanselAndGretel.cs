using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using NJsonLoader;
using UnityEngine.UI;
using UnityEngine.Playables;

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
    Image item3;

    [SerializeField]
    GameObject cipherScreen_Door,shelf,poker;

    [SerializeField,Header("ドアの暗号表示、非表示")]
    PlayableDirector cipherScreen_Door_TimeLine;

    [SerializeField,Header("棚の暗号表示、非表示")]
    PlayableDirector cipherScreen_shelf,cipherReScreen_shelf;

    [SerializeField, Header("火かき棒の暗号表示、非表示")]
    PlayableDirector cipherScreen_Poker,cipherReScreen_Poker;
    
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

        flagCandles = new bool[candles.Length];
        flagCandles[0] = true;
        flagCandles[1] = true;
        flagCandles[2] = true;
        flagCandles[3] = true;
        flagCandles[4] = true;
        flagCandles[5] = true;

        scenarioState = new ScenarioState();
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
        //Debug.Log(flagCandles[1]);

        //Rayを飛ばすかどうか
        if (check.RayCastON)
        {



            if (MobileInput.InputState(TouchPhase.Began)) // 左クリック
            {
                Touch touch = Input.GetTouch(0);

                Ray ray = Camera.main.ScreenPointToRay(touch.position); // Rayを生成


                RaycastHit hit;

                /*            RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, (Vector2)ray.direction);
                            Debug.Log(hit2D.collider.gameObject.name);
                            if (hit2D.collider)
                            {
                                for (int i = 0; i < candles.Length; i++)
                                {
                                    if (hit2D.collider.gameObject.name == "Candle" + (i + 1).ToString())
                                    {
                                        candles[i].gameObject.SetActive(true);
                                        flagCandles[i] = false;
                                    }

                                    if (hit2D.collider.gameObject.name == StringComponent.AddString("Candle", (i + 1).ToString(), "Fire"))
                                    {
                                        candles[i].gameObject.SetActive(false);
                                        flagCandles[i] = true;
                                    }
                                }
                            }*/



                /*            if (hit2D.collider.gameObject.name == "Candle2")
                            {

                                    flag = false;
                                    Debug.Log("通った");
                                    candles[1].gameObject.SetActive(true);



                            }

                            if (hit2D.collider.gameObject.name == "Candle2Fire")
                            {

                                    flag = false;
                                    Debug.Log("通った");
                                    candles[1].gameObject.SetActive(false);



                            }*/

                /*            if (hit2D.collider.gameObject.name == "Candle3")
                            {
                                candles[2].gameObject.SetActive(true);
                            }
                            if (hit2D.collider.gameObject.name == "Candle4")
                            {
                                candles[3].gameObject.SetActive(true);
                            }
                            if (hit2D.collider.gameObject.name == "Candle5")
                            {
                                candles[4].gameObject.SetActive(true);
                            }
                            if (hit2D.collider.gameObject.name == "Candle6")
                            {
                                candles[5].gameObject.SetActive(true);
                            }*/

                if (Physics.Raycast(ray, out hit)) // Rayを投射
                {
                    if (hit.collider.gameObject.name == "FrontDoor")
                    {
                        fade.FadeIn(2f);

                        //imageLoadings.AddList(items[1], "Assets/LoadingDatas/ScenarioDatas/PeterPan/メモ1.png");

                        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.inspectFrontDoor;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    }

                    if (hit.collider.gameObject.name == "DoorToKitchen")
                    {
                        cipherScreen_Door.SetActive(true);
                        cipherScreen_Door_TimeLine.enabled = false;
                        cipherScreen_Door_TimeLine.enabled = true;
                    }

                    if (hit.collider.gameObject.name == "棚")
                    {
                        shelf.SetActive(true);
                        cipherScreen_shelf.enabled = false;
                        cipherScreen_shelf.enabled = true;
                    }

                    if (hit.collider.gameObject.name == "棚.001")
                    {
                        fade.FadeIn(2f);

                        imageLoadings.AddList(item3, "Assets/LoadingDatas/ScenarioDatas/HanselAndGretel/H&G絵本(閉).png");

                        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.examineShelf2;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
                    }

                    if (hit.collider.gameObject.name == "Bucket")
                    {
                        fade.FadeIn(2f);

                        scenarioState.scenarioSceneHansel = ScenarioSceneHansel.checkBucket;
                        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
                        StartCoroutine(Change_MainScreen());
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

    public void Scenario(ScenarioSceneHansel scenario ,Image img,string str)
    {
        fade.FadeIn(2f);

        scenarioState.scenarioSceneHansel = scenario;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen(img,str));
    }

    private IEnumerator Change_MainScreen()
    {
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        scenarioScreen.SetActive(true);
        hansel.enabled = true;
    }

    private IEnumerator Change_MainScreen(Image img,string str)
    {
        Debug.Log("フェードイン" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        imageLoadings.AddList(img,str);
        scenarioScreen.SetActive(true);
        hansel.enabled = true;
    }

    private IEnumerator Change_MainScreen(GameObject obj, GameObject obj2)
    {
        Debug.Log("フェードイン" + fadeImage.CutoutRange);
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        obj.SetActive(true);
        obj2.SetActive(false);
        scenarioScreen.SetActive(true);
        hansel.enabled = true;
    }
}
