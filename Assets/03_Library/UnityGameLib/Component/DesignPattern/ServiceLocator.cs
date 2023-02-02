using CommonlyUsed;

namespace DesignPattern
{
    /// <summary>
    /// サービスロケータクラス
    /// サービス(機能を提供するクラス)のありかを示してくれるもの
    /// プログラムを特定の実装に依存させずに動作させたいときに用いる実装手法の一つ
    /// デザインパターンの一種(ServiceLocator)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public static class ServiceLocator<T> where T : class
    {
        public static T Instance { get; private set; }

        //nullじゃないかチェック
        public static bool IsValid() => Instance != null;

        //インスタンスを外部から設定する為
        public static void Bind(T instance)
        {
            Instance = instance;
        }

        //インスタンスをnullに設定する為
        public static void Unbind(T instance)
        {
            if (Instance == instance)
            {
                Instance = null;
            }
        }

        //強制的にnullにする
        public static void Clear()
        {
            Instance = null;
        }
    }
}