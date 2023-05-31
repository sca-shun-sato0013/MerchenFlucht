using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using UnityEngine.UI;



public class SetDisplayImage : MonoBehaviour, IUpdateManager
{
    [SerializeField, Header("���͒[��")]
    InputType inputType;

    [SerializeField, Header("Addressables�̓ǂݍ��݃t�H���_��path")]
    string pathName;

    [SerializeField, Header("�\��������摜��")]
    Image[] images;

    [SerializeField, Header("�摜�̃t�@�C�����擾")]
    string[] iDatas;

    [SerializeField, Header("�L�����̕\���A��\��")]
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