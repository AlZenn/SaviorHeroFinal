using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingdomHealthController : MonoBehaviour
{
    public static KingdomHealthController instance;

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
    }

    public void KingdomHealthFull()
    {
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
    }
        

    // Update is called once per frame
    void Update()
    {
        /* 
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10f);
        }
        */
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            DestroyKingdom();
            LevelManager.instance.EndLevel();
        }

        healthSlider.value = currentHealth;
    }
    private void DestroyKingdom()
    {
        gameObject.SetActive(false);

        // Add your logic here for the end of the game or any other actions when the kingdom is destroyed.

        Instantiate(destructionEffect, transform.position, transform.rotation);

        SFXManager.instance.PlaySFX(3);
    }
}
