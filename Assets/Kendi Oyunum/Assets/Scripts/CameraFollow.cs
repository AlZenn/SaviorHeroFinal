using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Oyuncu karakterin Transform'u

    public float smoothSpeed = 0.125f; // Kamera takip h�z�
    public float cameraSize = 5.0f; // Kameran�n boyutu
    public Vector3 offset; // Kamera ve karakter aras�ndaki mesafe

    void LateUpdate()
    {
        // Kamera boyutunu ayarla
        Camera.main.orthographicSize = cameraSize;

        // Kamera pozisyonunu g�ncelle, sadece "position.z" de�erini -10 yaparak
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = -10; // Kamera "z" pozisyonunu -10 olarak ayarla
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
