using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Playables;
using NJsonLoader;
using UnityEngine.UI;

public class ItemBox_Little : MonoBehaviour, IUpdateManager
{
    [SerializeField]
    GameObject scenarioScreen;

    [SerializeField]
    Image item1, item2,item4;

    [SerializeField]
    Fade fade;

    [SerializeField]
    FadeImage fadeImage;

    [SerializeField]
    ScenarioScreenLittle little;

    [SerializeField]
    PlayableDirector diaryLoading_Open;

    [SerializeField]
    RayCastScript_Little rayCastScript_Little;

    void Start()
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

    }

    public void GrandMatherDiaryLoading()
    {
        if(item2.sprite.name == "ê‘Ç∏Ç´ÇÒì˙ãL(ï¬)(Clone)")
        {
            diaryLoading_Open.enabled = false;
            diaryLoading_Open.enabled = true;
        }
    }

    public void FamilyPhotoLoading()
    {
        if(item4.sprite.name == "â∆ë∞é ê^ï\(Clone)")
        {
            rayCastScript_Little.ScenarioLoad(ScenarioSceneLittle.familyPhpto_Load);
        }
    }
}
