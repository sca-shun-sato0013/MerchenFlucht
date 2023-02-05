using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class SceneController : MonoBehaviour
{
    public void OnAkazukin()
    {
        //赤ずきんシーン遷移
        //SceneManager.LoadScene("LittleRedRidingHood");
        SceneManager.Instance.SceneLoadingAsync("LittleRedRidingHood");
    }
    public void OnHengure()
    {
        //ヘン&グレシーン遷移
        //SceneManager.LoadScene("HanselAndGretel");
        SceneManager.Instance.SceneLoadingAsync("HanselAndGretel");
    }
    public void OnPita()
    {
        //ピーターシーン遷移
        //SceneManager.LoadScene("PeterPan");
        SceneManager.Instance.SceneLoadingAsync("PeterPan");
    }

    public void OnTitle()
    {
        //タイトルシーン遷移
        //SceneManager.LoadScene("title");
        SceneManager.Instance.SceneLoadingAsync("title");
    }
}
