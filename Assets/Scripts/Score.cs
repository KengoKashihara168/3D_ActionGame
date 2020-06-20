using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text text = null; // スコア表示用テキスト
    private int score;                         // スコア
 
    /// <summary>
    /// スコアの初期化
    /// </summary>
    public void InitializeScore()
    {
        score = 0;
        UpdateText();
    }

    /// <summary>
    /// 加点
    /// </summary>
    /// <param name="point">点数</param>
    public void AddScore(int point)
    {
        score += point;
        UpdateText();
    }

    /// <summary>
    /// 点数のリセット
    /// </summary>
    public void ResetScore()
    {
        score = 0;
        UpdateText();
    }

    /// <summary>
    /// テキストの更新
    /// </summary>
    private void UpdateText()
    {
        text.text = score.ToString();
    }
}
