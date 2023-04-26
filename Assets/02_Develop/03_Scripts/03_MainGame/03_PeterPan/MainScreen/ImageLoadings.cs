using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;

public class ImageLoadings : MonoBehaviour
{
    [SerializeField] List<Image> images;
    [SerializeField] List<string> names;

    void Start() 
    {
        //UpdateManager.Instance.Bind(this, FrameControl.ON);

        for (int i = 0; i < images.Count; i++)
        {
            ImageLoading.ImageLoadingAsync(images[i], names[i]);
        }
    }

    public void AddList(Image img,string pathNames)
    {
        images.Add(img);
        names.Add(pathNames);

        for (int i = 0; i < images.Count; i++)
        {
            ImageLoading.ImageLoadingAsync(images[i], names[i]);
        }
    }

    public void SetImage(int index,string pathName)
    {
        names[index] = pathName;

        for (int i = 0; i < images.Count; i++)
        {
            ImageLoading.ImageLoadingAsync(images[i], names[i]);
        }
    }
}
    