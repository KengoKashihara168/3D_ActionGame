using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMove move;
    private LineRenderer line;

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
    }

    /// <summary>
    /// プレイヤーの停止
    /// </summary>
    public void StopPlayer()
    {
        move.Decelerate(Vector3.zero);
    }
}
