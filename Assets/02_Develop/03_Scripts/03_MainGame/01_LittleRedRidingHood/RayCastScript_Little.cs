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
    [SerializeField]
    GameObject scenarioScreen;
    [SerializeField]
    ScenarioScreenLittle little;

    [SerializeField]
    Image item3, item4, item5, item6;

    [SerializeField]
    ShaftRotation_Little check;

    ScenarioState scenarioState;

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
                    if (hit.collider.gameObject.name == "FrontDoor")
                    {
                        if (item6.sprite.name == "�G�{�ɋ��܂��Ă錮(Clone)")
                        {
                            if (item5.sprite.name == "�}�b�`(Clone)")
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

    public void ScenarioItemGet(ScenarioSceneHansel scenario, Image img, string str)
    {
        fade.FadeIn(2f);

        scenarioState.scenarioSceneHansel = scenario;
        ServiceLocator<IJsonLoader>.Instance.SaveStatusData(scenarioState, "ScenarioState");
        StartCoroutine(Change_MainScreen(img, str));
    }

    private IEnumerator Change_MainScreen()
    {
        yield return new WaitUntil(() => fadeImage.CutoutRange == 1f);

        scenarioScreen.SetActive(true);
        little.enabled = true;
    }

    private IEnumerator Change_MainScreen(Image img, string str)
    {
        Debug.Log("�t�F�[�h�C��" + fadeImage.CutoutRange);
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
