using System.Collections;
using System.Collections.Generic;
using CommonlyUsed;
using UnityEngine;
using UnityEngine.UI;
using DesignPattern;

namespace GameManager
{
    public interface ISceneManager
    {
        void SceneLog(SceneManager sLib);
        void SceneLoadingAsync(string str);
        IEnumerator FadeWait(string str);
        IEnumerator LoadScene(string str);
        IEnumerator LoadingWait(AsyncOperation async, string str);
    }

    public class SceneManager : Singleton<SceneManager>,ISingleton,ISceneManager
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
        public void SceneLog(SceneManager sLib)
        {
            if (log0 == false) { return; }

            if (log1 == true)
            {
                string str = StringComponent.AddString("現在ロードされているシーンの総数", UnityEngine.SceneManagement.SceneManager.sceneCount.ToString());
                Debug.Log(str);
            }

            if (log2 == true)
            {
                string str1 = StringComponent.AddString("ビルド設定のシーン数: ", UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings.ToString());
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

            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(str);
            async.allowSceneActivation = false;

            while (!async.isDone)
            {
                slider.value = async.progress;

                if (async.progress >= 0.9f)
                {
                    text.text = "読み込み完了";
                    if (waitCheck) StartCoroutine(LoadingWait(async, str));
                    waitCheck = false;
                }
                yield return null;
            }
        }

        //Loading終了後遷移
        public IEnumerator LoadingWait(AsyncOperation async, string str)
        {
            yield return new WaitForSeconds(2f);//ローディング時間
            Debug.Log(StringComponent.AddString(StringComponent.AddString("<color=orange><size=13><b>",UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, "</b></size></color><color=lightblue><size=13><b>シーンから</b></size></color>"), "<color=orange><size=13><b>", str, "</b></size></color><color=lightblue><size=13><b>シーンへ遷移</b></size></color>"));

            fade.FadeIn(fadeTime, () => async.allowSceneActivation = true);
        }
    }
}