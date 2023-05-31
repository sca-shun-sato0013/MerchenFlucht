using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using UnityEngine.UI;



public class SetDisplayImage : MonoBehaviour, IUpdateManager
{
    [SerializeField, Header("入力端末")]
    InputType inputType;

    [SerializeField, Header("Addressablesの読み込みフォルダのpath")]
    string pathName;

    [SerializeField, Header("表示させる画像数")]
    Image[] images;

    [SerializeField, Header("画像のファイル名取得")]
    string[] iDatas;

    [SerializeField, Header("キャラの表示、非表示")]
    GameObject charaImage;

    [SerializeField]
    ScenarioManager scenarioManager;

    bool fadeCheck = false;

    WaitForSeconds w;
    public string[] ImageDatas
    {
        get { return iDatas; }
        internal set { iDatas = value; }
    }

    public bool FadeCheck { 
        
        get => fadeCheck; 
        set => fadeCheck = value; 
    }

    void Start()
    {
        w = new WaitForSeconds(0.3f);
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
                if (iDatas[i] != "" && iDatas[i] != "NONE")
                {
                    
                    ImageLoading.ImageLoadingAsync(images[i], StringComponent.AddString(pathName,iDatas[i]));
                    StartCoroutine(WaitFadeTime());
                }

                if (iDatas[i] == "NONE")
                {
                    charaImage.SetActive(false);
                }
                else
                {
                    charaImage.SetActive(true);
                }
            }
        }       
    }

    private IEnumerator WaitFadeTime()
    {
        yield return w;
        fadeCheck = true;
    }
}