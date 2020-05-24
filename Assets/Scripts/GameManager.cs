using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private readonly int TimeBonus = 100;            // 時間による加点
    private readonly float BonusValidityTime = 5.0f; // ボーナス有効時間

    [SerializeField] private Card card = null;
    [SerializeField] private Score score = null;

    private Suit subjectSuit;   // 課題の柄
    private int currentNumber;  // 現在の数字
    private int acquiredNumber; // 取得枚数

    // Start is called before the first frame update
    void Start()
    {
        subjectSuit = Suit.Heart;
        GameManager manager = GetComponent<GameManager>();
        card.SetGameManager(manager);
        card.SetCardData(Suit.Heart, Number.Ace);
        
        currentNumber = 0;
        acquiredNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// カード取得通知
    /// </summary>
    /// <param name="card">取得したカード</param>
    public void CardAcquisitionNotification(CardData card)
    {
        int point = 0; // ポイント

        Debug.Log("Suit = " + card.suit + " ,Number = " + card.number);

        if (card.suit == subjectSuit) point += 100;

        Debug.Log(point);
        score.AddScore(point);
    }
}
