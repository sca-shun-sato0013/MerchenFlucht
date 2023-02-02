using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPattern;


namespace GameManager
{
        /// <summary>
        /// フレーム制御の影響を受けるか
        /// </summary>
        public enum FrameControl
        {
            ON,
            OFF,
        }

        public interface IUpdateManager
        {
            /// <summary>
            /// フレームごとにOnUpdate関数が呼ばれる
            /// </summary>
            /// <param name="deltaTime"></param>
            void OnUpdate(double deltaTime);
        }

        /// <summary>
        /// Update関数を管理するclass
        /// </summary>
        public class UpdateManager : Singleton<UpdateManager>
        {
            [Header("FrameControlがON")]
            [SerializeField,Header("オブジェクト数")]
            
            private short objOnCount;

            [Header("FrameControlがOFF")]
            [SerializeField, Header("オブジェクト数")]
            
            private short objOFFCount;

            private List<IUpdateManager> objON,objOFF;

            private  bool frameState;

            public override void Init()
            {
                frameState = false;
                objON = new List<IUpdateManager>(objOnCount);
                objOFF = new List<IUpdateManager>(objOFFCount);
            }

            public void Bind(IUpdateManager u,FrameControl f)
            {
            
                switch (f)
                {
                    case FrameControl.ON:

                        objON.Add(u);

                        break;

                    case FrameControl.OFF:

                        objOFF.Add(u);

                        break;
                }
            }

            public void UnBind(IUpdateManager u, FrameControl f)
            {
                switch (f)
                {
                    case FrameControl.ON:

                        objON.Remove(u);

                        break;

                    case FrameControl.OFF:

                        objOFF.Remove(u);

                        break;
                }
            }

            /// <summary>
            /// OnUpdate関数のフレーム処理を開始
            /// </summary>
            public void FrameStart()
            {
                bool start = false;
                
                frameState = start;
                
            }

            /// <summary>
            /// OnUpdate関数のフレーム処理を停止
            /// </summary>
            public void FrameStop()
            {
                bool stop = true;

                frameState = stop;
            }

            private void FrameControls(List<IUpdateManager> list,double d)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].OnUpdate(d);
                }
            }

            private void Frame()
            {
                double deltaTime = Time.deltaTime;

                FrameControls(objOFF,deltaTime);

                if (frameState) return;

                FrameControls(objON, deltaTime);
            }

            void Update()
            {                
                Frame();
            }                       
        }   
}
