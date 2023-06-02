using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ImageLoadings : MonoBehaviour
{
    [SerializeField] List<Image> images;
    [SerializeField] List<string> names;

    AsyncOperationHandle<Sprite> sprite;

    void Start() 
    {
        //UpdateManager.Instance.Bind(this, FrameControl.ON);

        for (int i = 0; i < images.Count; i++)
        {
            ImageLoading.ImageLoadingAsync(images[i], names[i],sprite);
        }
    }

    public void AddList(Image img,string pathNames)
    {
        images.Add(img);
        names.Add(pathNames);

        for (int i = 0; i < images.Count; i++)
        {
            ImageLoading.ImageLoadingAsync(images[i], names[i],sprite);
        }
    }

    public void SetImage(int index,string pathName)
    {
        names[index] = pathName;

        for (int i = 0; i < images.Count; i++)
        {
            ImageLoading.ImageLoadingAsync(images[i], names[i],sprite);
        }
    }
}
    