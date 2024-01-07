using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject bulletPrefab;
    public float detectionRange = 5f;
    public float bulletSpawnInterval = 3f; // Bullet'larýn oluþma aralýðý

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        // Eðer düþmanlarý tespit etmek istiyorsanýz, düþmanlarý içeren bir tag kullanabilirsiniz.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(firingPoint.position, enemy.transform.position);

            // Eðer düþman firing point'e yakýnsa
            if (distanceToEnemy < detectionRange)
            {
                // Zamanlayýcýyý kullanarak Bullet Prefab'larýný oluþtur
                timeSinceLastSpawn += Time.deltaTime;

                if (timeSinceLastSpawn >= bulletSpawnInterval)
                {
                    ShootBullet();
                    timeSinceLastSpawn = 0f; // Zamanlayýcýyý sýfýrla
                }
            }
        }
    }

    void ShootBullet()
    {
        // Bullet Prefab'ýný çoðaltmak için Instantiate kullanýlýr.
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);

        // Oluþturulan Bullet Prefab'ýný Tower'ýn alt objesi yapmak için
        bullet.transform.parent = transform;
    }
}
