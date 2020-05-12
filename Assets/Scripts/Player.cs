using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMove move;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
