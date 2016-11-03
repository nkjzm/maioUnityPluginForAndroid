using UnityEngine;

public static class MaioAndroid
{
#if UNITY_ANDROID && !UNITY_EDITOR
    static string MaioAds = "jp.maio.sdk.android.MaioAds";
    static string MaioAdsListener = "jp.maio.sdk.android.MaioAdsListener";
#endif

    /// <summary>
    /// maio SDK のバージョンを返します。
    /// </summary>
    /// <value>maio SDK のバージョン</value>
    public static string SdkVersion
    {
        get
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            using (AndroidJavaClass plugin = new AndroidJavaClass(MaioAds))
            {
                return plugin.CallStatic<string>("getSdkVersion");
            }
#else
            return null;
#endif
        }
    }

    /// <summary>
    /// 広告の配信テストを行うかどうかを設定します。
    /// </summary>
    /// <param name="adTestMode">広告のテスト配信を行う場合には <c>true</>、それ以外なら <c>false</c>。アプリ開発中は <c>true</c> にし、ストアに提出する際には <c>false</c> にして下さい（既定値は <c>false</c>）。</param>
    public static void SetAdTestMode(bool adTestMode)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass plugin = new AndroidJavaClass(MaioAds))
        {
            plugin.CallStatic("setAdTestMode",adTestMode);
        }
#endif
    }

    /// <summary>
    /// SDK のセットアップを開始します。
    /// </summary>
    /// <param name="mediaId">管理画面にて発行されるアプリ識別子</param>
    public static void Start(string mediaId)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // Unity インスタンスを取得
        var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        // 現在のアクティビティを取得
        var activ = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        // 空のListenerオブジェクトを作成
        var listener = new AndroidJavaObject(MaioAdsListener);

        using (AndroidJavaClass plugin = new AndroidJavaClass(MaioAds))
        {
            plugin.CallStatic("init", activ, mediaId, listener);
        }
#endif
    }

    /// <summary>
    /// 指定したゾーンの広告表示準備が整っていれば YES、そうでなければ NO を返します。
    /// </summary>
    /// <param name="zoneId">広告の表示準備が整っているか確認したいゾーンの識別子</param>
    /// <returns></returns>
    public static bool CanShow(string zoneId)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass plugin = new AndroidJavaClass(MaioAds))
        {
            return plugin.CallStatic<bool>("canShow", zoneId);
        }
#else
        return false;
#endif
    }
    /// <summary>
    /// 既定のゾーンの広告表示準備が整っていれば YES、そうでなければ NO を返します。
    /// </summary>
    /// <returns></returns>
    public static bool CanShow()
    {
        return CanShow(null);
    }

    /// <summary>
    /// 指定したゾーンの広告を表示します。
    /// </summary>
    /// <param name="zoneId">広告を表示したいゾーンの識別子</param>
    public static void Show(string zoneId)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass plugin = new AndroidJavaClass(MaioAds))
        {
            plugin.CallStatic("show", zoneId);
        }
#endif
    }
    /// <summary>
    /// 既定のゾーンの広告を表示します。
    /// </summary>
    public static void Show()
    {
        Show(null);
    }
}