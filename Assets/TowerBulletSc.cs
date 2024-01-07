using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletSc : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed; // Bullet'�n d�nme h�z�

    void Update()
    {
        FindClosestEnemyAndMove();
    }

    void FindClosestEnemyAndMove()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        // En yak�n d��man� bul
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        // En yak�n d��man varsa, ona do�ru hareket et ve d�n
        if (closestEnemy != null)
        {
            Vector2 direction = closestEnemy.transform.position - transform.position;
            direction.Normalize();

            transform.up = Vector2.Lerp(transform.up, direction, rotationSpeed * Time.deltaTime);
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }
        else
        {
            // E�er d��man yoksa sadece ileri git
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
    }

    public float bulletDamage = 10f; // Bullet hasar de�eri

    void OnTriggerEnter2D(Collider2D other)
    {
        // E�er �arp��an obje bir d��man ise
        if (other.CompareTag("Enemy"))
        {
            // D��man�n "TakeDamage" fonksiyonunu �a��r ve hasar de�erini ile
            other.GetComponent<EnemyController>().TakeDamage(bulletDamage);

            // Bullet'� yok et, ��nk� bir kere kullan�l�r.
            Destroy(gameObject);
        }
    }
}