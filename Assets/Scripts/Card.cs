﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Number
{
    Ace   = 1,
    Two   = 2,
    Three = 3,
    Four  = 4,
    Five  = 5,
    Six   = 6,
    Seven = 7,
    Eight = 8,
    Nine  = 9,
    Ten   = 10,
    Jack  = 11,
    Queen = 12,
    King  = 13,
}

public enum Suit
{
    Spade,
    Heart,
    Club,
    Diamond,
}

public struct CardData
{
    public Suit suit;
    public Number number;
}

public class Card : MonoBehaviour
{
    public bool isGetting { get; private set; }
    public CardData data;

    private void Awake()
    {
        data.suit = Suit.Spade;
        data.number = Number.Ace;
        isGetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーと衝突
        if(other.tag.Equals("Player"))
        {
            Debug.Log("Player Hit");
            isGetting = true;
        }
    }

    /// <summary>
    /// カードの情報を設定
    /// </summary>
    /// <param name="suit">柄</param>
    /// <param name="number">数字</param>
    public void SetCardData(Suit suit,Number number)
    {
        data.suit = suit;
        data.number = number;
    }

    /// <summary>
    /// カード情報を取得
    /// </summary>
    /// <returns>カード情報</returns>
    public CardData GetCardData()
    {
        return data;
    }
}