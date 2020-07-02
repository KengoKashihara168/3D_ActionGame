using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private readonly float DefaultRotationX = -90.0f;

    [SerializeField] private GameObject[] buildings = null;

    private GameObject building;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, buildings.Length - 1);
        Vector3 pos = transform.position;
        Quaternion rot = Quaternion.identity * Quaternion.AngleAxis(DefaultRotationX, Vector3.right);
        building = GameObject.Instantiate(buildings[rand], pos,rot, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
