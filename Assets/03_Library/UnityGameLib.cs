using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using NUnityGameLib.NDesignPattern.NSingleton;
using NUnityGameLib.NDesignPattern.NServiceLocator;
//using Cysharp.Threading.Tasks;


//名前空間
//この中のclassや関数を使うときはusingをつける
namespace NUnityGameLib
{
    public interface IUnityGameLib
    {
        void UpdateLib();
        T[] ArrayAdd<T>(int arrayLength);
        int ShortIf(bool b, int a);
        float ShortIf(bool b, float a);
        double ShortIf(bool b, double a);
        char ShortIf(bool b, char a);
        string ShortIf(bool b, string a);
        T[] ArrayAssignment<T>(T[] arrayReturn, T[] arrayAssigined, int num);
        T[] WhereLineQ<T>(T[] array, bool b);
        List<T> WhereLineQ<T>(List<T> array, bool b);
        String AddString(string str,string str1,string str2="",string str3="",string str4="");
        String AddString(string[] str);
        void ImageLoadingAsync(Image image, string imagePath, bool check = true);
    }

    /// <summary>
    /// UnityGameLib
    /// Unityのライブラリ 便利なクラスや関数などが入っています
    /// </summary>    
    public abstract class UnityGameLib : MonoBehaviour, IUnityGameLib
    {
     

        void Update()
        {
            UpdateLib();
        }

        private void OnEnable()
        {
            ServiceLocator<IUnityGameLib>.Bind(this); 
        }

        private void OnDisable()
        {
            ServiceLocator<IUnityGameLib>.Unbind(this);
        }

        /// <summary>
        /// Update関数をUnityGameLibで管理する関数
        /// 使い方はUpdate関数と同じです
        /// </summary>
        public virtual void UpdateLib(){}

        /// <summary>
        /// 配列を追加する関数
        /// 引数(int 配列の長さ)
        /// </summary>
        public virtual T[] ArrayAdd<T>(int arrayLength)
        {
            T[] array = new T[arrayLength];
            return array;
        }

        /// <summary>
        /// if文の省略系
        /// 引数(bool 条件を入力,int 整数) 
        /// </summary>  
        public virtual int ShortIf(bool b, int a)
        {
            if (b) { return a; }
            return 0;
        }

        /// <summary>
        /// if文の省略系
        /// 引数(bool 条件を入力,float 範囲が小さい小数) 
        /// </summary> 
        public virtual float ShortIf(bool b, float a)
        {
            if (b) { return a; }
            return 0f;
        }

        /// <summary>
        /// if文の省略系
        /// 引数(bool 条件を入力,double 範囲が大きい小数) 
        /// </summary> 
        public virtual double ShortIf(bool b, double a)
        {
            if (b) { return a; }
            return 0d;
        }

        /// <summary>
        /// if文の省略系
        /// 引数(bool 条件を入力,char 文字) 
        /// </summary> 
        public virtual char ShortIf(bool b, char a)
        {
            if (b) { return a; }
            return '0';
        }

        /// <summary>
        /// if文の省略系
        /// 引数(bool 条件を入力,string 文字列) 
        /// </summary> 
        public virtual string ShortIf(bool b, string a)
        {
            if (b) { return a; }
            return "";
        }
        /// <summary>
        /// 型が同じである二つの配列を一方に代入する関数
        /// 引数(T[] 代入されて返される配列 ,T[] 代入する配列,int 代入する数) 
        /// </summary> 
        public virtual T[] ArrayAssignment<T>(T[] arrayReturn,T[] arrayAssigined,int num)
        {
            for(int i = 0; i < arrayReturn.Length;++i)
            {
                arrayReturn[i] = arrayAssigined[i];
            }
            return arrayReturn;
        }

        /// <summary>
        /// ある配列から条件にあった値を返す関数
        /// 引数(T[] 配列,bool 条件)
        /// </summary>
        public virtual T[] WhereLineQ<T>(T[] array,bool b)
        {
            IEnumerable<T> query = array.Where(s => b);
            return query.ToArray();
        }

        /// <summary>
        /// あるリストから条件にあった値を返す関数
        /// 引数(ListT リスト,bool 条件)
        /// </summary>
        public virtual List<T> WhereLineQ<T>(List<T> array, bool b)
        {
            IEnumerable<T> query = array.Where(s => b);
            return query.ToList();
        }

