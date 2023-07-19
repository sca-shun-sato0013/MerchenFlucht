using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Playables;
using System.IO;

public class VersionCheck : MonoBehaviour,IUpdateManager
{
    [SerializeField, Header("google�X�v���b�g�V�[�g��ID")]
    string SHEET_ID = "ID������";
    [SerializeField, Header("�V�[�g��")]
    string SHEET_NAME = "�V�[�g��������";
    //google�X�v���b�g�V�[�g�̃f�[�^�ۊǗp
    string[][] arrayTwo;

    [SerializeField]
    GameObject updateScreen;

    [SerializeField, Header("���݂̃o�[�W����")]
    string currentVer = null;

    bool updateCheck = false;

    bool flag = false;

    public bool UpdateCheck => updateCheck;

    [SerializeField]
    Text text;

    [SerializeField]
    PlayableDirector timeLine;

    private void Start()
    {
        text.text = "Ver " + currentVer;
        StartCoroutine(Method(SHEET_NAME));
        UpdateManager.Instance.Bind(this,FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
       
    }

    private IEnumerator Method(string _SHEET_NAME)
    {

        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + SHEET_ID + "/gviz/tq?tqx=out:csv&sheet=" + _SHEET_NAME);
        yield return request.SendWebRequest();

        switch (request.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log("<color=Cyan><size=13><b>���N�G�X�g��...</b></size></color>");
                break;

            case UnityWebRequest.Result.Success:
                flag = true;
                Debug.Log("<color=Lime><size=13><b>���N�G�X�g����!</b></size></color>");
                break;

            ///<summary>
            ///�`���l���Ƃ͈��pURL
            /// https://e-words.jp/w/%E3%83%81%E3%83%A3%E3%83%8D%E3%83%AB.html#:~:text=%E3%83%86%E3%83%AC%E3%83%93%E3%81%AE%E3%83%81%E3%83%A3%E3%83%B3%E3%83%8D%E3%83%AB%E3%81%AE%E3%82%88%E3%81%86,%E3%82%92%E8%A1%A8%E3%81%99%E3%81%93%E3%81%A8%E3%82%82%E3%81%82%E3%82%8B%E3%80%82
            /// </summary>
            case UnityWebRequest.Result.ConnectionError:
                Debug.LogError("<color=Red><size=13><b>�T�[�o�[�Ƃ̒ʐM�Ɏ��s���܂����B���N�G�X�g���ڑ��ł��Ȃ��������A���S�ȃ`���l�����m���ł��Ȃ������\��������܂��B</b></size></color>");
                break;

            ///<summary>
            ///�v���g�R���Ƃ͈��pURL(�����ł���https�̂��Ƃł��B)
            ///�@https://www.keyence.co.jp/ss/general/iot-glossary/protocol.jsp#:~:text=%E3%83%97%E3%83%AD%E3%83%88%E3%82%B3%E3%83%AB%E3%82%88%E3%81%BF%EF%BC%9A%E3%81%B7%E3%82%8D%E3%81%A8%E3%81%93%E3%82%8B%E3%80%81%E8%8B%B1%E5%AD%97%EF%BC%9A,%E3%81%8C%E5%8F%AF%E8%83%BD%E3%81%AB%E3%81%AA%E3%82%8A%E3%81%BE%E3%81%99%E3%80%82
            /// </summary>
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("<color=Red><size=13><b>�T�[�o�[���G���[������Ԃ��܂����B���N�G�X�g�̓T�[�o�[�Ƃ̒ʐM�ɐ������܂������A�ڑ��v���g�R���Œ�`����Ă���G���[���󂯎��܂����B</b></size></color>");
                break;

            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("<color=Red><size=13><b>�f�[�^�������ɃG���[���������܂����B���N�G�X�g�̓T�[�o�[�Ƃ̒ʐM�ɐ������܂������A��M�����f�[�^�̏������ɃG���[���������܂����B�f�[�^���j�����Ă��邩�A�������`���ł͂���܂���B</b></size></color>");
                break;

            //�����̒l���A�Ăяo���ꂽ���\�b�h�Œ�`����Ă��鋖�e�͈͊O�ł���ꍇ�ɃX���[������O�B(microsoft�����p)
            default: throw new ArgumentOutOfRangeException();

        }

        arrayTwo = ConvertCSVtoArray(request.downloadHandler.text);
        Version();
    }

    private string[][] ConvertCSVtoArray(string s)
    {
        StringReader reader = new StringReader(s);
        reader.ReadLine();

        List<string[]> rows = new List<string[]>();
        while (reader.Peek() >= 0)
        {
            string line = reader.ReadLine();        // ��s���ǂݍ���
            string[] elements = line.Split(',');    // �s�̃Z����,�ŋ�؂���
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            rows.Add(elements);
        }
        return rows.ToArray();
    }


    public void Version()
    {
        if (arrayTwo[0][0] != currentVer)
        {
            updateScreen.SetActive(true);
            updateCheck = false;
            timeLine.enabled = false;
            timeLine.enabled = true;
        }
        else
        {
            Debug.Log("�ʂ���");
            updateCheck = true;
        }
    }

    public void YesButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.DefaultCompany.MerchenFlucht");
    }

    public void NoButton()
    {
        updateScreen.SetActive(false);
    }
}