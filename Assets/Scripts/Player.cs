using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMove move;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        move.Movement(dir);

        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            time = Time.time;
        }

        if(GetComponent<Rigidbody>().velocity.z <= 0.0f && time > 0.0f)
        {
            Debug.Log(Time.time - time);
            time = 0.0f;
        }
    }
}
