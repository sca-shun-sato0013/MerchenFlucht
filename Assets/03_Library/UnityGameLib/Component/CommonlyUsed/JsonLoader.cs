using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using GameManager;
using CommonlyUsed;
using DesignPattern;

namespace NJsonLoader
{

    public interface IJsonLoader
    {
        void SaveStatusData<T>(T status, string str);
        T LoadStatusData<T>(string str);
    }

    public class JsonLoader : MonoBehaviour,IJsonLoader
    {
        private void OnEnable()
        {
            ServiceLocator<IJsonLoader>.Bind(this);
        }

        private void OnDisable()
        {
            ServiceLocator<IJsonLoader>.Unbind(this);
        }

        public void SaveStatusData<T>(T status, string saveName)
        {
            StreamWriter writer;

            string jsonstr = JsonUtility.ToJson(status);
            //Application.DataPath/02_Develop/10_Json/
            writer = new StreamWriter(StringComponent.AddString(Application.persistentDataPath,"/", saveName, ".json"),false);
            writer.Write(jsonstr);
            writer.Flush();
            writer.Close();
        }

        public T LoadStatusData<T>(string loadName)
        {
            string datastr = "";
            StreamReader reader;
            //Application.DataPath/02_Develop/10_Json/
            reader = new StreamReader(StringComponent.AddString(Application.persistentDataPath, "/", loadName, ".json"));
            datastr = reader.ReadToEnd();
            reader.Close();

            return JsonUtility.FromJson<T>(datastr);
        }
    }
}