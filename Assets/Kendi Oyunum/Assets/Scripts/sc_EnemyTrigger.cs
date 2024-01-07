using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_EnemyTrigger : MonoBehaviour
{
    public GameObject bullet; // Bullet GameObject'i
    private BoxCollider2D boxCollider2D; // Box Collider 2D

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Eðer diðer Collider'ýn tag'i enemy ise
        if (otherCollider.gameObject.tag == "Enemy")
        {
            // Bullet GameObject'i aktifleþtir
            bullet.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        // Eðer diðer Collider'ýn tag'i enemy ise
        if (otherCollider.gameObject.tag == "Enemy")
        {
            // Bullet GameObject'i pasifleþtir
            bullet.SetActive(false);
        }
    }
}