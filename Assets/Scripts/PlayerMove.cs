using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float MaxSpeed = 0.0f;
    [SerializeField] private float moveSpeed = 0.0f;

    private Rigidbody rigid;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        rigid = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="dir">移動する方向</param>
    public void Movement(Vector3 dir)
    {
        Decelerate(dir);

        if (rigid.velocity.sqrMagnitude >= MaxSpeed * MaxSpeed) return;
        Vector3 force = dir.normalized * moveSpeed;
        rigid.AddForce(force);
    }

    /// <summary>
    /// 減速
    /// </summary>
    public void Decelerate(Vector3 dir)
    {
        Vector3 vel = rigid.velocity;

        // 左右キーが入力されていなければ
        if(Mathf.Approximately(dir.x,0.0f))
        {
            vel.x = 0.0f;
        }
        // 上下キーが入力されていなければ
        if (Mathf.Approximately(dir.z, 0.0f)) 
        {
            vel.z = 0.0f;
        }
        rigid.velocity = vel;
    }
}
