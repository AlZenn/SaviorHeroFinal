using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Oyuncu karakterin Transform'u

    public float smoothSpeed = 0.125f; // Kamera takip hýzý
    public float cameraSize = 5.0f; // Kameranýn boyutu
    public Vector3 offset; // Kamera ve karakter arasýndaki mesafe

    void LateUpdate()
    {
        // Kamera boyutunu ayarla
        Camera.main.orthographicSize = cameraSize;

        // Kamera pozisyonunu güncelle, sadece "position.z" deðerini -10 yaparak
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = -10; // Kamera "z" pozisyonunu -10 olarak ayarla
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
