using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private GameObject clearPanel = null; // ゲームクリアパネル

    public bool isPushSpace { get; private set; } // スペースキー押下フラグ

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        clearPanel.SetActive(false);
        isPushSpace = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void UpdateGameClearManager()
    {
        // パネルの表示
        ShowPanel();

        // スペースキーが押されたら
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // スペースキー押下フラグをtrue
            isPushSpace = true;
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
