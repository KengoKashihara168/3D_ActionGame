using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    // 定数
    private readonly string NextScene = "GameScene"; // 次のシーン

    // 外部設定変数
    [SerializeField] private AudioClip soundEffect = null;  // SE
    [SerializeField] private float     sePlayTime  = 0.0f;  // SEの再生時間
    [SerializeField] private bool      isStopBGM   = false; // SE再生時にBGMを停止するフラグ

    private SoundManager sound;     // サウンド
    private bool         isPushKey; // キーが入力されたフラグ

    // Start is called before the first frame update
    void Start()
    {
        // サウンドの初期化
        sound = GetComponent<SoundManager>();
        sound.Initialize();
        // ボタン押下フラグの初期化
        isPushKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        // キーが押され、かつまだ押されていなければ
        if(Input.GetKeyDown(KeyCode.Space) && isPushKey == false)
        {
            isPushKey = true;
            // SEの再生
            sound.PlaySE(soundEffect);
        }

        if(isPushKey)
        {
            // シーン遷移
            ChangeScene();
        }
        
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    private void ChangeScene()
    {
        // SEの再生が終了していたら
        if(sound.IsEndSE(soundEffect.name,sePlayTime))
        {
            SceneManager.LoadScene(NextScene);
        }
    }

}
