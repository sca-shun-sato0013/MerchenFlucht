using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CabinetScreen : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    InputField inputField;

    [SerializeField]
    PlayableDirector cabinet_Close;

    [SerializeField]
    RayCastScript_Little rayCastScript_Little;

    [SerializeField,Header("Item2")]
    Image item2;

    [SerializeField]
    Text[] texts;
    
    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;
    }

    public void OnCabinetClick()
    {
        string str = inputField.text.ToUpper();

        char[] charaArray = inputField.text.ToUpper().ToCharArray();

        if (charaArray.Length != 5) return;

        for (int i = 0; i < charaArray.Length; i++)
        {
            texts[i].text = charaArray[i].ToString();
        }

        inputField.text = "";

        StartCoroutine(Wait(str));
    }

    public void ReturnButton()
    {
        cabinet_Close.enabled = false;
        cabinet_Close.enabled = true;

        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(1.0f);

        this.gameObject.SetActive(false);
    }
    IEnumerator Wait(string str)
    {
        yield return new WaitForSeconds(1.5f);

        if (str == "THREE")
        {
            rayCastScript_Little.ScenarioLoad_ItemGet(ScenarioSceneLittle.grandMatherDiary,item2, "Assets/LoadingDatas/ScenarioDatas/LittleRedRidingHood/Ô‚¸‚«‚ñ“ú‹L(•Â).png");
        }

        yield return new WaitForSeconds(1.5f);

        this.gameObject.SetActive(false);
    }
}
    