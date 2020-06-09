using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CardManager cardManager = null;

    // Start is called before the first frame update
    void Start()
    {
        // カードマネージャーの初期化
        cardManager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // カードマネージャの更新
        cardManager.UpdateCard();
    }
}
