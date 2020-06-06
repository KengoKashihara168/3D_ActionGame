using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    [SerializeField] private Text text = null;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 加点
    /// </summary>
    /// <param name="point">点数</param>
    public void AddScore(int point)
    {
        score += point;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = "スコア：" + score;
    }
}
