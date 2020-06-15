﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private readonly int MaxCardCount = 12;
    private readonly float CardPositionY = 6.0f;

    [SerializeField] private GameObject   cardPrefab   = null;
    [SerializeField] private Material[]   cardMaterial = null;
    [SerializeField] private Score        score        = null; // スコア

    private Card[]  cards;      // カードリスト
    private int beforeIndex; // 前に獲得したカード

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        // 変数の初期化
        cards = new Card[MaxCardCount];
        beforeIndex = -1;

        // カードの生成
        CreateCard();
        // カードの初期化
        InitializeCard();

        // スコアの初期化
        score.InitializeScore();
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
        // カードを生成できるか確認
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
            cards[i] = card.GetComponent<Card>();
        }
    }

    private void InitializeCard()
    {
        // カードの情報を設定
        SetCardData();
        // カードのマテリアルを設定
        SetMaterial();
        // カードの座標を設定
        SetCardPosition();
    }

    /// <summary>
    /// カードの情報を設定
    /// </summary>
    private void SetCardData()
    {
        for (int i = 0; i < MaxCardCount; i++)
        {
            Junishi eto = (Junishi)i;
            cards[i].Initialize(eto);
            cards[i].name = eto.ToString();
        }
    }

    /// <summary>
    /// カードのマテリアルを設定
    /// </summary>
    private void SetMaterial()
    {
        for (int i = 0; i < MaxCardCount; i++)
        {
            MeshRenderer renderer = cards[i].GetComponent<MeshRenderer>();
            renderer.material = cardMaterial[i];
        }
    }

    private void SetCardPosition()
    {
        float range = (GameManager.MaxStageSize / 2) - (cards[0].transform.localScale.x); // 座標の範囲
        for (int i = 0; i < MaxCardCount; i++)
        {
            Vector3 pos = Vector3.zero;
            pos.x = Random.Range(-range, range);
            pos.y = CardPositionY;
            pos.z = Random.Range(-range, range);

            cards[i].transform.position = pos;
        }
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

    /// <summary>
    /// カードが取得されたかチェックする
    /// </summary>
    private int CheckCardGetting()
    {
        int index = -1;

        for(int i = 0;i < MaxCardCount;i++)
        {
            if (cards[i].isGetting && cards[i].gameObject.activeSelf)
            {
                index = i;
                Debug.Log("取得されたカードのインデックス：" + index);
                return index;
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
        // 正しい順番で取得したか判定
        if(IsGetRightOrder(index))
        {
            // スコアを反映する
            ReflectedInScore(index);
            // 取得したカードのインデックスを保持
            beforeIndex = index;
            // カードを非表示にする
            HideCard(index);
        }
        else
        {
            cards[index].GetFailure();
            Debug.Log("正しい順番ではありません");
        }
    }

    /// <summary>
    /// スコアを反映
    /// </summary>
    private void ReflectedInScore(int index)
    {
        int point = 100; // 得点

        // 加点
        score.AddScore(point);
    }

    /// <summary>
    /// 正しい順番で獲得されているか判定
    /// </summary>
    /// <param name="index">取得カードのインデックス</param>
    /// <returns>正順判定結果</returns>
    private bool IsGetRightOrder(int index)
    {
        bool isOrder = true;                // 正順フラグ
        int  diff    = index - beforeIndex; // インデックスの差

        // 前のカードとの差が１以外なら
        if (diff > 1) isOrder = false;

        return isOrder;
    }

    /// <summary>
    /// カードを非表示
    /// </summary>
    /// <param name="index">カードのインデックス</param>
    private void HideCard(int index)
    {
        Junishi eto = cards[index].GetJunishi();
        Debug.Log(eto + "を非表示");
        cards[index].gameObject.SetActive(false);
    }
}
