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


//���O���
//���̒���class��֐����g���Ƃ���using������
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
    /// Unity�̃��C�u���� �֗��ȃN���X��֐��Ȃǂ������Ă��܂�
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
        /// ����(bool ���������,double �͈͂��傫������) 
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

        /// <summary>
        /// �������A��������֐�(�ő�5�܂�)
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
        /// �����̕������A��������֐�
        /// ����(string[]������̔z��)
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
        /// �摜���w��̃t�H���_����ǂݍ��ފ֐�
        /// ����(Image �Ԃ����摜, string �摜������p�X,bool �����������)
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
            /// �V���O���g���N���X
            /// �N���X�̃C���X�^���X����ɐ�������
            /// �O���[�o���ȃA�N�Z�X�|�C���g��񋟂���
            /// �f�U�C���p�^�[���̈��(Singleton)
            /// </summary>(���pURL�j
            /// https://marunaka-blog.com/cshap-singleton/5433/
            public abstract class Singleton<T> : UnityGameLib,ISingleton where T : Singleton<T>
            {
                public virtual bool DestroyTragetGameObject => false;
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
            /// �T�[�r�X���P�[�^�N���X
            /// �T�[�r�X(�@�\��񋟂���N���X)�̂��肩�������Ă�������
            /// �v���O���������̎����Ɉˑ��������ɓ��삳�������Ƃ��ɗp���������@�̈��
            /// �f�U�C���p�^�[���̈��(ServiceLocator)
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// 
            public static class ServiceLocator<T> where T : class
            {
                public static T Instance { get; private set; }

                //null����Ȃ����`�F�b�N
                public static bool IsValid() => Instance != null;

                //�C���X�^���X���O������ݒ肷���
                public static void Bind(T instance)
                {
                    Instance = instance;
                }

                //�C���X�^���X��null�ɐݒ肷���
                public static void Unbind(T instance)
                {
                    if(Instance == instance)
                    {
                        Instance = null;
                    }
                }

                //�����I��null�ɂ���
                public static void Clear()
                {
                    Instance = null;
                }
            }
        }

        namespace NStateMachine
        {
            /// <summary>
            /// �X�e�[�g�}�V���N���X
            /// 
            /// </summary>
            public class StateMachine<TOwner> : UnityGameLib,IUnityGameLib
            {
                /// <summary>
                /// �X�e�[�g��\���N���X
                /// </summary>
                public abstract class State
                {
                    /// <summary>
                    /// ���̃X�e�[�g���Ǘ����Ă���X�e�[�g�}�V��
                    /// </summary>
                    protected StateMachine<TOwner> StateMachine => stateMachine;
                    internal StateMachine<TOwner> stateMachine;
                    /// <summary>
                    /// �J�ڂ̈ꗗ
                    /// </summary>
                    internal Dictionary<int, State> transitions = new Dictionary<int, State>();
                    /// <summary>
                    /// ���̃X�e�[�g�̃I�[�i�[
                    /// </summary>
                    protected TOwner Owner => stateMachine.Owner;

                    /// <summary>
                    /// �X�e�[�g�J�n
                    /// </summary>
                    internal void Enter(State prevState)
                    {
                        OnEnter(prevState);
                    }
                    /// <summary>
                    /// �X�e�[�g���J�n�������ɌĂ΂��
                    /// </summary>
                    protected virtual void OnEnter(State prevState) { }

                    /// <summary>
                    /// �X�e�[�g�X�V
                    /// </summary>
                    internal void Update()
                    {
                        OnUpdate();
                    }
                    /// <summary>
                    /// ���t���[���Ă΂��
                    /// </summary>
                    protected virtual void OnUpdate() { }

                    /// <summary>
                    /// �X�e�[�g�I��
                    /// </summary>
                    internal void Exit(State nextState)
                    {
                        OnExit(nextState);
                    }
                    /// <summary>
                    /// �X�e�[�g���I���������ɌĂ΂��
                    /// </summary>
                    protected virtual void OnExit(State nextState) { }
                }

                /// <summary>
                /// �ǂ̃X�e�[�g����ł�����̃X�e�[�g�֑J�ڂł���悤�ɂ��邽�߂̉��z�X�e�[�g
                /// </summary>
                public sealed class AnyState : State { }

                /// <summary>
                /// ���̃X�e�[�g�}�V���̃I�[�i�[
                /// </summary>
                public TOwner Owner { get; }
                /// <summary>
                /// ���݂̃X�e�[�g
                /// </summary>
                public State CurrentState { get; private set; }

                // �X�e�[�g���X�g
                private LinkedList<State> states = new LinkedList<State>();

                /// <summary>
                /// �X�e�[�g�}�V��������������
                /// </summary>
                /// <param name="owner">�X�e�[�g�}�V���̃I�[�i�[</param>
                public StateMachine(TOwner owner)
                {
                    Owner = owner;
                }

                /// <summary>
                /// �X�e�[�g��ǉ�����i�W�F�l���b�N�Łj
                /// </summary>
                public T Add<T>() where T : State, new()
                {
                    T state = new T();
                    state.stateMachine = this;
                    states.AddLast(state);
                    return state;
                }

                /// <summary>
                /// ����̃X�e�[�g���擾�A�Ȃ���ΐ�������
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
                /// �J�ڂ��`����
                /// </summary>
                /// <param name="eventId">�C�x���gID</param>
                public void AddTransition<TFrom, TTo>(int eventId)
                    where TFrom : State, new()
                    where TTo : State, new()
                {
                    TFrom from = GetOrAddState<TFrom>();
                    if (from.transitions.ContainsKey(eventId))
                    {
                        // �����C�x���gID�̑J�ڂ��`��
                        throw new System.ArgumentException(
                            $"�X�e�[�g'{nameof(TFrom)}'�ɑ΂��ăC�x���gID'{eventId.ToString()}'�̑J�ڂ͒�`�ςł�");
                    }

                    TTo to = GetOrAddState<TTo>();
                    from.transitions.Add(eventId, to);
                }

                /// <summary>
                /// �ǂ̃X�e�[�g����ł�����̃X�e�[�g�֑J�ڂł���C�x���g��ǉ�����
                /// </summary>
                /// <param name="eventId">�C�x���gID</param>
                public void AddAnyTransition<TTo>(int eventId) where TTo : State, new()
                {
                    AddTransition<AnyState, TTo>(eventId);
                }

                /// <summary>
                /// �X�e�[�g�}�V���̎��s���J�n����i�W�F�l���b�N�Łj
                /// </summary>
                public void Start<TFirst>() where TFirst : State, new()
                {
                    Start(GetOrAddState<TFirst>());
                }

                /// <summary>
                /// �X�e�[�g�}�V���̎��s���J�n����
                /// </summary>
                /// <param name="firstState">�N�����̃X�e�[�g</param>
                /// <param name="param">�p�����[�^</param>
                public void Start(State firstState)
                {
                    CurrentState = firstState;
                    CurrentState.Enter(null);
                }

                /// <summary>
                /// �X�e�[�g���X�V����
                /// </summary>
                public void Update()
                {
                    CurrentState.Update();
                }

                /// <summary>
                /// �C�x���g�𔭍s����
                /// </summary>
                /// <param name="eventId">�C�x���gID</param>
                public void Dispatch(int eventId)
                {
                    State to;
                    if (!CurrentState.transitions.TryGetValue(eventId, out to))
                    {
                        if (!GetOrAddState<AnyState>().transitions.TryGetValue(eventId, out to))
                        {
                            // �C�x���g�ɑΉ�����J�ڂ�������Ȃ�����
                            return;
                        }
                    }
                    Change(to);
                }

                /// <summary>
                /// �X�e�[�g��ύX����
                /// </summary>
                /// <param name="nextState">�J�ڐ�̃X�e�[�g</param>
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
            /// PC�̃R���g���[���[�N���X
            /// PC�̃L�[���͊֌W�̊֐��������Ă��܂�
            /// </summary>
            public abstract class ControllerPC : UnityGameLib,IUnityGameLib,IControllerPC
            {
                /// <summary>
                /// �L�[���͂ɂ���ăI�u�W�F�N�g�̍��W���O�ړ�����֐�
                /// ����(GameObject �ړ�������I�u�W�F�N�g, float �ړ��̑���)
                /// </summary>
                /// <param name="obj">�ړ�������I�u�W�F�N�g</param>
                /// <param name="speed">�ړ��̑���</param>
                /// <returns>�ړ��̍��W</returns>
                public virtual Transform GetKeyPositionMoveUp(GameObject obj, float speed)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    {
                        obj.transform.position += Vector3.forward * speed * Time.deltaTime;
                    }
                    return obj.transform;
                }

                /// <summary>
                /// �L�[���͂ɂ���ăI�u�W�F�N�g�̍��W����ړ�����֐�
                /// ����(GameObject �ړ�������I�u�W�F�N�g, float �ړ��̑���)
                /// </summary>
                /// <param name="obj">�ړ�������I�u�W�F�N�g</param>
                /// <param name="speed">�ړ��̑���</param>
                /// <returns>�ړ��̍��W</returns>
                public virtual Transform GetKeyPositionMoveDown(GameObject obj, float speed)
                {
                    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    {
                        obj.transform.position += Vector3.back * speed * Time.deltaTime;
                    }
                    return obj.transform;
                }

                /// <summary>
                /// �L�[���͂ɂ���ăI�u�W�F�N�g�̍��W���E�ړ�����֐�
                /// ����(GameObject �ړ�������I�u�W�F�N�g, float �ړ��̑���)
                /// </summary>
                /// <param name="obj">�ړ�������I�u�W�F�N�g</param>
                /// <param name="speed">�ړ��̑���</param>
                /// <returns>�ړ��̍��W</returns>
                public virtual Transform GetKeyPositionMoveRight(GameObject obj, float speed)
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        obj.transform.position += transform.right * speed * Time.deltaTime;
                    }
                    return obj.transform;
                }

                /// <summary>
                /// �L�[���͂ɂ���ăI�u�W�F�N�g�̍��W�����ړ�����֐�
                /// ����(GameObject �ړ�������I�u�W�F�N�g, float �ړ��̑���)
                /// </summary>
                /// <param name="obj">�ړ�������I�u�W�F�N�g</param>
                /// <param name="speed">�ړ��̑���</param>
                /// <returns>�ړ��̍��W</returns>
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
                /// �o�b�N�O���E���h�Đ�
                /// ����(int BGM�z��̔ԍ�)
                /// </summary>
                /// <param name="bgmNumber">BGM�z��̔ԍ�</param>
                public virtual void PlayBGM(int bgmNumber)
                {
                    audioSource.clip = soundBGM[bgmNumber];
                    audioSource.Play();
                }

                /// <summary>
                /// ���ʉ�(se)�Đ�
                /// ����(int SE�z��̔ԍ�)
                /// </summary>
                /// <param name="seNumber">SE�z��̔ԍ�</param>
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
                [SerializeField, Header("Fade���鎞��")] float fadeTime = 0;
                [SerializeField, Header("���ׂĂ�log�\��:")] bool log0 = false;
                [SerializeField, Header("Scene�̑���:")] bool log1 = false;
                [SerializeField, Header("Scene�̑���:")] bool log2 = false;
                bool waitCheck = true;


                /// <summary>
                /// �V�[���̏�ԕ\�����O
                /// ����(SceneManagerLib SceneManagerLib�N���X���p����������)
                /// </summary>
                /// <param name="sLib">SceneManagerLib�N���X���p����������</param>
                public void SceneLog(SceneManagerLib sLib)
                {
                    if(log0 == false){return;}

                    if(log1 == true) 
                    {
                        string str = AddString("���݃��[�h����Ă���V�[���̑���", SceneManager.sceneCount.ToString());
                        Debug.Log(str); 
                    }

                    if(log2 == true)
                    {
                        string str1 = AddString("�r���h�ݒ�̃V�[����: ", SceneManager.sceneCountInBuildSettings.ToString());
                        Debug.Log(str1);
                    }
                }

                /// <summary>
                /// �񓯊��ŃV�[����J�ڂ���֐�
                /// �V�[���J�ڒ��͎����I�Ƀ��[�f�B���O��ʂ��͂��݂܂��B
                /// ����(string �ړ��������V�[����)
                /// </summary>
                /// <param name="str">�ړ��������V�[����</param>
                public void SceneLoadingAsync(string str)
                {
                    fade.FadeIn(fadeTime, () => obj.SetActive(true));
                    StartCoroutine(FadeWait(str));                      
                }
   
                //fade�I����Loading��ʂɈړ�
                public IEnumerator FadeWait(string str)
                {
                    yield return new WaitUntil(() => fadeImage.Range == 1f);
                    fade.FadeOut(fadeTime, () => StartCoroutine(LoadScene(str)));
                }

                //�V�[���̓ǂݍ��ݑ҂�
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
                            text.text = "�ǂݍ��݊���";
                            if (waitCheck)StartCoroutine(LoadingWait(async,str));
                            waitCheck = false;
                        }
                        yield return null;
                    }
                }

                //Loading�I����J��
                public IEnumerator LoadingWait(AsyncOperation async,string str)
                {
                    yield return new WaitForSeconds(2f);//���[�f�B���O����
                    Debug.Log(AddString(AddString("<color=orange><size=13><b>", SceneManager.GetActiveScene().name, "</b></size></color><color=lightblue><size=13><b>�V�[������</b></size></color>"), "<color=orange><size=13><b>", str, "</b></size></color><color=lightblue><size=13><b>�V�[���֑J��</b></size></color>"));

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
               [SerializeField,Header("google�X�v���b�g�V�[�g��ID")] string SHEET_ID = "ID������";
               [SerializeField,Header("�V�[�g��")] string SHEET_NAME = "�V�[�g��������";

                //��s�̕�����
                [SerializeField,Header("��s�̕�����")]int currentCharNum = 0;
                //�s��
                [SerializeField,Header("�s��")]int currentLineNum = 0;
                //�������e�L�X�g�ɏ������܂�鑬��
                private float textInterval = 0f;
                [SerializeField,Header("�\�������e�L�X�g")]
                Text displayText;
                [SerializeField, Header("�������\������鑬��")]
                float charaSpeed = 0f;
                [SerializeField, Header("�b�����Ă���L�����̖��O")]
                Text talkingCharaName = null;
                //google�X�v���b�g�V�[�g�̃f�[�^�ۊǗp
                string[][] arrayTwo;
                //�b���Ă���L�����̖��O�ۊǗp
                List<string> charaName = new List<string>();
                //��ʂɕ\������L�������ۊǗp
                List<string> displayCharaImage = new List<string>();
                //���ʉ�se�ۊǗp
                List<string> soundSe = new List<string>();
                //���͕ۊǗp
                List<string> texts = new List<string>();
                
                //�e�L�X�g�\�����I����Ă��邩�̃`�F�b�N
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
                            Debug.Log("<color=Cyan><size=13><b>���N�G�X�g��...</b></size></color>");
                            break;

                        case UnityWebRequest.Result.Success:
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
                    reader.ReadLine();  //�w�b�_�ǂݔ�΂�
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
                        //��������0�ɂ���
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
                [Header("�S�Ẵ��O�\��:")]
                [SerializeField, Header("Debugger�֐��g�p��:")] bool log0;
                [SerializeField, Header("int�^���O�\��:")]      bool log1;
                [SerializeField, Header("float�^���O�\��:")]    bool log2;
                [SerializeField, Header("double�^���O�\��:")]   bool log3;
                [SerializeField, Header("char�^���O�\��:")]     bool log4;
                [SerializeField, Header("string�^���O�\��:")]   bool log5;
                [SerializeField, Header("Vector2�^���O�\��:")]  bool log6;
                [SerializeField, Header("Vector3�^���O�\��:")]  bool log7;

                private void OnEnable()
                {
                    ServiceLocator<IDebugManager>.Bind(this);
                }

                private void OnDisable()
                {
                    ServiceLocator<IDebugManager>.Unbind(this);
                }

                /// <summary>
                /// �I�u�W�F�N�g�̈�ʓI�ȏ��Log
                /// ����(UnityGameLib UnityGameLib���p����������)
                /// </summary>
                /// <param name="lib">UnityGameLib���p����������</param>
                public void GeneralDebugger(UnityGameLib lib)
                {
                    Debug.Log(AddString("<size=13><b>�A�^�b�`����Ă���I�u�W�F�N�g�� :", lib.gameObject.name,"</b></size>"));
                    Debug.Log(AddString("<size=13><b>����script���L���ł��邩 :", lib.enabled.ToString(), "</b></size>"));
                    Debug.Log(AddString("<size=13><b>�Q�[���I�u�W�F�N�g���A�N�e�B�u�ł���script���L���ł��邩 :", lib.isActiveAndEnabled.ToString(), "</b></size>"));
                    Debug.Log(AddString("<size=13><b>�g�p����Ă���^�O��: ", lib.tag, "</b></size>"));
                    Debug.Log(AddString("<size=13><b>position :", lib.transform.position.ToString(), "</b></size>"));
                    Debug.Log(AddString("<size=13><b>rotation :", lib.transform.rotation.ToString(), "</b></size>"));
                    Debug.Log(AddString("<size=13><b>scale :", lib.transform.localScale.ToString(), "</b></size>"));
                }

                /// <summary>
                /// int�^�̃f�o�b�O�\��
                /// ����(string �f�o�b�O�̍ۂɎg�p������������,int �f�o�b�O�̒l)
                /// </summary>
                /// <param name="s">�f�o�b�O�̍ۂɎg�p������������</param>
                /// <param name="i">�f�o�b�O�̒l</param>
                public void Debugger(string s,int i)
                {
                    if(log1 && log0)
                    {                     
                        Debug.Log(AddString(AddString("<color=cyan><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     i.ToString(), "</b></size></color>"));
                    }
                }


                /// <summary>
                /// float�^�̃f�o�b�O�\��
                /// ����(string �f�o�b�O�̍ۂɎg�p������������,float �f�o�b�O�̒l)
                /// </summary>
                /// <param name="s">�f�o�b�O�̍ۂɎg�p������������</param>
                /// <param name="f">�f�o�b�O�̒l</param>
                public void Debugger(string s, float f)
                {
                    if (log2 && log0)
                    {
                        Debug.Log(AddString(AddString("<color=magenta><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     f.ToString(), "</b></size></color>"));
                    }
                }

                /// <summary>
                /// double�^�̃f�o�b�O�\��
                /// ����(string �f�o�b�O�̍ۂɎg�p������������,double �f�o�b�O�̒l)
                /// </summary>
                /// <param name="s">�f�o�b�O�̍ۂɎg�p������������</param>
                /// <param name="d">�f�o�b�O�̒l</param>
                public void Debugger(string s, double d)
                {
                    if (log3 && log0)
                    {
                        Debug.Log(AddString(AddString("<color=maroon><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     d.ToString(), "</b></size></color>"));
                    }
                }

                /// <summary>
                /// char�^�̃f�o�b�O�\��
                /// ����(string �f�o�b�O�̍ۂɎg�p������������,char �f�o�b�O�̒l)
                /// </summary>
                /// <param name="s">�f�o�b�O�̍ۂɎg�p������������</param>
                /// <param name="c">�f�o�b�O�̒l</param>
                public void Debugger(string s, char c)
                {
                    if (log4 && log0)
                    {
                        Debug.Log(AddString(AddString("<color=orange><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     c.ToString(), "</b></size></color>"));
                    }
                }

                /// <summary>
                /// string�^�̃f�o�b�O�\��
                /// ����(string �f�o�b�O�̍ۂɎg�p������������)
                /// </summary>
                /// <param name="s">�f�o�b�O�̍ۂɎg�p������������</param>
                public void Debugger(string s)
                {
                    if (log5 && log0)
                    {
                        Debug.Log(AddString("<color=lightblue><size=13><b>", s, "</b></size></color>"));
                    }
                }

                /// <summary>
                /// Vector2�^�̃f�o�b�O�\��
                /// ����(string �f�o�b�O�̍ۂɎg�p������������,Vector2 �f�o�b�O�̒l)
                /// </summary>
                /// <param name="s">�f�o�b�O�̍ۂɎg�p������������</param>
                /// <param name="v2">�f�o�b�O�̒l</param>
                public void Debugger(string s,Vector2 v2)
                {
                    if (log6 && log0)
                    {
                        Debug.Log(AddString(AddString("<color=teal><size=13><b>", s, "</b></size></color> "), "<color=yellow><size=13><b>",
                                     v2.ToString(), "</b></size></color>"));
                    }
                }

                /// <summary>
                /// Vector3�^�̃f�o�b�O�\��
                /// ����(string �f�o�b�O�̍ۂɎg�p������������,Vector3 �f�o�b�O�̒l)
                /// </summary>
                /// <param name="s">�f�o�b�O�̍ۂɎg�p������������</param>
                /// <param name="v3">�f�o�b�O�̒l</param>
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
