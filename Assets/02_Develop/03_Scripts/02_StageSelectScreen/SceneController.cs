using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class SceneController : MonoBehaviour
{
    public void OnAkazukin()
    {
        //�Ԃ�����V�[���J��
        //SceneManager.LoadScene("LittleRedRidingHood");
        SceneManager.Instance.SceneLoadingAsync("LittleRedRidingHood");
    }
    public void OnHengure()
    {
        //�w��&�O���V�[���J��
        //SceneManager.LoadScene("HanselAndGretel");
        SceneManager.Instance.SceneLoadingAsync("HanselAndGretel");
    }
    public void OnPita()
    {
        //�s�[�^�[�V�[���J��
        //SceneManager.LoadScene("PeterPan");
        SceneManager.Instance.SceneLoadingAsync("PeterPan");
    }

    public void OnTitle()
    {
        //�^�C�g���V�[���J��
        //SceneManager.LoadScene("title");
        SceneManager.Instance.SceneLoadingAsync("title");
    }
}