        /// <summary>
        /// 文字列を連結させる関数(最大5つまで)
        /// </summary>
        public String AddString(string str,string str1,string str2="",string str3="",string str4="")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(str);
            sb.Append(str1);
            sb.Append(str2);
            sb.Append(str3);
            sb.Append(str4);
            string s =  sb.ToString();
            return s;
        }

        /// <summary>
        /// 複数の文字列を連結させる関数
        /// 引数(string[]文字列の配列)
        /// </summary>
        public String AddString(string[] str)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string word in str)
            {
                sb.Append(word);
            }
            var text = sb.ToString();
            return text;
        }

        /// <summary>
        /// 画像を指定のフォルダから読み込む関数
        /// 引数(Image 返される画像, string 画像があるパス,bool 条件があれば)
        /// </summary>
        public void ImageLoadingAsync(Image image, string imagePath, bool check = true)
        {
            if (check)
            {
                Addressables.LoadAssetAsync<Sprite>(imagePath).Completed += sprite =>
                {
                     image.sprite = Instantiate(sprite.Result);                     
                };
            }
      
        }

        /*void OnTriggerEnter(Collider collider)
        {
            this.transform.parent = collider.gameObject.transform;
        }*/

    }

    namespace NDesignPattern
    {
        namespace NSingleton
        {
            public interface ISingleton
            {
                bool DestroyTragetGameObject { get;}
                void Init();
                void OnDestroy();
                void OnRelease();
            }

            /// <summary>
            /// シングルトンクラス
            /// クラスのインスタンスを一つに制限する
            /// グローバルなアクセスポイントを提供する
            /// デザインパターンの一種(Singleton)
            /// </summary>(引用URL）
            /// https://marunaka-blog.com/cshap-singleton/5433/
            public abstract class Singleton<T> : UnityGameLib,ISingleton where T : Singleton<T>
            {
                public virtual bool DestroyTragetGameObject => false;
                public static T Instance { get; private set; } = null;

                ///<summary>
                ///Singletonが有効かどうか
                /// </summary>
                public static bool IsValid() => Instance != null;

                private void Awake()
                {
                    if (Instance == null)
                    {
                        Instance = this as T;
                        Instance.Init();
                        return;
                    }
                    if (DestroyTragetGameObject)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        Destroy(this);
                    }
                }

                ///<summary>
                ///派生クラス用のAwake
                /// </summary>
                public virtual void Init() { }

                public void OnDestroy()
                {
                    if (Instance == this)
                    {
                        Instance = null;
                    }
                    OnRelease();
                }

                public virtual void OnRelease() { }
            }
        }

        namespace NServiceLocator
        {
            /// <summary>
            /// サービスロケータクラス
            /// サービス(機能を提供するクラス)のありかを示してくれるもの
            /// プログラムを特定の実装に依存させずに動作させたいときに用いる実装手法の一つ
            /// デザインパターンの一種(ServiceLocator)
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// 
            public static class ServiceLocator<T> where T : class
            {
                public static T Instance { get; private set; }

                //nullじゃないかチェック
                public static bool IsValid() => Instance != null;

                //インスタンスを外部から設定する為
                public static void Bind(T instance)
                {
                    Instance = instance;
                }

                //インスタンスをnullに設定する為
                public static void Unbind(T instance)
                {
                    if(Instance == instance)
                    {
                        Instance = null;
                    }
                }

                //強制的にnullにする
                public static void Clear()
                {
                    Instance = null;
                }
            }
        }

        namespace NStateMachine
        {
            /// <summary>
            /// ステートマシンクラス
            /// 
            /// </summary>
            public class StateMachine<TOwner> : UnityGameLib,IUnityGameLib
            {
                /// <summary>
                /// ステートを表すクラス
                /// </summary>
                public abstract class State
                {
                    /// <summary>
                    /// このステートを管理しているステートマシン
                    /// </summary>
                    protected StateMachine<TOwner> StateMachine => stateMachine;
                    internal StateMachine<TOwner> stateMachine;
                    /// <summary>
                    /// 遷移の一覧
                    /// </summary>
                    internal Dictionary<int, State> transitions = new Dictionary<int, State>();
                    /// <summary>
                    /// このステートのオーナー
                    /// </summary>
                    protected TOwner Owner => stateMachine.Owner;

                    /// <summary>
                    /// ステート開始
                    /// </summary>
                    internal void Enter(State prevState)
                    {
                        OnEnter(prevState);
                    }
                    /// <summary>
                    /// ステートを開始した時に呼ばれる
                    /// </summary>
                    protected virtual void OnEnter(State prevState) { }

                    /// <summary>
                    /// ステート更新
                    /// </summary>
                    internal void Update()
                    {
                        OnUpdate();
                    }
                    /// <summary>
                    /// 毎フレーム呼ばれる
                    /// </summary>
                    protected virtual void OnUpdate() { }

                    /// <summary>
                    /// ステート終了
                    /// </summary>
                    internal void Exit(State nextState)
                    {
                        OnExit(nextState);
                    }
                    /// <summary>
                    /// ステートを終了した時に呼ばれる
                    /// </summary>
                    protected virtual void OnExit(State nextState) { }
                }

                /// <summary>
                /// どのステートからでも特定のステートへ遷移できるようにするための仮想ステート
                /// </summary>
                public sealed class AnyState : State { }

                /// <summary>
                /// このステートマシンのオーナー
                /// </summary>
                public TOwner Owner { get; }
                /// <summary>
                /// 現在のステート
                /// </summary>
                public State CurrentState { get; private set; }

                // ステートリスト
                private LinkedList<State> states = new LinkedList<State>();

                /// <summary>
                /// ステートマシンを初期化する
                /// </summary>
                /// <param name="owner">ステートマシンのオーナー</param>
                public StateMachine(TOwner owner)
                {
                    Owner = owner;
                }

                /// <summary>
                /// ステートを追加する（ジェネリック版）
                /// </summary>
                public T Add<T>() where T : State, new()
                {
                    T state = new T();
                    state.stateMachine = this;
                    states.AddLast(state);
                    return state;
                }

                /// <summary>
                /// 特定のステートを取得、なければ生成する
                /// </summary>
                public T GetOrAddState<T>() where T : State, new()
                {
                    foreach (var state in states)
                    {
                        if (state is T result)
                        {
                            return result;
                        }
                    }
                    return Add<T>();
                }

                /// <summary>
                /// 遷移を定義する
                /// </summary>
                /// <param name="eventId">イベントID</param>
                public void AddTransition<TFrom, TTo>(int eventId)
                    where TFrom : State, new()
                    where TTo : State, new()
                {
                    TFrom from = GetOrAddState<TFrom>();
                    if (from.transitions.ContainsKey(eventId))
                    {
                        // 同じイベントIDの遷移を定義済
                        throw new System.ArgumentException(
                            $"ステート'{nameof(TFrom)}'に対してイベントID'{eventId.ToString()}'の遷移は定義済です");
                    }

                    TTo to = GetOrAddState<TTo>();
                    from.transitions.Add(eventId, to);
                }

                /// <summary>
                /// どのステートからでも特定のステートへ遷移できるイベントを追加する
                /// </summary>
                /// <param name="eventId">イベントID</param>
                public void AddAnyTransition<TTo>(int eventId) where TTo : State, new()
                {
                    AddTransition<AnyState, TTo>(eventId);
                }

                /// <summary>
                /// ステートマシンの実行を開始する（ジェネリック版）
                /// </summary>
                public void Start<TFirst>() where TFirst : State, new()
                {
                    Start(GetOrAddState<TFirst>());
                }

                /// <summary>
                /// ステートマシンの実行を開始する
                /// </summary>
                /// <param name="firstState">起動時のステート</param>
                /// <param name="param">パラメータ</param>
                public void Start(State firstState)
                {
                    CurrentState = firstState;
                    CurrentState.Enter(null);
                }

                /// <summary>
                /// ステートを更新する
                /// </summary>
                public void Update()
                {
                    CurrentState.Update();
                }

                /// <summary>
                /// イベントを発行する
                /// </summary>
                /// <param name="eventId">イベントID</param>
                public void Dispatch(int eventId)
                {
                    State to;
                    if (!CurrentState.transitions.TryGetValue(eventId, out to))
                    {
                        if (!GetOrAddState<AnyState>().transitions.TryGetValue(eventId, out to))
                        {
                            // イベントに対応する遷移が見つからなかった
                            return;
                        }
                    }
                    Change(to);
                }

                /// <summary>
                /// ステートを変更する
                /// </summary>
                /// <param name="nextState">遷移先のステート</param>
                private void Change(State nextState)
                {
                    CurrentState.Exit(nextState);
                    nextState.Enter(CurrentState);
                    CurrentState = nextState;
                }
            }
        }
    }

    namespace NPlayerController
    {
        namespace NControllerPC
        {
            public interface IControllerPC
            {
                Transform GetKeyPositionMoveUp(GameObject obj, float speed);
                Transform GetKeyPositionMoveDown(GameObject obj, float speed);
                Transform GetKeyPositionMoveRight(GameObject obj, float speed);
                Transform GetKeyPositionMoveLeft(GameObject obj, float speed);
            }

            /// <summary>
            /// PCのコントローラークラス
            /// PCのキー入力関係の関数が入っています
            /// </summary>
            public abstract class ControllerPC : UnityGameLib,IUnityGameLib,IControllerPC
            {
                /// <summary>
                /// キー入力によってオブジェクトの座標が前移動する関数
                /// 引数(GameObject 移動させるオブジェクト, float 移動の速さ)
                /// </summary>
                /// <param name="obj">移動させるオブジェクト</param>
                /// <param name="speed">移動の速さ</param>
                /// <returns>移動の座標</returns>
                public virtual Transform GetKeyPositionMoveUp(GameObject obj, float speed)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    {
                        obj.transform.position += Vector3.forward * speed * Time.deltaTime;
                    }
                    return obj.transform;
                }

                /// <summary>
                /// キー入力によってオブジェクトの座標が後移動する関数
                /// 引数(GameObject 移動させるオブジェクト, float 移動の速さ)
                /// </summary>
                /// <param name="obj">移動させるオブジェクト</param>
                /// <param name="speed">移動の速さ</param>
                /// <returns>移動の座標</returns>
                public virtual Transform GetKeyPositionMoveDown(GameObject obj, float speed)
                {
                    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    {
                        obj.transform.position += Vector3.back * speed * Time.deltaTime;
                    }
                    return obj.transform;
                }

                /// <summary>
                /// キー入力によってオブジェクトの座標が右移動する関数
                /// 引数(GameObject 移動させるオブジェクト, float 移動の速さ)
                /// </summary>
                /// <param name="obj">移動させるオブジェクト</param>
                /// <param name="speed">移動の速さ</param>
                /// <returns>移動の座標</returns>
                public virtual Transform GetKeyPositionMoveRight(GameObject obj, float speed)
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        obj.transform.position += transform.right * speed * Time.deltaTime;
                    }
                    return obj.transform;
                }

                /// <summary>
                /// キー入力によってオブジェクトの座標が左移動する関数
                /// 引数(GameObject 移動させるオブジェクト, float 移動の速さ)
                /// </summary>
                /// <param name="obj">移動させるオブジェクト</param>
                /// <param name="speed">移動の速さ</param>
                /// <returns>移動の座標</returns>
                public virtual Transform GetKeyPositionMoveLeft(GameObject obj, float speed)
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        obj.transform.position += Vector3.left * speed * Time.deltaTime;
                    }
                    return obj.transform;
                }
            }

        }

        namespace NControllerMobile
        {

        }
    }

    namespace NGameManager
    {
        
        namespace NSoundManager
        {

            public interface ISoundManager
            {
                void PlayBGM(int bgmManager);
                void PlaySE(int seNumber);
            }

            [RequireComponent(typeof(AudioSource))]
            public abstract class SoundManager : Singleton<SoundManager>,IUnityGameLib,ISingleton,ISoundManager
            {
                [SerializeField]AudioSource audioSource;
                [SerializeField]AudioClip[] soundBGM;
                [SerializeField]AudioClip[] soundSE;

                /// <summary>
                /// バックグラウンド再生
                /// 引数(int BGM配列の番号)
                /// </summary>
                /// <param name="bgmNumber">BGM配列の番号</param>
                public virtual void PlayBGM(int bgmNumber)
                {
                    audioSource.clip = soundBGM[bgmNumber];
                    audioSource.Play();
                }

                /// <summary>
                /// 効果音(se)再生
                /// 引数(int SE配列の番号)
                /// </summary>
                /// <param name="seNumber">SE配列の番号</param>
                public virtual void PlaySE(int seNumber)
                {
                    audioSource.PlayOneShot(soundSE[seNumber]);
                }
            }
        }

        namespace NSceneManager
        {
            public interface ISceneManager
            {
                void SceneLog(SceneManagerLib sLib);
                void SceneLoadingAsync(string str);
                IEnumerator FadeWait(string str);
                IEnumerator LoadScene(string str);
                IEnumerator LoadingWait(AsyncOperation async, string str);
            }

            public abstract class SceneManagerLib : Singleton<SceneManagerLib>,IUnityGameLib,ISingleton,ISceneManager
            {
                [SerializeField, Header("LoadingScreen")] GameObject obj;
                [SerializeField] Slider slider;
                [SerializeField] Text text;
                [SerializeField] Fade fade;
                [SerializeField] FadeImage fadeImage;
                [SerializeField, Header("Fadeする時間")] float fadeTime = 0;
                [SerializeField, Header("すべてのlog表示:")] bool log0 = false;
                [SerializeField, Header("Sceneの総数:")] bool log1 = false;
                [SerializeField, Header("Sceneの総数:")] bool log2 = false;
                bool waitCheck = true;


                /// <summary>
                /// シーンの状態表示ログ
                /// 引数(SceneManagerLib SceneManagerLibクラスを継承したもの)
                /// </summary>
                /// <param name="sLib">SceneManagerLibクラスを継承したもの</param>
                public void SceneLog(SceneManagerLib sLib)
                {
                    if(log0 == false){return;}

                    if(log1 == true) 
                    {
                        string str = AddString("現在ロードされているシーンの総数", SceneManager.sceneCount.ToString());
                        Debug.Log(str); 
                    }

                    if(log2 == true)
                    {
                        string str1 = AddString("ビルド設定のシーン数: ", SceneManager.sceneCountInBuildSettings.ToString());
                        Debug.Log(str1);
                    }
                }

                /// <summary>
                /// 非同期でシーンを遷移する関数
                /// シーン遷移中は自動的にローディング画面をはさみます。
                /// 引数(string 移動したいシーン名)
                /// </summary>
                /// <param name="str">移動したいシーン名</param>
                public void SceneLoadingAsync(string str)
                {
                    fade.FadeIn(fadeTime, () => obj.SetActive(true));
                    StartCoroutine(FadeWait(str));                      
                }
   
                //fade終了後Loading画面に移動
                public IEnumerator FadeWait(string str)
                {
                    yield return new WaitUntil(() => fadeImage.Range == 1f);
                    fade.FadeOut(fadeTime, () => StartCoroutine(LoadScene(str)));
                }

                //シーンの読み込み待ち
                public IEnumerator LoadScene(string str)
                {
                    yield return null;

                    AsyncOperation async = SceneManager.LoadSceneAsync(str);
                    async.allowSceneActivation = false;

                    while(!async.isDone)
                    {
                        slider.value = async.progress;

                        if(async.progress >= 0.9f)
                        {
                            text.text = "読み込み完了";
                            if (waitCheck)StartCoroutine(LoadingWait(async,str));
                            waitCheck = false;
                        }
                        yield return null;
                    }
                }

                //Loading終了後遷移
                public IEnumerator LoadingWait(AsyncOperation async,string str)
                {
                    yield return new WaitForSeconds(2f);//ローディング時間
                    Debug.Log(AddString(AddString("<color=orange><size=13><b>", SceneManager.GetActiveScene().name, "</b></size></color><color=lightblue><size=13><b>シーンから</b></size></color>"), "<color=orange><size=13><b>", str, "</b></size></color><color=lightblue><size=13><b>シーンへ遷移</b></size></color>"));

                    fade.FadeIn(fadeTime, () => async.allowSceneActivation = true);
                }
            }
        }

        namespace NScenarioManager
        {
            public interface IScenarioManager
            {

            }
           
            public abstract class ScenarioManager : Singleton<ScenarioManager>,IUnityGameLib,IScenarioManager,ISingleton
            {
               [SerializeField,Header("googleスプレットシートのID")] string SHEET_ID = "IDを入れる";
               [SerializeField,Header("シート名")] string SHEET_NAME = "シート名を入れる";

                //一行の文字数
                [SerializeField,Header("一行の文字数")]int currentCharNum = 0;
                //行数
                [SerializeField,Header("行数")]int currentLineNum = 0;
                //文字がテキストに書き込まれる速さ
                private float textInterval = 0f;
                [SerializeField,Header("表示されるテキスト")]
                Text displayText;
                [SerializeField, Header("文字が表示される速さ")]
                float charaSpeed = 0f;
                [SerializeField, Header("話をしているキャラの名前")]
                Text talkingCharaName = null;
                //googleスプレットシートのデータ保管用
                string[][] arrayTwo;
                //話しているキャラの名前保管用
                List<string> charaName = new List<string>();
                //画面に表示するキャラ名保管用
                List<string> displayCharaImage = new List<string>();
                //効果音se保管用
                List<string> soundSe = new List<string>();
                //文章保管用
                List<string> texts = new List<string>();
                
                //テキスト表示が終わっているかのチェック
                bool checkIfTheStoryIsOver = false;

                public override void UpdateLib()
                {
                    TextController();
                }
                public IEnumerator Method(string _SHEET_NAME)
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

                    for(int i = 0; i < arrayTwo.Length; i++)
                    {
                        charaName.Add(arrayTwo[i][0]);

                        displayCharaImage.Add(arrayTwo[i][1]);
                        displayCharaImage.Add(arrayTwo[i][2]);
                        displayCharaImage.Add(arrayTwo[i][3]);
                        displayCharaImage.Add(arrayTwo[i][4]);
                        displayCharaImage.Add(arrayTwo[i][5]);

                        soundSe.Add(arrayTwo[i][6]);

                        texts.Add(arrayTwo[i][7]);
                    }

                }

                public void TextController()
                {
                    if (currentCharNum < texts[currentLineNum].Length) DisplayText();
                    else NextLineWhenButton();
                }

                public string[][] ConvertCSVtoArray(string s)
                {
                    StringReader reader = new StringReader(s);
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

                void DisplayText()
                {                   
                    if (textInterval <= 0)
                    {
                        displayText.text += texts[currentLineNum][currentCharNum];
                        talkingCharaName.text = charaName[currentLineNum];
                        currentCharNum++;
                       textInterval = charaSpeed*Time.deltaTime;
                    }
                    else textInterval--;
                }

                void NextLineWhenButton()
                {
                    if (Input.GetMouseButton(0) && !checkIfTheStoryIsOver)
                    {
                        
                        currentLineNum++;

                        if (currentLineNum >= lineIsTheEnd()) 
                        { checkIfTheStoryIsOver = true;};
                        //文字数を0にする
                        currentCharNum = 0;
                        displayText.text = "";

                    }
                }


                protected virtual int lineIsTheEnd()
                {
                    int lineIsTheEnd = 2000;
                    return lineIsTheEnd;
                }

                public void ReLoadGoogleSheet()
                {
                    StartCoroutine(Method(SHEET_NAME));
                }
            }
        }

        namespace NDebugManager
        {
            public interface IDebugManager
            {
                void GeneralDebugger(UnityGameLib lib);
                void Debugger(string s, int i);
                void Debugger(string s, float f);
                void Debugger(string s, double d);
                void Debugger(string s, char c);
                void Debugger(string s);
                void Debugger(string s, Vector2 v2);
                void Debugger(string s, Vector3 v3);

            }

            
            public abstract class DebugManager : Singleton<DebugManager>,IUnityGameLib,IDebugManager,ISingleton
            {
                [Header("全てのログ表示:")]
                [SerializeField, Header("Debugger関数使用時:")] bool log0;
                [SerializeField, Header("int型ログ表示:")]      bool log1;
                [SerializeField, Header("float型ログ表示:")]    bool log2;
                [SerializeField, Header("double型ログ表示:")]   bool log3;
                [SerializeField, Header("char型ログ表示:")]     bool log4;
                [SerializeField, Header("string型ログ表示:")]   bool log5;
                [SerializeField, Header("Vector2型ログ表示:")]  bool log6;
                [SerializeField, Header("Vector3型ログ表示:")]  bool log7;

                private void OnEnable()
                {
                    ServiceLocator<IDebugManager>.Bind(this);
                }

                private void OnDisable()
                {
                    ServiceLocator<IDebugManager>.Unbind(this);
                }

                /// <summary>
                /// オブジェクトの一般的な情報Log
                /// 引数(UnityGameLib UnityGameLibを継承したもの)
                /// </summary>
                /// <param name="lib">UnityGameLibを継承したもの</param>
                public void GeneralDebugger(UnityGameLib lib)
                {
                    Debug.Log(AddString("<size=13><b>アタッチされているオブジェクト名 :", lib.gameObject.name,"</b></size>"));
                    Debug.Log(AddString("<size=13><b>そのscriptが有効であるか :", lib.enabled.ToString(), "</b></size>"));
                    Debug.Log(AddString("<size=13><b>ゲームオブジェクトがアクティブでかつscriptが有効であるか :", lib.isActiveAndEnabled.ToString(), "</b></size>"));
                    Debug.Log(AddString("<size=13><b>使用されているタグ名: ", lib.tag, "</b></size>"));
                    Debug.Log(AddString("<size=13><b>position :", lib.transform.position.ToString(), "</b></size>"));
                    Debug.Log(AddString("<size=13><b>rotation :", lib.transform.rotation.ToString(), "</b></size>"));
                    Debug.Log(AddString("<size=13><b>scale :", lib.transform.localScale.ToString(), "</b></size>"));
                }

                /// <summary>
                /// int型のデバッグ表示
                /// 引数(string デバッグの際に使用したい文字列,int デバッグの値)
                /// </summary>
                /// <param name="s">デバッグの際に使用したい文字列</param>
                /// <param name="i">デバッグの値</param>
                public void Debugger(string s,int i)
                {
                    if(log1 && log0)
                    {                     
                        Debug.Log(AddString(AddString("<color=cyan><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     i.ToString(), "</b></size></color>"));
                    }
                }


                /// <summary>
                /// float型のデバッグ表示
                /// 引数(string デバッグの際に使用したい文字列,float デバッグの値)
                /// </summary>
                /// <param name="s">デバッグの際に使用したい文字列</param>
                /// <param name="f">デバッグの値</param>
                public void Debugger(string s, float f)
                {
                    if (log2 && log0)
                    {
                        Debug.Log(AddString(AddString("<color=magenta><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     f.ToString(), "</b></size></color>"));
                    }
                }

                /// <summary>
                /// double型のデバッグ表示
                /// 引数(string デバッグの際に使用したい文字列,double デバッグの値)
                /// </summary>
                /// <param name="s">デバッグの際に使用したい文字列</param>
                /// <param name="d">デバッグの値</param>
                public void Debugger(string s, double d)
                {
                    if (log3 && log0)
                    {
                        Debug.Log(AddString(AddString("<color=maroon><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     d.ToString(), "</b></size></color>"));
                    }
                }

                /// <summary>
                /// char型のデバッグ表示
                /// 引数(string デバッグの際に使用したい文字列,char デバッグの値)
                /// </summary>
                /// <param name="s">デバッグの際に使用したい文字列</param>
                /// <param name="c">デバッグの値</param>
                public void Debugger(string s, char c)
                {
                    if (log4 && log0)
                    {
                        Debug.Log(AddString(AddString("<color=orange><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     c.ToString(), "</b></size></color>"));
                    }
                }

                /// <summary>
                /// string型のデバッグ表示
                /// 引数(string デバッグの際に使用したい文字列)
                /// </summary>
                /// <param name="s">デバッグの際に使用したい文字列</param>
                public void Debugger(string s)
                {
                    if (log5 && log0)
                    {
                        Debug.Log(AddString("<color=lightblue><size=13><b>", s, "</b></size></color>"));
                    }
                }

                /// <summary>
                /// Vector2型のデバッグ表示
                /// 引数(string デバッグの際に使用したい文字列,Vector2 デバッグの値)
                /// </summary>
                /// <param name="s">デバッグの際に使用したい文字列</param>
                /// <param name="v2">デバッグの値</param>
                public void Debugger(string s,Vector2 v2)
                {
                    if (log6 && log0)
                    {
                        Debug.Log(AddString(AddString("<color=teal><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     v2.ToString(), "</b></size></color>"));
                    }
                }

                /// <summary>
                /// Vector3型のデバッグ表示
                /// 引数(string デバッグの際に使用したい文字列,Vector3 デバッグの値)
                /// </summary>
                /// <param name="s">デバッグの際に使用したい文字列</param>
                /// <param name="v3">デバッグの値</param>
                public void Debugger(string s, Vector3 v3)
                {
                    if (log7 && log0)
                    {             
                        Debug.Log(AddString(AddString("<color=lime><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     v3.ToString(), "</b></size></color>"));
                    }
                }
            }
        }
    } 
}
