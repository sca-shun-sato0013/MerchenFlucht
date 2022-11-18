using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using NUnityGameLib.NDesignPattern.NSingleton;
//using Cysharp.Threading.Tasks;

//���O���
//���̒���class��֐����g���Ƃ���using������
namespace NUnityGameLib
{
    interface IUnityGameLib
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
            interface ISingleton
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
    }

    namespace NPlayerController
    {
        namespace NControllerPC
        {
            interface IControllerPC
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
                public virtual Transform GetKeyPositionMoveUp(GameObject obj, float speed)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    {
                        obj.transform.position += Vector3.forward * speed * Time.deltaTime;
                    }
                    return obj.transform;
                }

                public virtual Transform GetKeyPositionMoveDown(GameObject obj, float speed)
                {
                    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    {
                        obj.transform.position += Vector3.back * speed * Time.deltaTime;
                    }
                    return obj.transform;
                }

                public virtual Transform GetKeyPositionMoveRight(GameObject obj, float speed)
                {
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        obj.transform.position += transform.right * speed * Time.deltaTime;
                    }
                    return obj.transform;
                }

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

            interface ISoundManager
            {
                void PlayBGM(AudioClip bgmManager);
                void PlaySE(int seNumber);
            }

            [RequireComponent(typeof(AudioSource))]
            public abstract class SoundManager : Singleton<SoundManager>,IUnityGameLib,ISingleton,ISoundManager
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

                public void SceneLodingAsync(string str)
                {
                    fade.FadeIn(fadeTime, () => obj.SetActive(true));
                    StartCoroutine(FadeWait(str));                      
                }
   
                IEnumerator FadeWait(string str)
                {
                    yield return new WaitUntil(() => fadeImage.Range == 1f);
                    fade.FadeOut(fadeTime, () => StartCoroutine(LoadScene(str)));
                }
                IEnumerator LoadScene(string str)
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

                IEnumerator LoadingWait(AsyncOperation async,string str)
                {
                    yield return new WaitForSeconds(1f);
                    Debug.Log(AddString(AddString("<color=orange><size=13><b>", SceneManager.GetActiveScene().name, "</b></size></color><color=lightblue><size=13><b>�V�[������</b></size></color>"), "<color=orange><size=13><b>", str, "</b></size></color><color=lightblue><size=13><b>�V�[���֑J��</b></size></color>"));

                    fade.FadeIn(fadeTime, () => async.allowSceneActivation = true);
                }
            }
        }

        namespace NScenarioManager
        {
            interface IScenarioManager
            {

            }
            public abstract class ScenarioManager : Singleton<ScenarioManager>,IUnityGameLib,IScenarioManager,ISingleton
            {
               [SerializeField] string SHEET_ID = "ID������";
               [SerializeField] string SHEET_NAME = "�V�[�g��������";

                IEnumerator Method(string _SHEET_NAME)
                {
                    UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + SHEET_ID + "/gviz/tq?tqx=out:csv&sheet=" + _SHEET_NAME);
                    yield return request.SendWebRequest();

                    switch(request.result)
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

                        //�����̒l���A�Ăяo���ꂽ���\�b�h�Œ�`����Ă��鋖�e�͈͊O�ł���ꍇ�ɃX���[������O�B
                        default: throw new ArgumentOutOfRangeException();

                    }


                    string str = request.downloadHandler.text;

                        Debug.Log(request.downloadHandler.text);
                   
                }
                public void ReLoadGoogleSheet()
                {
                    StartCoroutine(Method(SHEET_NAME));
                }
            }
        }

        namespace NDebugManager
        {
            interface IDebugManager
            {
                void GeneralDebugger(UnityGameLib lib);
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

                public void GeneralDebugger(UnityGameLib lib)
                {
                    string str�@= AddString("�A�^�b�`����Ă���I�u�W�F�N�g�� :", lib.gameObject.name);
                    string str1 = AddString("����script���L���ł��邩 :",lib.enabled.ToString());
                    string str2 = AddString("�Q�[���I�u�W�F�N�g���A�N�e�B�u�ł���script���L���ł��邩 :", lib.isActiveAndEnabled.ToString());
                    string str3 = AddString("�g�p����Ă���^�O��: ", lib.tag);
                    string str4 = AddString("position :", lib.transform.position.ToString());
                    string str5 = AddString("rotation :", lib.transform.rotation.ToString());
                    string str6 = AddString("scale :", lib.transform.localScale.ToString());
            
                    Debug.Log(str);
                    Debug.Log(str1);
                    Debug.Log(str2);
                    Debug.Log(str3);
                    Debug.Log(str4);
                    Debug.Log(str5);
                    Debug.Log(str6);
                }

                public void Debugger(string s,int i)
                {
                    if(log1 && log0)
                    {
                        string str = AddString(s, i.ToString());
                        Debug.Log(str);
                    }
                }

                public void Debugger(string s, float f)
                {
                    if (log2 && log0)
                    {
                        string str = AddString(s, f.ToString());
                        Debug.Log(str);
                    }
                }

                public void Debugger(string s, double d)
                {
                    if (log3 && log0)
                    {
                        string str = AddString(s, d.ToString());
                        Debug.Log(str);
                    }
                }

                public void Debugger(string s, char c)
                {
                    if (log4 && log0)
                    {
                        string str = AddString(s, c.ToString());
                        Debug.Log(str);
                    }
                }

                public void Debugger(string s)
                {
                    if (log5 && log0)
                    {
                        Debug.Log(s);
                    }
                }

                public void Debugger(string s,Vector2 v2)
                {
                    if (log6 && log0)
                    {
                        string str = AddString(s, v2.ToString());
                        Debug.Log(str);
                    }
                }

                public void Debugger(string s, Vector3 v3)
                {
                    if (log7 && log0)
                    {
                        string str = AddString(s, v3.ToString());
                        Debug.Log(str);
                    }
                }
            }
        }
    } 
}
