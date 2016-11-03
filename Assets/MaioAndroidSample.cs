using UnityEngine;
using UnityEngine.UI;

public class MaioAndroidSample : MonoBehaviour
{
    /// maio から発行されるメディアIDに差し替えてください。
    public const string MEDIA_ID = "DemoPublisherMedia";

    void Start()
    {
        Debug.Log("maio SDK " + MaioAndroid.SdkVersion);

        Button btnAdZone = GameObject.Find("btnAdZone").GetComponent<Button>();
        btnAdZone.onClick.AddListener(() =>
        {
            Debug.Log("MaioAndroid.CanShow(); " + MaioAndroid.CanShow());
            // 動画広告を表示
            if (MaioAndroid.CanShow())
            {
                MaioAndroid.Show();
            }
        });
        Text txtAdZone = btnAdZone.GetComponentsInChildren<Text>()[0];

        // 広告の配信テスト設定を行います。アプリをリリースする際にはコメントアウトして下さい。
        MaioAndroid.SetAdTestMode(true);

        // SDK のセットアップを開始します。
        MaioAndroid.Start(MEDIA_ID);

        txtAdZone.text = "Loading Ad";
    }
}