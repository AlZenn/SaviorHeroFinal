using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    public GameObject TowerToSpawn;
    private List<GameObject> spawnedTowers = new List<GameObject>();
    public Transform SpawnPoint; // Transform tipinde spawn noktasý
    public float towerLifetime = 15f; // Kule ömrü (saniye)
    public int costTower = 0;
    private void Update()
    {
        // Spawn edilmiþ kulelerin ömrünü kontrol et
        for (int i = spawnedTowers.Count - 1; i >= 0; i--)
        {
            GameObject tower = spawnedTowers[i];
            towerLifetime -= Time.deltaTime;

            if (towerLifetime <= 0f)
            {
                DestroyTower(i);
            }
        }
    }
    private bool CanAffordTower()
    {
        // Check if the current coins are greater than the tower cost
        return CoinController.instance.currentCoins >= costTower;
    }


    public void spawnTower()
    {
        if (SpawnPoint != null && CanAffordTower())
        {
            GameObject newTower = Instantiate(TowerToSpawn, SpawnPoint.position, Quaternion.identity);
            spawnedTowers.Add(newTower);
            CoinController.instance.SpendCoins(costTower);
            Debug.Log("Spawnladým");
        }
    }

    private void DestroyTower(int index)
    {
        if (index >= 0 && index < spawnedTowers.Count)
        {
            GameObject tower = spawnedTowers[index];
            spawnedTowers.RemoveAt(index);
            Destroy(tower);
            towerLifetime = 15f; // Kule yok olduðunda, ömrü sýfýrla
        }
    }
}