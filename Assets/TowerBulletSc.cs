using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletSc : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed; // Bullet'ýn dönme hýzý

    void Update()
    {
        FindClosestEnemyAndMove();
    }

    void FindClosestEnemyAndMove()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // En yakýn düþmaný bul
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        // En yakýn düþman varsa, ona doðru hareket et ve dön
        if (closestEnemy != null)
        {
            Vector2 direction = closestEnemy.transform.position - transform.position;
            direction.Normalize();

            transform.up = Vector2.Lerp(transform.up, direction, rotationSpeed * Time.deltaTime);
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            // Eðer düþman yoksa sadece ileri git
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
    }

    public float bulletDamage = 10f; // Bullet hasar deðeri

    void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarpýþan obje bir düþman ise
        if (other.CompareTag("Enemy"))
        {
            // Düþmanýn "TakeDamage" fonksiyonunu çaðýr ve hasar deðerini ile
            other.GetComponent<EnemyController>().TakeDamage(bulletDamage);

            // Bullet'ý yok et, çünkü bir kere kullanýlýr.
            Destroy(gameObject);
        }
    }
}