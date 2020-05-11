using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private float MaxSpeed = 0.0f;
    [SerializeField] private float turnSpeed = 0.0f;

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
    /// 回転
    /// </summary>
    /// <param name="speed">回転速度</param>
    private void TurnAround(float speed)
    {
        float y = transform.eulerAngles.y + speed * Time.deltaTime;
        Quaternion rot = Quaternion.Euler(0.0f, y, 0.0f);
        rigid.rotation = rot;
    }

    /// <summary>
    /// Z方向へ移動
    /// </summary>
    public void MoveForward()
    {
        if (rigid.velocity.z >= MaxSpeed) return;
        float angle = transform.eulerAngles.y;
        Debug.Log("右へ移動");
        // -Y方向へ回転
        if (angle > 1.0f && angle < 180.0f)
        {
            TurnAround(-turnSpeed);
        }
        // Y方向へ回転
        if(angle >= 180.0f && angle < 359.0f)
        {
            TurnAround(turnSpeed);
        }
        // 前進
        if(angle >= 359.0f || angle <= 1.0f)
        {
            rigid.rotation = Quaternion.AngleAxis(0.0f, Vector3.up);
            rigid.AddForce(Vector3.forward * speed);
        }
        // 角度がマイナスになった場合の対処
        MinusAngleSolution(angle);
    }

    /// <summary>
    /// X方向へ移動
    /// </summary>
    public void MoveRight()
    {
        if (rigid.velocity.x >= MaxSpeed) return;
        float angle = transform.eulerAngles.y;

        // -Y方向へ回転
        if (angle > 91.0f && angle <= 270.0f)
        {
            TurnAround(-turnSpeed);
        }
        // Y方向へ回転
        if (angle >= 0.0f && angle < 89.0f || angle > 270.0f && angle <= 360.0f)
        {
            TurnAround(turnSpeed);
        }
        // 前進
        if (angle >= 89.0f && angle <= 91.0f)
        {
            rigid.AddForce(Vector3.right * speed);
        }
        // 角度がマイナスになった場合の対処
        MinusAngleSolution(angle);
    }

    /// <summary>
    /// -Z方向へ移動
    /// </summary>
    public void MoveBack()
    {
        if (rigid.velocity.z <= -MaxSpeed) return;
        float angle = transform.eulerAngles.y;
        // -Y方向へ回転
        if (angle >= 181.0f && angle <= 360.0f)
        {
            TurnAround(-turnSpeed);
        }
        // Y方向へ回転
        if (angle >= 0.0f && angle <= 179.0f)
        {
            TurnAround(turnSpeed);
        }
        // 前進
        if (angle > 179.0f && angle < 181.0f)
        {
            rigid.AddForce(Vector3.back * speed);
        }
        // 角度がマイナスになった場合の対処
        MinusAngleSolution(angle);
    }

    /// <summary>
    /// -X方向へ移動
    /// </summary>
    public void MoveLeft()
    {
        if (rigid.velocity.x <= -MaxSpeed) return;
        float angle = transform.eulerAngles.y;
        if (angle >= 0.0f && angle < 90.0f || angle >= 271.0f && angle <= 360.0f)
        {
            // -Y方向へ回転
            TurnAround(-turnSpeed);
        }
        if (angle >= 90.0f && angle <= 269.0f)
        {
            // Y方向へ回転
            TurnAround(turnSpeed);
        }
        if (angle > 269.0f && angle < 271.0f)
        {
            // 前進
            rigid.AddForce(Vector3.left * speed);
        }
        // 角度がマイナスになった場合の対処
        MinusAngleSolution(angle);
    }

    /// <summary>
    /// 向きがマイナスになった場合の対処
    /// </summary>
    /// <param name="angle">向き</param>
    private void MinusAngleSolution(float angle)
    {
        // 角度がマイナスになった場合の対処
        if (angle < 0)
        {
            rigid.rotation = Quaternion.AngleAxis(0.0f, Vector3.up);
        }
    }
}
