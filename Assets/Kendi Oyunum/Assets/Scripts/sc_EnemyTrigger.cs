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
        // E�er di�er Collider'�n tag'i enemy ise
        if (otherCollider.gameObject.tag == "Enemy")
        {
            // Bullet GameObject'i aktifle�tir
            bullet.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        // E�er di�er Collider'�n tag'i enemy ise
        if (otherCollider.gameObject.tag == "Enemy")
        {
            // Bullet GameObject'i pasifle�tir
            bullet.SetActive(false);
        }
    }
}