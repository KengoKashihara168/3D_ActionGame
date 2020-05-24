using System.Collections;
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
    private CardData data;

    // Start is called before the first frame update
    void Start()
    {
        data.suit   = Suit.Spade;
        data.number = Number.Ace;
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
        }
    }
}
