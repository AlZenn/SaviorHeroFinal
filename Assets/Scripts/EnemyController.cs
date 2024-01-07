using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    public Transform target;

    public float damage;

    public float hitWaitTime = 1f;
    private float hitCounter;

    public float health = 5f;

    public float knockBackTime = .5f;
    private float knockBackCounter;

    public int expToGive = 1;

    public int coinValue = 1;
    public float coinDropRate = .5f;

    // Start is called before the first frame update
    void Start()
    {
        FindNearestTarget();
    }

    // Update is called once per frame
    void Update()
    {
        FindNearestTarget();
        if (PlayerController.instance.gameObject.activeSelf == true)
        {
            if (knockBackCounter > 0)
            {
                knockBackCounter -= Time.deltaTime;

                if (moveSpeed > 0)
                {
                    moveSpeed = -moveSpeed * 2f;
                }

                if (knockBackCounter <= 0)
                {
                    moveSpeed = Mathf.Abs(moveSpeed * .5f);
                }
            }

            theRB.velocity = (target.position - transform.position).normalized * moveSpeed;

            if (hitCounter > 0f)
            {
                hitCounter -= Time.deltaTime;
            }
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealthController.instance.TakeDamage(damage);

            hitCounter = hitWaitTime;
        }
        if (collision.gameObject.tag == "Kingdom" && hitCounter <= 0f)
        {
            KingdomHealthController.instance.TakeDamage(damage);

            hitCounter = hitWaitTime;
        }
        if (collision.gameObject.tag == "Bina" && hitCounter <= 0f)
        {
            BinaHealthController.instance.TakeDamage(damage);

            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            Destroy(gameObject);

            ExperienceLevelController.instance.SpawnExp(transform.position, expToGive);

            if (Random.value <= coinDropRate)
            {
                CoinController.instance.DropCoin(transform.position, coinValue);
            }

            SFXManager.instance.PlaySFXPitched(0);
        }
        else
        {
            SFXManager.instance.PlaySFXPitched(1);
        }

        DamageNumberController.instance.SpawnDamage(damageToTake, transform.position);

        FindNearestTarget();
    }

    public void TakeDamage(float damageToTake, bool shouldKnockback)
    {
        TakeDamage(damageToTake);

        if (shouldKnockback == true)
        {
            knockBackCounter = knockBackTime;
        }
    }

    private void FindNearestTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] kingdoms = GameObject.FindGameObjectsWithTag("Kingdom");
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Bina");

        GameObject nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = player;
            }
        }

        foreach (GameObject kingdom in kingdoms)
        {
            float distance = Vector2.Distance(transform.position, kingdom.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = kingdom;
            }
        }

        foreach (GameObject building in buildings)
        {
            float distance = Vector2.Distance(transform.position, building.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = building;
            }
        }

        if (nearestTarget != null)
        {
            target = nearestTarget.transform;
        }
    }

}
