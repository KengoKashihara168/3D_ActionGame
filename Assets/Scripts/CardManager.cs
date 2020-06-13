using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private readonly int MaxCardCount = 12;
    private readonly float CardPositionY = 6.0f;

    [SerializeField] private GameObject   cardPrefab   = null;
    [SerializeField] private Material[]   cardMaterial = null;
    [SerializeField] private Score        score        = null; // スコア

    private List<Card> cards; // カードリスト

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        // カードリストの初期化
        cards = new List<Card>();

        // カードの生成
        CreateCard();

        foreach (var card in cards)
        {
            // カードの値を設定
            card.SetCardData(Suit.Heart, Number.Ace);
        }

        // スコアの初期化
        score.InitializeScore();
    }

    /// <summary>
    /// カードの更新
    /// </summary>
    public void UpdateCard()
    {
        // カードが取得されたかチェック
        int getIndex = CheckCardGetting();

        // カードが取得されていれば
        if (getIndex >= 0)
        {
            // カードの取得
            GetCard(getIndex);
        }
    }

    private bool IsSetCardMaterial()
    {
        if (cardPrefab == null)                 return false;
        if (cardMaterial == null)               return false;
        if (cardMaterial.Length < MaxCardCount) return false;
        if (cardMaterial.Length > MaxCardCount) return false;

        return true;
    }

    /// <summary>
    /// カードの生成
    /// </summary>
    private void CreateCard()
    {
        if (IsSetCardMaterial() == false)
        {
            Debug.LogError("カード生成できませんでした");
            return;
        }

        for(int i = 0;i < MaxCardCount;i++)
        {
            // カードの生成
            GameObject card = GameObject.Instantiate(cardPrefab);
            // カードリストに登録
            cards.Add(card.GetComponent<Card>());
        }
    }

    private void InitializeCard()
    {

    }

    /// <summary>
    /// カードが取得されたかチェックする
    /// </summary>
    private int CheckCardGetting()
    {
        int index = -1;

        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].isGetting)
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
