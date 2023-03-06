using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class SceneController : MonoBehaviour
{
    private int OnSelectButton = 0;
    public void OnAkazukin()
    {
        OnSelectButton = 1;
        //赤ずきんシーン遷移
        //SceneManager.LoadScene("LittleRedRidingHood");
        //SceneManager.Instance.SceneLoadingAsync("LittleRedRidingHood");
    }
    public void OnHengure()
    {
        OnSelectButton = 2;
        //ヘン&グレシーン遷移
        //SceneManager.LoadScene("HanselAndGretel");
        //SceneManager.Instance.SceneLoadingAsync("HanselAndGretel");
    }
    public void OnPeter()
    {
        OnSelectButton = 3;
        //ピーターシーン遷移
        //SceneManager.LoadScene("PeterPan");
        //SceneManager.Instance.SceneLoadingAsync("PeterPan");
    }

    public void OnTitle()
    {
        //タイトルシーン遷移
        //SceneManager.LoadScene("title");
        SceneManager.Instance.SceneLoadingAsync("title");
    }

    public void OnDecideBoutton()
    {
        if (OnSelectButton == 1)
        {
            Debug.Log("1");
            SceneManager.Instance.SceneLoadingAsync("LittleRedRidingHood");
        }
        if (OnSelectButton == 2)
        {
            Debug.Log("2");
            SceneManager.Instance.SceneLoadingAsync("HanselAndGretel");
        }
        if (OnSelectButton == 3)
        {
            Debug.Log("3");
            SceneManager.Instance.SceneLoadingAsync("PeterPan");
        }
    }
}
