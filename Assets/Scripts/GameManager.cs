using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static readonly float MaxStageSize = 300.0f; // ステージのサイズ

    // ゲームの状態
    private enum GameState
    {
        Continue,  // 継続
        GameOver,  // ゲームオーバー
        GameClear, // ゲームクリアー
    }

    [SerializeField] private Player      player      = null; // プレイヤー
    [SerializeField] private CardManager cardManager = null; // カードマネージャー
    [SerializeField] private GameObject  clearPanel  = null; // ゲームクリアパネル

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーの初期化
        player.Initialize();
        // カードマネージャーの初期化
        cardManager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        GameState state = JudgeGameState(); // ゲームの状態

        switch(state)
        {
            case GameState.Continue:
                // ゲームの更新
                UpdateGame();
                break;
            case GameState.GameClear:
                // ゲームクリア後の処理
                GameClear();
                break;
            case GameState.GameOver:
                // ゲームオーバー後の処理
                GameOver();
                break;
        }
    }

    /// <summary>
    /// ゲームの状態を判定
    /// </summary>
    /// <returns>ゲームの状態</returns>
    private GameState JudgeGameState()
    {
        GameState state = GameState.Continue; // ゲームの状態

        // カードをすべて取得していたら
        if (cardManager.isGetAllCards)
        {
            // ゲームクリア
            state = GameState.GameClear;
        }

        return state;
    }

    /// <summary>
    /// ゲームの更新
    /// </summary>
    private void UpdateGame()
    {
        // プレイヤーの更新
        player.UpdatePlayer();
        // カードマネージャの更新
        cardManager.UpdateCard();
    }

    /// <summary>
    /// ゲームクリア後の処理
    /// </summary>
    private void GameClear()
    {
        Debug.Log("ゲームクリア！");

        // プレイヤーの移動停止
        player.StopPlayer();
        // ゲームクリアパネルを表示
        clearPanel.SetActive(true);
    }

    /// <summary>
    /// ゲームオーバー処理
    /// </summary>
    private void GameOver()
    {
        Debug.Log("ゲームオーバー...");
    }
}
