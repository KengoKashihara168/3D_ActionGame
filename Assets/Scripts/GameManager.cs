using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Card> cards = null;
    [SerializeField] private Score score = null;

    // Start is called before the first frame update
    void Start()
    {
        // カードの初期化
        InitializeCards();
    }

    // Update is called once per frame
    void Update()
    {
        // カードが取得されたかチェック
        CheckCardGetting();
    }

    /// <summary>
    /// カードの初期化
    /// </summary>
    private void InitializeCards()
    {
        foreach(var card in cards)
        {
            // カードの値を設定
            card.SetCardData(Suit.Heart, Number.Ace);
        }
    }

    /// <summary>
    /// カードの更新
    /// </summary>
    private void UpdateCards()
    {
        // カードが取得されたかチェック
        int getIndex = CheckCardGetting();

        // カードが取得されていれば
        if(getIndex > 0)
        {
            // カードの取得
            GetCard(getIndex);
        }
    }

    /// <summary>
    /// カードが取得されたかチェックする
    /// </summary>
    private int CheckCardGetting()
    {
        int index = 0;

        for(int i = 0;i < cards.Count;i++)
        {
            if(cards[i].isGetting)
            {
                index = i;
                Debug.Log("取得されたカードのインデックス：" + index);
            }
        }

        return index;
    }

    /// <summary>
    /// カードの取得
    /// </summary>
    /// <param name="index">カードのインデックス</param>
    private void GetCard(int index)
    {
        // スコアを反映する
        ReflectedInScore();
        // カードを削除する
        DeleteCard(index);
    }

    /// <summary>
    /// スコアを反映
    /// </summary>
    private void ReflectedInScore()
    {
        int point = 100; // 得点

        // 加点
        score.AddScore(point);
    }

    /// <summary>
    /// カードを削除
    /// </summary>
    /// <param name="index">カードのインデックス</param>
    private void DeleteCard(int index)
    {
        CardData card = cards[index].GetCardData();
        Debug.Log(card.suit + "の" + card.number + "を削除");
        cards.RemoveAt(index);
    }

}
