using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    
    public class UnityGameLib : MonoBehaviour, IUnityGameLib
    {
              
        void Update()
        {
            UpdateLib();
        }

        public virtual void UpdateLib(){}

        public virtual T[] ArrayAdd<T>(int arrayLength)
        {
            T[] array = new T[arrayLength];
            return array;
        }

        public virtual int ShortIf(bool b, int a)
        {
            if (b) { return a; }
            return 0;
        }

        public virtual float ShortIf(bool b, float a)
        {
            if (b) { return a; }
            return 0f;
        }

        public virtual double ShortIf(bool b, double a)
        {
            if (b) { return a; }
            return 0d;
        }

        public virtual char ShortIf(bool b, char a)
        {
            if (b) { return a; }
            return '0';
        }

        public virtual string ShortIf(bool b, string a)
        {
            if (b) { return a; }
            return "";
        }

        public virtual T[] ArrayAssignment<T>(T[] arrayReturn,T[] arrayAssigined,int num)
        {
            for(int i = 0; i < arrayReturn.Length;++i)
            {
                arrayReturn[i] = arrayAssigined[i];
            }
            return arrayReturn;
        }
    }

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

    

    namespace NGameManager
    {
        
        namespace NSoundManager
        {

            interface ISoundManager
            {

            }

            struct Sound
            {

            }


            [RequireComponent(typeof(AudioSource))]
            public class SoundManager : Singleton<SoundManager>,IUnityGameLib,ISoundManager
            {
               
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
    }
}

