using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public GameObject cube;
    void Update()
    {
        transform.LookAt(cube.transform.position);
    }
}
