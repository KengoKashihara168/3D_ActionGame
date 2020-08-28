using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager = null; // サウンドマネージャー
    [SerializeField] private AudioClip    runningSE    = null; // 走るSE
    private PlayerMove move;

    public void Initialize()
    {
        Debug.Log("Playerの初期化");
        move = GetComponent<PlayerMove>();
        move.Initialize();
    }

    public void UpdatePlayer()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir += Vector3.right;
        }

        move.Movement(dir);

        RunningSE();
    }

    private void RunningSE()
    {
        if (move.IsMoving())
        {
            soundManager.PlaySE(runningSE);
        }
        else
        {
            soundManager.StopSE(runningSE);
        }
    }

    /// <summary>
    /// プレイヤーの停止
    /// </summary>
    public void StopPlayer()
    {
        move.Decelerate(Vector3.zero);
    }
}
