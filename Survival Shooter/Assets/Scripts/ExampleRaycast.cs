using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleRaycast : MonoBehaviour
{
    public GameObject _object;
    public float rayLength;
    public LayerMask layerRay;

    Ray ray;//el rayo
    RaycastHit hit;
    void Start()
    {
        
    }

    void Update()
    {
        //Configuración del rayo
        ray.origin = transform.position;
        ray.direction = transform.forward;
        //

        if (Physics.Raycast(ray, out hit, rayLength, layerRay))//Lanzando el rayo
        {
            _object = hit.collider.gameObject;
            Debug.Log("Estoy chocando con algo " + hit.collider.name);
        }
        else Debug.Log("no estoy chocando con nada");

        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
    }
}
