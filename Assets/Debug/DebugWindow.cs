using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CommonlyUsed;
using GameManager;

public class DebugWindow : MonoBehaviour
{
    [SerializeField]
    private Text textUI = null;
    
    [SerializeField]
    ScrollRect scrollRect;

    [SerializeField]
    InputField inputField;
    
    [SerializeField]
    ScenarioScreenPeterPan screen;
    
    [SerializeField]
    GameObject mainScreen, scenarioScreen;

    private int logCount = 0;

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    /// <summary>
    /// 内容を書き変えて使う
    /// </summary>
    public void InputCommand()
    {
        switch(inputField.text)
        {
            case "system call stopUpdate":
                UpdateManager.Instance.FrameStop();
                break;
            case "system call startUpdate":
                UpdateManager.Instance.FrameStart();
                break;
            case "system call stopTime":
                Time.timeScale = 0f;
                break;
            case "system call scene title":
                SceneManager.Instance.SceneLoadingAsync("title");
                break;
            case "system call scene stageSelect":
                SceneManager.Instance.SceneLoadingAsync("StageSelectScene");
                break;
            case "system call scene littleRed":
                SceneManager.Instance.SceneLoadingAsync("LittleRedRidingHood");
                break;
            case "system call scene hansel":
                SceneManager.Instance.SceneLoadingAsync("HanselAndGretel");
                break;
            case "system call scene peterPan":
                SceneManager.Instance.SceneLoadingAsync("PeterPan");
                break;
            case "system call scene endScreen":
                SceneManager.Instance.SceneLoadingAsync("EndScreen");
                break;
            case "system call scene endRoll":
                SceneManager.Instance.SceneLoadingAsync("EndRollScreen");
                break;
            case "system call main screen":
                mainScreen.SetActive(true);
                scenarioScreen.SetActive(false);
                break;
            case "system call scenario screen":
                mainScreen.SetActive(false);
                scenarioScreen.SetActive(true);
                break;
            case "system set scenario peterPan introduction":
                screen.ScenarioPattarn = ScenarioScenePeter.introduction;
                break;
            case "system set scenario peterPan examineTheShelf":
                screen.ScenarioPattarn = ScenarioScenePeter.examineTheShelf;
                break;
            case "system set scenario peterPan wallPaper":
                screen.ScenarioPattarn = ScenarioScenePeter.wallPaper;
                break;
            case "system set scenario peterPan displayMemo1FromTheItemCcolumn":
                screen.ScenarioPattarn = ScenarioScenePeter.displayMemo1FromTheItemCcolumn;
                break;
            case "system set scenario peterPan dontHaveMatch":
                screen.ScenarioPattarn = ScenarioScenePeter.dontHaveMatch;
                break;
            case "system set scenario peterPan haveAMatch":
                screen.ScenarioPattarn = ScenarioScenePeter.haveAMatch;
                break;
            case "system set scenario peterPan shadowPointing":
                screen.ScenarioPattarn = ScenarioScenePeter.shadowPointing;
                break;
            case "system set scenario peterPan examineTheChair":
                screen.ScenarioPattarn = ScenarioScenePeter.examineTheChair;
                break;
            case "system set scenario peterPan shadowPointingToTheWall":
                screen.ScenarioPattarn = ScenarioScenePeter.shadowPointingToTheWall;
                break;
            case "system set scenario peterPan examineAfterTheShadowAppears":
                screen.ScenarioPattarn = ScenarioScenePeter.examineAfterTheShadowAppears;
                break;
            case "system set scenario peterPan examineShadows":
                screen.ScenarioPattarn = ScenarioScenePeter.examineShadows;
                break;
            case "system set scenario peterPan examineThePainting":
                screen.ScenarioPattarn = ScenarioScenePeter.examineThePainting;
                break;
            case "system set scenario peterPan checkForMistakes":
                screen.ScenarioPattarn = ScenarioScenePeter.checkForMistakes;
                break;
            case "system set scenario peterPan examineTheRat":
                screen.ScenarioPattarn = ScenarioScenePeter.examineTheRat;
                break;
            case "system set scenario peterPan examineTheKitchenFromRats":
                screen.ScenarioPattarn = ScenarioScenePeter.examineTheKitchenFromRats;
                break;
            case "system set scenario peterPan examineTheMouseWithTheCheese":
                screen.ScenarioPattarn = ScenarioScenePeter.examineTheMouseWithTheCheese;
                break;
                
            default:
                Debug.Log("対応するコマンドがありません");
                break;
        }
    }
    
    private void HandleLog(string logText, string stackTrace, LogType type)
    {
        //文字列が空文字(null)か判定
        if (string.IsNullOrEmpty(logText))
        {
            return;
        }

        if (logCount > 200)
        {
            int index = textUI.text.IndexOf("\n");
            textUI.text = textUI.text.Substring(index + 1);
        }
        else
        {
            logCount++;
        }

        textUI.text += logText;
        textUI.text += "\n";

        scrollRect.verticalNormalizedPosition = 0;
    }
}
