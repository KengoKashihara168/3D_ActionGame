using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 十二支の列挙
public enum Junishi
{
    Ne,      // 子
    Ushi,    // 丑
    Tora,    // 寅
    U,       // 卯
    Tatsu,   // 辰
    Mi,      // 巳
    Uma,     // 午
    Hitsuji, // 未
    Saru,    // 申
    Tori,    // 酉
    Inu,     // 戌
    I,       // 亥
}

public class Card : MonoBehaviour
{
    public bool isHitting { get; private set; }
    private Junishi eto;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="type">カードの干支</param>
    public void Initialize(Junishi type)
    {
        eto = type;
        isHitting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーと衝突
        if(other.tag.Equals("Player"))
        {
            Debug.Log("Player Hit");
            isHitting = true;
        }
    }

    /// <summary>
    /// 十二支の取得
    /// </summary>
    /// <returns>十二支</returns>
    public Junishi GetJunishi()
    {
        return eto;
    }

    /// <summary>
    /// 取得失敗
    /// </summary>
    public void GetFailure()
    {
        isHitting = false;
    }
}
