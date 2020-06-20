using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Vector3 distance = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = target.position;
        cameraPos.x += distance.x;
        cameraPos.y += distance.y;
        cameraPos.z -= distance.z;
        transform.position = cameraPos;
    }
}
