using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinaHealthController : MonoBehaviour
{
    public static BinaHealthController instance;
    public GameObject bina;

    private void Awake()
    {
        instance = this;
    }

    public float currentHealth, maxHealth;

    public Slider healthSlider;

    public GameObject destructionEffect;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100f;

        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        InvokeRepeating("DecreaseHealthOverTime", 0.25f, 0.25f);
    }
    private void DecreaseHealthOverTime()
    {
        TakeDamage(1f);
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            Destroy(bina);
            DestroyKingdom2();
            
        }

        healthSlider.value = currentHealth;
    }
    private void DestroyKingdom2()
    {
        
        gameObject.SetActive(false);

        Instantiate(destructionEffect, transform.position, transform.rotation);
        SFXManager.instance.PlaySFX(12);
    }
}
