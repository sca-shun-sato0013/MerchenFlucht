using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;

public class ImageLoadings : MonoBehaviour,IUpdateManager
{
    [SerializeField] List<Image> images;
    [SerializeField] List<string> names;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    private void OnEnable()
    {
        for (int i = 0; i < images.Count; i++)
        {
            ImageLoading.ImageLoadingAsync(images[i],names[i]);
        }
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;


    }

    public void AddList(Image img,string pathNames)
    {
        images.Add(img);
        names.Add(pathNames);
    }

    public void SetImage(int index,string pathName)
    {
        names[index] = pathName; 
    }
}
    