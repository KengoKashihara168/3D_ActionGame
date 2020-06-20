using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static readonly float MaxStageSize = 300.0f;

    [SerializeField] private Player player = null;
    [SerializeField] private CardManager cardManager = null;

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
        // プレイヤーの更新
        player.UpdatePlayer();
        // カードマネージャの更新
        cardManager.UpdateCard();
    }
}
