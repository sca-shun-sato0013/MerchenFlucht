using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnAkazukin()
    {
        //�Ԃ�����V�[���J��
        SceneManager.LoadScene("LittleRedRidingHood");
    }
    public void OnHengure()
    {
        //�w��&�O���V�[���J��
        SceneManager.LoadScene("HanselAndGretel");
    }
    public void OnPita()
    {
        //�s�[�^�[�V�[���J��
        SceneManager.LoadScene("PeterPan");
    }
}
