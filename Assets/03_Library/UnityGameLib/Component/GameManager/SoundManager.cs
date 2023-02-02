using UnityEngine;
using DesignPattern;

namespace GameManager
{

    public interface ISoundManager
    {
        void PlayBGM(int bgmManager);
        void PlaySE(int seNumber);
    }

    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : Singleton<SoundManager> ,ISoundManager
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip[] soundBGM;
        [SerializeField] AudioClip[] soundSE;

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
