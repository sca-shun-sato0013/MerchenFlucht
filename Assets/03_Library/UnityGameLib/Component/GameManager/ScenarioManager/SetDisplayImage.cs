using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using UnityEngine.UI;



public class SetDisplayImage : MonoBehaviour,IUpdateManager
{
    [SerializeField,Header("入力端末")]
    InputType inputType;

    [SerializeField,Header("表示させる画像数")]
    Image[] images;

    [SerializeField,Header("画像のファイル名取得")]
    string[] iDatas;

    [SerializeField]
    ScenarioManager scenarioManager;

    bool If = true;

    public string[] ImageDatas
    {
        get { return iDatas; }
       internal set { iDatas = value; }
    }

    void Start()
    {
        iDatas = new string[images.Length];
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
/*        switch(inputType)
        {
            case InputType.InputPC:
                If = MobileInput.InputState(TouchPhase.Began);
                break;

            case InputType.MobileInput:
                If = Input.GetMouseButtonDown(0);
                break;

        }*/

        if(scenarioManager.LoadCheck)
        {
            scenarioManager.LoadCheck = false;

            for (int i = 0; i < images.Length; i++)
            {
                Debug.Log("sdf");
                if (iDatas[i] != "")
                {
                    Debug.Log(StringComponent.AddString("Assets/LoadingDatas/ScenarioDatas/", iDatas[i]));
                    ImageLoading.ImageLoadingAsync(images[i], StringComponent.AddString("Assets/LoadingDatas/ScenarioDatas/", iDatas[i]));
                }
            }
        }       
    }
}