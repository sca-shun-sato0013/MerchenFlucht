using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnAkazukin()
    {
        //赤ずきんシーン遷移
        SceneManager.LoadScene("LittleRedRidingHood");
    }
    public void OnHengure()
    {
        //ヘン&グレシーン遷移
        SceneManager.LoadScene("HanselAndGretel");
    }
    public void OnPita()
    {
        //ピーターシーン遷移
        SceneManager.LoadScene("PeterPan");
    }
}
