using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SetDisplayImage : MonoBehaviour,IUpdateManager
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
    Image charaImage;
    [SerializeField, Header("シナリオ背景")]
    Image backGroundImage;
    [SerializeField]
    ImageTransparencyAnimation charaAnimation;
    [SerializeField]
    ScenarioManager scenarioManager;

    bool fadeCheck = false;

    string past  = "";

    AsyncOperationHandle<Sprite> sprite;
    
    WaitForSeconds w2;
        

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
        w2 = new WaitForSeconds(0.2f);
        iDatas = new string[images.Length];
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (backGroundImage.sprite.name == "Black(Clone)")fadeCheck = true;
        
        if (scenarioManager.LoadCheck)
        {
            scenarioManager.LoadCheck = false;
            
            for (int i = 0; i < images.Length; i++)
            {
                if (iDatas[i] != "" && iDatas[i] != "NONE")
                {
                    if (iDatas[i] != past)
                    {
                        charaAnimation.enabled = false;
                        ImageLoading.ImageLoadingAsync(images[i], StringComponent.AddString(pathName, iDatas[i]),sprite);
                        past = iDatas[i];
                    }
                }

                if (iDatas[i] == "NONE")
                {
                    charaAnimation.enabled = false;
                }
                else
                {
                    StartCoroutine(WaitLoad());
                }
            }
        }
    }

    private IEnumerator WaitLoad()
    {
        string s = iDatas[1] + "(Clone)";

        yield return w2;

        if (charaImage.sprite.name == s.Replace(".png", ""))
        {
            charaAnimation.enabled = false;
            charaAnimation.enabled = true;
        }
    }
}