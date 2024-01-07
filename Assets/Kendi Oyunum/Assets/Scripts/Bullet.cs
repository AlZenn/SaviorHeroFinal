using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float detectionRadius = 10f;
    public string enemyTag = "Enemy";

    void Update()
    {
        // "Enemy" taglý objeleri kontrol et
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag(enemyTag))
            {
                // "Enemy" taglý obje bulundu, ona doðru hareket et
                MoveTowardsEnemy(enemy.transform.position);
                break; // Sadece bir düþmana doðru hareket etmek için, diðerlerini kontrol etmeyi durdur
            }
        }

    }

    void MoveTowardsEnemy(Vector2 enemyPosition)
    {
        // Düþmanýn pozisyonuna doðru hareket et
        transform.position = Vector2.MoveTowards(transform.position, enemyPosition, speed * Time.deltaTime);
    }
}