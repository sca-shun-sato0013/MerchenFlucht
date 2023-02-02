using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using UnityEngine.UI;



public class SetDisplayCharaImage : MonoBehaviour,IUpdateManager
{

    [SerializeField,Header("�\��������L�����N�^�[��")]
    Image[] images;

    [SerializeField,Header("�L�����N�^�[�摜�̖��O�擾")]
    string[] cDatas;

    bool flag = true;
    internal string[] charaImageDatas
    {
        get { return cDatas; }
        set { cDatas = value; }
    }

    void Start()
    {
        ImageLoading.ImageLoadingAsync(images[0], "Assets/LoadingDatas/ScenarioDatas/w1.png");
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (cDatas[i] != "" && flag)
            {
                flag = false;
                ImageLoading.ImageLoadingAsync(images[i],StringComponent.AddString("Assets/LoadingDatas/ScenarioDatas/",cDatas[i]));
            }
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            flag = true;
        }
    }
}
