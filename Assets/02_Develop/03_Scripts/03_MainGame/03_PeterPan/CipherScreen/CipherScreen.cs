using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CipherScreen : MonoBehaviour,IUpdateManager
{
    [SerializeField]
    InputField inputField;

    [SerializeField]
    PlayableDirector cipher_TimeLine;

    [SerializeField, Header("�Í���ʂ̉�ʐ���")]
    PlayableDirector cipherScreenOpen_TimeLine, cipherScreenClose_TimeLine;

    [SerializeField, Header("�T����Ԃɖ߂�")]
    PlayableDirector keyBox_TimeLine, keyBoxRe_TimeLine;

    [SerializeField, Header("KeyBox�J��")]
    PlayableDirector keyBox_Open;

    [SerializeField]
    BoxCollider keyBox_Collider;

    [SerializeField, Header("�E�F���f�B�[�̃e�L�X�g")]
    Text explanatoryText,incorrectAnswer,correctAnswer;

    [SerializeField, Header("�Í��\����Text")]
    Text[] texts;  

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        
    }

    public void OnCipherClick()
    {
        string str = inputField.text.ToUpper();

        char[] charaArray = inputField.text.ToUpper().ToCharArray();

        if (charaArray.Length != 6) return;

        cipher_TimeLine.enabled = false;
        cipher_TimeLine.enabled = true;

        for(int i = 0; i < charaArray.Length; i++)
        {
            texts[i].text = charaArray[i].ToString();
        }

        StartCoroutine(Wait(str));
        inputField.text = "";
    }

    public void OnClickClose()
    {
        inputField.text = "";
        cipherScreenOpen_TimeLine.enabled = false;

        cipherScreenClose_TimeLine.enabled = false;
        cipherScreenClose_TimeLine.enabled = true;

        keyBox_Collider.enabled = true;
        StartCoroutine(Close());
    }

    IEnumerator Close()
    {
        yield return new WaitForSeconds(1.5f);

        keyBox_TimeLine.enabled = false;
        keyBoxRe_TimeLine.enabled = true;

        yield return new WaitForSeconds(1.5f);

        this.gameObject.SetActive(false);

    }

    IEnumerator Wait(string str)
    {
        yield return new WaitForSeconds(1.5f);

        if(str == "SHADOW")
        {
            explanatoryText.enabled = false;
            incorrectAnswer.enabled = false;
            correctAnswer.enabled = true;

            cipherScreenOpen_TimeLine.enabled = false;

            cipherScreenClose_TimeLine.enabled = false;
            cipherScreenClose_TimeLine.enabled = true;

            StartCoroutine(Open_KeyBox());
        }
        else
        {
            explanatoryText.enabled = false;
            correctAnswer.enabled = false;
            incorrectAnswer.enabled = true;           
        }
    }

    IEnumerator Open_KeyBox()
    {
        yield return new WaitForSeconds(1f);

        keyBox_Open.enabled = true; 
    }
}
    