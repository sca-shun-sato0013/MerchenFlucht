using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

namespace CommonlyUsed
{
    public static class ImageLoading 
    {
        /// <summary>
        /// 画像を指定のフォルダから読み込む関数
        /// 引数(Image 返される画像, string 画像があるパス,bool 条件があれば)
        /// </summary>
        public static void ImageLoadingAsync(Image image, string imagePath,AsyncOperationHandle<Sprite> s, bool check = true)
        {
            bool b = false;
            if (check)
            {
                Addressables.LoadAssetAsync<Sprite>(imagePath).Completed += sprite =>
                {
                    image.sprite = Object.Instantiate(sprite.Result);
                };               
            }
        }
    }
}