using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletGenerator : MonoBehaviour
{
    public float spawntime;
    private float spawnTimer = 0;
    public GameObject potatoPrefab;

    // Update fonksiyonu, her oyun karesi g�ncellendi�inde �al���r.
    private void Update()
    {
        // spawnTimer de�i�keni 2 saniyeyi doldurduysa, bir patato prefab� olu�turur.
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawntime)
        {
            // Oyun sahnesine bir patato prefab� ekler.
            GameObject potato = Instantiate(potatoPrefab, transform.position, transform.rotation);

            // spawnTimer de�i�kenini s�f�rlar.
            spawnTimer = 0;
            
        }
    }
}
