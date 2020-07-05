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
    public readonly float CardPositionY = 6.0f;
    private readonly float MaxHeight = 20.0f;
    
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

    /// <summary>
    /// カードの更新
    /// </summary>
    public void CardUpdate()
    {
        // フワフワとした運動
        transform.position = MoveFluffy(transform.position);
    }

    /// <summary>
    /// フワフワと運動
    /// </summary>
    /// <param name="pos">現在の座標</param>
    /// <returns>移動した座標</returns>
    private Vector3 MoveFluffy(Vector3 pos)
    {
        Vector3 move = pos;                  // 移動した座標
        float   y    = CardPositionY;        // 高さ
        float   sin  = Mathf.Sin(Time.time); // サイン波

        // フワフワとした運動の計算
        y += MaxHeight * (sin + 1.0f) / 2;
        move.y = y;

        return move;
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
