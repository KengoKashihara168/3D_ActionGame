using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearManager : MonoBehaviour
{
    private readonly float MaxOverTime = 1.0f;

    [SerializeField] private GameObject clearPanel = null; // ゲームクリアパネル

    public bool isTimeOver { get; private set; } // スペースキー押下フラグ
    private float elapsedTime;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        clearPanel.SetActive(false);
        isTimeOver = false;
        elapsedTime = 0.0f;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void UpdateGameClearManager()
    {
        // パネルの表示
        //ShowPanel();
        // 経過時間の加算
        elapsedTime += Time.deltaTime;

        // スペースキーが押されたら
        if(elapsedTime > MaxOverTime)
        {
            // スペースキー押下フラグをtrue
            isTimeOver = true;
        }
    }

    /// <summary>
    /// パネルの表示
    /// </summary>
    private void ShowPanel()
    {
        if (clearPanel.activeSelf) return;
        clearPanel.SetActive(true);
    }
}
