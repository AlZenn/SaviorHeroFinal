using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDestory : MonoBehaviour
{
    public GameObject myself;
    public GameObject text;
    public float damage = 1000f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(damage, false);
        }
    }

    void DeactivatePotion()
    {
            myself.SetActive(false);
        text.SetActive(true);
    }
    private void Update()
    {
        Invoke("DeactivatePotion", 0.10f);
    }

}
