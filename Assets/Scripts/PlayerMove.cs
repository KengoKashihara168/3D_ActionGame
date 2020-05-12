using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float MaxSpeed = 0.0f;
    [SerializeField] private float moveSpeed = 0.0f;

    private Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="dir">移動する方向</param>
    public void Movement(Vector3 dir)
    {
        if (rigid.velocity.sqrMagnitude >= MaxSpeed * MaxSpeed) return;
        rigid.AddForce(dir.normalized * moveSpeed);
    }
}
