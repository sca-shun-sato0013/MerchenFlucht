using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManager;
using UnityEngine.Networking;
using System.IO;
using DesignPattern;



public class ScenarioManager : Singleton<ScenarioManager>,ISingleton,IUpdateManager
{


    [SerializeField,Header("入力端末")]
    InputType inputType;
    [SerializeField, Header("googleスプレットシートのID")]
    string SHEET_ID = "IDを入れる";

    [SerializeField, Header("シート名")] 
    string SHEET_NAME = "シート名を入れる";

    //文字がテキストに書き込まれる速さ
    private float textInterval = 0f;
    [SerializeField, Header("表示されるテキスト")]
    Text displayText;
    [SerializeField, Header("文字が表示される速さ")]
    float charaSpeed = 0f;
    [SerializeField, Header("話をしているキャラの名前")]
    Text talkingCharaName = null;
    [SerializeField,Header("キャラ画像データ")]
    SetDisplayImage setImage;
    //googleスプレットシートのデータ保管用
    string[][] arrayTwo;
    //話しているキャラの名前保管用
    List<string> charaName;
    //画面に表示するキャラ画像保管用
    List<string> displayCharaImage;
    //効果音se保管用
    List<string> soundSe;
    //文章保管用
    List<string> texts;
    //背景画像保管用
    List<string> backGroundImage;
    //テキスト表示が終わっているかのチェック
    bool checkIfTheStoryIsOver = false;
    //一行の文字数
    int currentCharNum = 0;
    //行数
    int currentLineNum = 0;
    //終わりの行
    int lineIsTheEnd = 0;
    //読み込みのチェック
    bool loadCheck = false;
    public int CurrentLineNum => currentLineNum;
    public bool LoadCheck 
    {
       get {return loadCheck; }
       internal set {loadCheck = value;}
    }

    private void Start()
    {
        
        charaName = new List<string>();
        displayCharaImage = new List<string>();        
        backGroundImage = new List<string>();       
        soundSe = new List<string>();       
        texts = new List<string>();
        
        UpdateManager.Instance.Bind(this, FrameControl.ON);
    }

    public void OnUpdate(double deltaTime)
    {
       if(LineEndCheck()) TextController();
    }

    private IEnumerator Method(string _SHEET_NAME)
    {

        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + SHEET_ID + "/gviz/tq?tqx=out:csv&sheet=" + _SHEET_NAME);
        yield return request.SendWebRequest();

        switch (request.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log("<color=Cyan><size=13><b>リクエスト中...</b></size></color>");
                break;

            case UnityWebRequest.Result.Success:
                Debug.Log("<color=Lime><size=13><b>リクエスト成功!</b></size></color>");
                break;

            ///<summary>
            ///チャネルとは引用URL
            /// https://e-words.jp/w/%E3%83%81%E3%83%A3%E3%83%8D%E3%83%AB.html#:~:text=%E3%83%86%E3%83%AC%E3%83%93%E3%81%AE%E3%83%81%E3%83%A3%E3%83%B3%E3%83%8D%E3%83%AB%E3%81%AE%E3%82%88%E3%81%86,%E3%82%92%E8%A1%A8%E3%81%99%E3%81%93%E3%81%A8%E3%82%82%E3%81%82%E3%82%8B%E3%80%82
            /// </summary>
            case UnityWebRequest.Result.ConnectionError:
                Debug.LogError("<color=Red><size=13><b>サーバーとの通信に失敗しました。リクエストが接続できなかったか、安全なチャネルを確率できなかった可能性があります。</b></size></color>");
                break;

            ///<summary>
            ///プロトコルとは引用URL(ここでいうhttpsのことです。)
            ///　https://www.keyence.co.jp/ss/general/iot-glossary/protocol.jsp#:~:text=%E3%83%97%E3%83%AD%E3%83%88%E3%82%B3%E3%83%AB%E3%82%88%E3%81%BF%EF%BC%9A%E3%81%B7%E3%82%8D%E3%81%A8%E3%81%93%E3%82%8B%E3%80%81%E8%8B%B1%E5%AD%97%EF%BC%9A,%E3%81%8C%E5%8F%AF%E8%83%BD%E3%81%AB%E3%81%AA%E3%82%8A%E3%81%BE%E3%81%99%E3%80%82
            /// </summary>
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("<color=Red><size=13><b>サーバーがエラー応答を返しました。リクエストはサーバーとの通信に成功しましたが、接続プロトコルで定義されているエラーを受け取りました。</b></size></color>");
                break;

            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("<color=Red><size=13><b>データ処理中にエラーが発生しました。リクエストはサーバーとの通信に成功しましたが、受信したデータの処理中にエラーが発生しました。データが破損しているか、正しい形式ではありません。</b></size></color>");
                break;

            //引数の値が、呼び出されたメソッドで定義されている許容範囲外である場合にスローされる例外。(microsoftより引用)
            default: throw new ArgumentOutOfRangeException();

        }

