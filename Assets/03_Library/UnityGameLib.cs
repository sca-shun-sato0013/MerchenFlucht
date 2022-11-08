using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace NUnityGameLib
{
    interface IUnityGameLib
    {
        T[] ArrayAdd<T>(int arrayLength);
        int ShortIf(bool b, int a);
        float ShortIf(bool b, float a);
        double ShortIf(bool b, double a);
        char ShortIf(bool b, char a);
        string ShortIf(bool b, string a);
        T[] ArrayAssignment<T>(T[] arrayReturn, T[] arrayAssigined, int num);
        void UpdateLib();
    }

    /// <summary>
    /// UnityGameLib
    /// Unityのライブラリ(便利なクラスや関数が入っています)
    /// </summary>    
    public class UnityGameLib : MonoBehaviour, IUnityGameLib
    {
              
        void Update()
        {
            UpdateLib();
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
        /// 引数(bool 条件を入力,doble 範囲が大きい小数) 
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
    }

    /// <summary>
    /// クラスのインスタンスを一つに制限する
    /// グローバルなアクセスポイントを提供する
    /// </summary>
    public class Singleton<T> : UnityGameLib where T : Singleton<T>
    {
        protected virtual bool DestroyTragetGameObject => false;
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
        protected virtual void Init() { }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
            OnRelease();
        }

        protected virtual void OnRelease() { }
    }

    namespace NPlayerController
    {
        namespace NControllerPC
        {

        }

        namespace NControllerMobile
        {

        }
    }

    namespace NGameManager
    {
        
        namespace NSoundManager
        {

            interface ISoundManager
            {
                void PlayBGM(AudioClip bgmManager);
                void PlaySE(int seNumber);
            }

            [RequireComponent(typeof(AudioSource))]
            public class SoundManager : Singleton<SoundManager>,IUnityGameLib,ISoundManager
            {
                [SerializeField]AudioSource audioSource;
                [SerializeField]AudioClip[] sound;

                public virtual void PlayBGM(AudioClip bgmNumber)
                {
                    audioSource.clip = bgmNumber;
                    audioSource.Play();
                }

                public virtual void PlaySE(int seNumber)
                {
                    audioSource.PlayOneShot(sound[seNumber]);
                }
            }
        }

        namespace NSceneManager
        {
            interface ISceneManager
            {

            }

            public class SceneManager : Singleton<SceneManager>,IUnityGameLib,ISceneManager
            {
                
            }
        }

        namespace NDebugManager
        {
            interface IDebugManager
            {

            }

            public class DebugManager
            {
                public void Debug()
                {

                }
            }
        }
    }
}

