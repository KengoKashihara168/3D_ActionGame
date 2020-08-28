﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource               audioSource; // オーディオソース
    private Dictionary<string, float> seEndTimes;   // SEの終了時間
    private Dictionary<string, AudioSource> soundEffects;

    public void Initialize()
    {
        // オーディオソースの取得
        audioSource = GetComponent<AudioSource>();
        Debug.Assert(audioSource, "AudioSourceがありません");

        // SEの終了時間を初期化
        seEndTimes = new Dictionary<string, float>();

        // SE配列の初期化
        soundEffects = new Dictionary<string, AudioSource>();
    }

    /// <summary>
    /// SEの再生
    /// </summary>
    /// <param name="clip">SE</param>
    /// <param name="isLoop">SEのループフラグ</param>
    /// <param name="isStopBGM">BGM停止フラグ</param>
    public void PlaySE(AudioClip clip,float endTime = 99.9f, bool isStopBGM = false)
    {
        if (IsEndSE(clip.name, endTime) == false) return;

        // BGMを停止
        if (isStopBGM) audioSource.Pause();

        // SEを追加
        AddSE(clip);

        // SEを再生
        soundEffects[clip.name].Play();

        Debug.Log(clip.name + "の再生");
    }

    public void StopSE(AudioClip clip)
    {
        if (IsEndSE(clip.name, clip.length)) return;
        string seName = clip.name;
        soundEffects[seName].Stop();
    }

    /// <summary>
    /// SEの追加
    /// </summary>
    /// <param name="clip">SE</param>
    /// <param name="isLoop">ループフラグ</param>
    private void AddSE(AudioClip clip)
    {
        if (soundEffects.ContainsKey(clip.name)) return;

        var se = gameObject.AddComponent<AudioSource>();
        se.clip = clip;
        se.loop = false;
        soundEffects.Add(clip.name, se);
    }

    /// <summary>
    /// SEが再生終了したか判定
    /// </summary>
    /// <param name="seName">SEの名前</param>
    /// <returns></returns>
    public bool IsEndSE(string seName,float endTime)
    {
        if (soundEffects.ContainsKey(seName) == false) return true;

        bool isEndSE = false; // SEが終了したか
        if (soundEffects[seName].isPlaying == false)        isEndSE = true;
        if (soundEffects[seName].time > Mathf.Abs(endTime)) isEndSE = true;
        return isEndSE;
    }
    
}