        arrayTwo = ConvertCSVtoArray(request.downloadHandler.text);

        for (int i = 0; i < arrayTwo.Length; i++)
        {
            charaName.Add(arrayTwo[i][0]);

            backGroundImage.Add(arrayTwo[i][1]);

            //一人目
            displayCharaImage.Add(arrayTwo[i][2]);

/*            //二人目
            displayCharaImage.Add(arrayTwo[i][2]);
            //三人目
            displayCharaImage.Add(arrayTwo[i][3]);
            //四人目
            displayCharaImage.Add(arrayTwo[i][4]);
            //五人目
            displayCharaImage.Add(arrayTwo[i][5]);*/

            /*            //一人目
                        setImage.charaImageDatas[0] = arrayTwo[i][1];
                        //二人目
                        setImage.charaImageDatas[1] = arrayTwo[i][2];
                        //三人目
                        setImage.charaImageDatas[2] = arrayTwo[i][3];
                        //四人目
                        setImage.charaImageDatas[3] = arrayTwo[i][4];
                        //五人目
                        setImage.charaImageDatas[4] = arrayTwo[i][5];*/


            soundSe.Add(arrayTwo[i][7]);

            texts.Add(arrayTwo[i][8]);
        }

    }

    private void TextController()
    {
        if (currentCharNum < texts[currentLineNum].Length) DisplayText();
        else 
        {
            switch(inputType)
            {
                case InputType.InputPC : NextLineWhenButton(Input.GetMouseButtonDown(0));
                    break;
                case InputType.MobileInput: NextLineWhenButton(MobileInput.InputState(TouchPhase.Began));
                    break;
            }            
        } 
    }

    private string[][] ConvertCSVtoArray(string s)
    {
        StringReader reader = new StringReader(s);
        reader.ReadLine();  //ヘッダ読み飛ばし
        reader.ReadLine();  //ヘッダ読み飛ばし
        List<string[]> rows = new List<string[]>();
        while (reader.Peek() >= 0)
        {
            string line = reader.ReadLine();        // 一行ずつ読み込み
            string[] elements = line.Split(',');    // 行のセルは,で区切られる
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            rows.Add(elements);
        }
        return rows.ToArray();
    }

    private void DisplayText()
    {
        if (textInterval <= 0)
        {
            
            displayText.text += texts[currentLineNum][currentCharNum];
            Debug.Log(displayText.text);
            talkingCharaName.text = charaName[currentLineNum];

            setImage.ImageDatas[0] = backGroundImage[currentLineNum];
            setImage.ImageDatas[1] = displayCharaImage[currentLineNum];
            loadCheck = true;
           
            currentCharNum++;
            textInterval = charaSpeed * Time.deltaTime;
        }
        else textInterval--;
    }

    private void NextLineWhenButton(bool input)
    {
        if (input && !checkIfTheStoryIsOver)
        {
            SoundManager.Instance.PlaySE(0);
            currentLineNum++;

            if (currentLineNum >= lineIsTheEnd)
            {
                checkIfTheStoryIsOver = true; 
            }
            else
            {

               

                //文字数を0にする
                currentCharNum = 0;
                displayText.text = "";
            }
        }
    }

    /// <summary>
    /// シナリオの開始
    /// </summary>
    public void PlayScenario(int startLine, int endLine)
    {
        currentLineNum = startLine - 3;
        lineIsTheEnd = endLine - 2;
        currentCharNum = 0;
        displayText.text = "";
        checkIfTheStoryIsOver = false;
        
        StartCoroutine(Method(SHEET_NAME));
    }

    public bool LineEndCheck()
    {
        //Debug.Log(currentLineNum + 3);
        return lineIsTheEnd > currentLineNum;
    }
}
