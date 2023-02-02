using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace CommonlyUsed
{
    public static class CSVLoading 
    {
        public static List<string[]> CSVLoadAsync(List<string[]> csvDatas,string csvPath)
        {
            Addressables.LoadAssetAsync<TextAsset>(csvPath).Completed += charaData =>
            {
                StringReader reader = new StringReader(charaData.Result.text);

                while (reader.Peek() != -1)
                {
                    string line = reader.ReadLine();
                    csvDatas.Add(line.Split(','));
                }
                
            };

            return csvDatas;
        }
    }          
}
