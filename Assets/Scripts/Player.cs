using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMove move;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        Vector3 dir = Vector3.zero;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            dir += Vector3.forward;
        }
        if(Input.GetKey(KeyCode.DownArrow))
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
}
