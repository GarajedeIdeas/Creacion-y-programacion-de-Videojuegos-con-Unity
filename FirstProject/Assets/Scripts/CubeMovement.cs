using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public int speed;
    public int turnSpeed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //speed = 5;
        Debug.Log("Speed: " + speed);
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");//AD
        float vertical = Input.GetAxis("Vertical");//WS
        //Vector3.forward = (0,0,1)
        //Vector3.up, Vector3.right
        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);

        if(Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up * 300);
        }
    }
}
