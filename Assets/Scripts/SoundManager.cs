using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource               audioSource; // オーディオソース
    private Dictionary<string, float> seEndTimes;   // SEの終了時間

    public void Initialize()
    {
        // オーディオソースの取得
        audioSource = GetComponent<AudioSource>();
        Debug.Assert(audioSource, "AudioSourceがありません");

        // SEの終了時間を初期化
        seEndTimes = new Dictionary<string, float>();
    }

    /// <summary>
    /// SEの再生
    /// </summary>
    /// <param name="clip">SE</param>
    /// <param name="isStopBGM">BGM停止フラグ</param>
    /// <param name="isLoop">SEのループフラグ</param>
    public void PlaySE(AudioClip clip,bool isStopBGM)
    {
        // BGMを停止
        if(isStopBGM) audioSource.Pause();
        // SEの再生
        audioSource.PlayOneShot(clip);
        // 終了時間の設定
        AddEndTime(clip);
    }

    /// <summary>
    /// SEの終了時間を設定
    /// </summary>
    /// <param name="clip">SE</param>
    private void AddEndTime(AudioClip clip)
    {
        string name    = clip.name;               // SEの名前
        float  endTime = Time.time + clip.length; // SEの再生時間
        seEndTimes.Add(name, endTime);
    }

    /// <summary>
    /// SEが再生終了したか判定
    /// </summary>
    /// <param name="seName">SEの名前</param>
    /// <returns></returns>
    public bool IsEndSE(string seName)
    {
        if (seEndTimes[seName] < Time.time) return true;
        return false;
    }
    
}
