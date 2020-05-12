using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TurnModel();
        }
    }

    private void TurnModel()
    {
        transform.rotation = Quaternion.AngleAxis(90.0f, Vector3.up);
    }
}
