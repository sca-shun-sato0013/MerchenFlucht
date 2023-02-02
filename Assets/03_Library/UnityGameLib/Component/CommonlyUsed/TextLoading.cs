using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;

namespace CommonlyUsed
{
    public static class TextLoading
    {
        public static List<string> TextLoadAsync(List<string> texts, string textPath)
        {
            Addressables.LoadAssetAsync<TextAsset>(textPath).Completed += novelData =>
            {
                StringReader reader = new StringReader(novelData.Result.text);

                while (reader.Peek() != -1)
                {

                    string line = reader.ReadLine();
                    texts.Add(line);
                }

            };

            return texts;
        }
    }

}
