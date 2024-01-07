using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject bulletPrefab;
    public float detectionRange = 5f;
    public float bulletSpawnInterval = 3f; // Bullet'lar�n olu�ma aral���

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        // E�er d��manlar� tespit etmek istiyorsan�z, d��manlar� i�eren bir tag kullanabilirsiniz.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(firingPoint.position, enemy.transform.position);

            // E�er d��man firing point'e yak�nsa
            if (distanceToEnemy < detectionRange)
            {
                // Zamanlay�c�y� kullanarak Bullet Prefab'lar�n� olu�tur
                timeSinceLastSpawn += Time.deltaTime;

                if (timeSinceLastSpawn >= bulletSpawnInterval)
                {
                    ShootBullet();
                    timeSinceLastSpawn = 0f; // Zamanlay�c�y� s�f�rla
                }
            }
        }
    }

    void ShootBullet()
    {
        // Bullet Prefab'�n� �o�altmak i�in Instantiate kullan�l�r.
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);

        // Olu�turulan Bullet Prefab'�n� Tower'�n alt objesi yapmak i�in
        bullet.transform.parent = transform;
    }
}
