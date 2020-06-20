using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private GameObject clearPanel = null; // ゲームクリアパネル

    public void Initialize()
    {
        clearPanel.SetActive(false);
    }

    public void UpdateGameClearManager()
    {
        ShowPanel();
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
