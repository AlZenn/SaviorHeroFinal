using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletGenerator : MonoBehaviour
{
    public float spawntime;
    private float spawnTimer = 0;
    public GameObject potatoPrefab;

    // Update fonksiyonu, her oyun karesi güncellendiðinde çalýþýr.
    private void Update()
    {
        // spawnTimer deðiþkeni 2 saniyeyi doldurduysa, bir patato prefabý oluþturur.
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawntime)
        {
            // Oyun sahnesine bir patato prefabý ekler.
            GameObject potato = Instantiate(potatoPrefab, transform.position, transform.rotation);

            // spawnTimer deðiþkenini sýfýrlar.
            spawnTimer = 0;
            
        }
    }
}
