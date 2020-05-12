using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float MaxSpeed = 0.0f;
    [SerializeField] private float moveSpeed = 0.0f;
    [SerializeField] private float deceleration = 0.0f;

    private Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 減速
        rigid.AddForce(GetDecelerate());
    }

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="dir">移動する方向</param>
    public void Movement(Vector3 dir)
    {
        if (rigid.velocity.sqrMagnitude >= MaxSpeed * MaxSpeed) return;

        Vector3 force = dir.normalized * moveSpeed;
        rigid.AddForce(force);
    }

    /// <summary>
    /// 減速率の取得
    /// </summary>
    /// <returns>減速率</returns>
    private Vector3 GetDecelerate()
    {
        Vector3 force = rigid.velocity.normalized * moveSpeed;
        Vector3 decelerate = -force * deceleration;
        return decelerate;
    }
}
