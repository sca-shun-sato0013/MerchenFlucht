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
