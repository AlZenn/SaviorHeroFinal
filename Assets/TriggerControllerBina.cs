using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControllerBina : MonoBehaviour
{
    // Bu fonksiyon, bir baþka Collider2D objesi bu Collider2D'ye temas ettiðinde çaðrýlýr.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eðer çarpýþan objenin etiketi "Player" ise
        if (collision.gameObject.CompareTag("Player"))
        {
            // Collider'ýn isTrigger özelliðini true yap
            GetComponent<BoxCollider2D>().isTrigger = true;

            // Ýsterseniz aþaðýdaki gibi bir debug mesajý yazabilirsiniz
            Debug.Log("Player ile etkileþim baþladý!");
        }
    }

    // Bu fonksiyon, bir baþka Collider2D objesi bu Collider2D'den ayrýldýðýnda çaðrýlýr.
    private void OnTriggerExit2D(Collider2D other)
    {
        // Eðer çýkan objenin etiketi "Player" ise
        if (other.CompareTag("Player"))
        {
            // Collider'ýn isTrigger özelliðini false yap
            GetComponent<BoxCollider2D>().isTrigger = false;

            // Ýsterseniz aþaðýdaki gibi bir debug mesajý yazabilirsiniz
            Debug.Log("Player ile etkileþim bitti!");
        }
    }
}