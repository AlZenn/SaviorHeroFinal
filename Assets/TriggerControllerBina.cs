using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControllerBina : MonoBehaviour
{
    // Bu fonksiyon, bir ba�ka Collider2D objesi bu Collider2D'ye temas etti�inde �a�r�l�r.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // E�er �arp��an objenin etiketi "Player" ise
        if (collision.gameObject.CompareTag("Player"))
        {
            // Collider'�n isTrigger �zelli�ini true yap
            GetComponent<BoxCollider2D>().isTrigger = true;

            // �sterseniz a�a��daki gibi bir debug mesaj� yazabilirsiniz
            Debug.Log("Player ile etkile�im ba�lad�!");
        }
    }

    // Bu fonksiyon, bir ba�ka Collider2D objesi bu Collider2D'den ayr�ld���nda �a�r�l�r.
    private void OnTriggerExit2D(Collider2D other)
    {
        // E�er ��kan objenin etiketi "Player" ise
        if (other.CompareTag("Player"))
        {
            // Collider'�n isTrigger �zelli�ini false yap
            GetComponent<BoxCollider2D>().isTrigger = false;

            // �sterseniz a�a��daki gibi bir debug mesaj� yazabilirsiniz
            Debug.Log("Player ile etkile�im bitti!");
        }
    }
}