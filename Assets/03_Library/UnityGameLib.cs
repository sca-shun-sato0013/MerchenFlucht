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
    /// Unity�̃��C�u����(�֗��ȃN���X��֐��������Ă��܂�)
    /// </summary>    
    public class UnityGameLib : MonoBehaviour, IUnityGameLib
    {
              
        void Update()
        {
            UpdateLib();
        }

        /// <summary>
        /// Update�֐���UnityGameLib�ŊǗ�����֐�
        /// �g������Update�֐��Ɠ����ł�
        /// </summary>
        public virtual void UpdateLib(){}

        /// <summary>
        /// �z���ǉ�����֐�
        /// ����(int �z��̒���)
        /// </summary>
        public virtual T[] ArrayAdd<T>(int arrayLength)
        {
            T[] array = new T[arrayLength];
            return array;
        }

        /// <summary>
        /// if���̏ȗ��n
        /// ����(bool ���������,int ����) 
        /// </summary>  
        public virtual int ShortIf(bool b, int a)
        {
            if (b) { return a; }
            return 0;
        }

        /// <summary>
        /// if���̏ȗ��n
        /// ����(bool ���������,float �͈͂�����������) 
        /// </summary> 
        public virtual float ShortIf(bool b, float a)
        {
            if (b) { return a; }
            return 0f;
        }

        /// <summary>
        /// if���̏ȗ��n
        /// ����(bool ���������,doble �͈͂��傫������) 
        /// </summary> 
        public virtual double ShortIf(bool b, double a)
        {
            if (b) { return a; }
            return 0d;
        }

        /// <summary>
        /// if���̏ȗ��n
        /// ����(bool ���������,char ����) 
        /// </summary> 
        public virtual char ShortIf(bool b, char a)
        {
            if (b) { return a; }
            return '0';
        }

        /// <summary>
        /// if���̏ȗ��n
        /// ����(bool ���������,string ������) 
        /// </summary> 
        public virtual string ShortIf(bool b, string a)
        {
            if (b) { return a; }
            return "";
        }

        /// <summary>
        /// �^�������ł����̔z�������ɑ������֐�
        /// ����(T[] �������ĕԂ����z�� ,T[] �������z��,int ������鐔) 
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
        /// ����z�񂩂�����ɂ������l��Ԃ��֐�
        /// ����(T[] �z��,bool ����)
        /// </summary>
        public virtual T[] WhereLineQ<T>(T[] array,bool b)
        {
            IEnumerable<T> query = array.Where(s => b);
            return query.ToArray();
        }

        /// <summary>
        /// ���郊�X�g��������ɂ������l��Ԃ��֐�
        /// ����(ListT ���X�g,bool ����)
        /// </summary>
        public virtual List<T> WhereLineQ<T>(List<T> array, bool b)
        {
            IEnumerable<T> query = array.Where(s => b);
            return query.ToList();
        }        
    }

    /// <summary>
    /// �N���X�̃C���X�^���X����ɐ�������
    /// �O���[�o���ȃA�N�Z�X�|�C���g��񋟂���
    /// </summary>
    public class Singleton<T> : UnityGameLib where T : Singleton<T>
    {
        protected virtual bool DestroyTragetGameObject => false;
        public static T Instance { get; private set; } = null;

        ///<summary>
        ///Singleton���L�����ǂ���
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
        ///�h���N���X�p��Awake
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

