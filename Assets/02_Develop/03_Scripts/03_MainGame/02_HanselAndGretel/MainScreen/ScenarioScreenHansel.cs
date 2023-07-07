using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using DesignPattern;
using NJsonLoader;
using UnityEngine.Rendering;

public enum ScenarioSceneHansel
{
    introduction,

    inspectFrontDoor,

    shelfCipherAnswer,

    examineTheDiary,

    examineThePhoto,

    examineShelf2,

    checkBucket,

    pokerGet,

    grannykitchen,
    //水窯
    waterKiln,

    bucketGet,

    bucketOfWater,

    bonFire,

    fireFighting,

    grandMatherFurnace,

    noMatch,

    keyGet,

    happyEnd,

    matchGet,

    haveAMatch,

    trueEnd,

    badEnd,
}
public class ScenarioScreenHansel : MonoBehaviour, IUpdateManager
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

        [SerializeField]
        Volume volume;

        [SerializeField]
        GameOver_Hansel gameOver;

        [SerializeField, Header("フェードインの時間")]
        float timer;
        [SerializeField, Header("シナリオの場面")]
        ScenarioSceneHansel scenarioScene;

        ScenarioState scenarioState;

        bool justOnce = true;
        bool justOnce2 = true;

        public ScenarioSceneHansel ScenarioPattarn
        {
            get { return scenarioScene; }
            set { scenarioScene = value; }
        }

        bool check = true;
        bool flag = false;
        int save;

        string imageSave;
        string pastImage;

        private void OnEnable()
        {
            justOnce = true;
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

            if (justOnce)
            {
                justOnce = false;

                StartCoroutine(FadeWait());
                mainScreen.SetActive(false);
                volume.enabled = false;
                SoundManager.Instance.PlayBGM(1, true);
                SoundManager.Instance.FadeOut_BGM(1f);

                scenarioState = new ScenarioState();
                scenarioState = ServiceLocator<IJsonLoader>.Instance.LoadStatusData<ScenarioState>("ScenarioState");

                scenarioScene = scenarioState.scenarioSceneHansel;

                switch (scenarioScene)
                {

                    case ScenarioSceneHansel.introduction:

                        scenariosManager.PlayScenario(5,21);

                        break;

                    case ScenarioSceneHansel.inspectFrontDoor:

                        scenariosManager.PlayScenario(28,29);

                        break;

                    case ScenarioSceneHansel.shelfCipherAnswer:

                        scenariosManager.PlayScenario(53,54);

                        break;

                    case ScenarioSceneHansel.examineTheDiary:

                        scenariosManager.PlayScenario(61,90);

                        break;

                    case ScenarioSceneHansel.examineThePhoto:

                        scenariosManager.PlayScenario(94,95);

                        break;

                    case ScenarioSceneHansel.examineShelf2:

                    scenariosManager.PlayScenario(99,104);

                        break;

                    case ScenarioSceneHansel.grannykitchen:

                        scenariosManager.PlayScenario(125,125);

                        break;


                    case ScenarioSceneHansel.checkBucket:

                        scenariosManager.PlayScenario(110,112);

                        break;

    
                    case ScenarioSceneHansel.pokerGet:

                        scenariosManager.PlayScenario(149,149);

                        break;

                    case ScenarioSceneHansel.waterKiln:

                        scenariosManager.PlayScenario(155,155);

                        break;

                    case ScenarioSceneHansel.bucketGet:

                        scenariosManager.PlayScenario(115,116);

                        break;

                    case ScenarioSceneHansel.bucketOfWater:

                        scenariosManager.PlayScenario(158,158);

                        break;

                    case ScenarioSceneHansel.bonFire:

                        scenariosManager.PlayScenario(164,165);

                        break;

                    case ScenarioSceneHansel.fireFighting:

                        scenariosManager.PlayScenario(168,173);

                        break;

                    case ScenarioSceneHansel.grandMatherFurnace:

                        scenariosManager.PlayScenario(185,191);

                        break;

                    case ScenarioSceneHansel.noMatch:

                        scenariosManager.PlayScenario(197,199);

                       break;

                    case ScenarioSceneHansel.keyGet:

                        scenariosManager.PlayScenario(209,210);

                        break;

                     case ScenarioSceneHansel.happyEnd:

                        scenariosManager.PlayScenario(240, 252);
                        
                        break;

                    case ScenarioSceneHansel.matchGet:

                        scenariosManager.PlayScenario(132,134);

                        break;

                    case ScenarioSceneHansel.haveAMatch:

                        scenariosManager.PlayScenario(202,205);

                        break;

                    case ScenarioSceneHansel.trueEnd:

                        scenariosManager.PlayScenario(257,280);

                        break;

                    case ScenarioSceneHansel.badEnd:

                        scenariosManager.PlayScenario(289,310);

                        break;
                }
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
                if (gameOver.GameEnd && justOnce2)
                {
                    justOnce2 = false;
                    SceneManager.Instance.SceneLoadingAsync("title");
                }
                else if (scenarioState.happyEndHansel && justOnce2)
                {
                    justOnce2 = false;
                    SceneManager.Instance.SceneLoadingAsync("title");
                }
                else if (scenarioState.trueEndHansel && justOnce2)
                {
                    justOnce2 = false;
                    SceneManager.Instance.SceneLoadingAsync("EndRollScreen_Hansel");
                }
                else
                {
                    fade.FadeIn(timer, () =>
                    {
                        if (fadeImage.CutoutRange == 1f)
                        {
                            SoundManager.Instance.FadeIn_BGM();
                            mainScreen.gameObject.SetActive(true);
                            this.gameObject.SetActive(false);
                        }
                    });
                }
            }
        }

        IEnumerator FadeWait()
        {
            yield return new WaitForSeconds(1f);
            fade.FadeOut(1f);
        }
}
