using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothing;//velocidad de seguimiento de la cámara al player

    Vector3 offset;//distancia inicial entre cámara y player

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        //calculo la posición a la que quiero mover la cámara
        Vector3 targetCamPos = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
