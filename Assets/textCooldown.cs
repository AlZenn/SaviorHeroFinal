using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textCooldown : MonoBehaviour
{
    public Text countdownText;
    public float countdownDuration = 5f; // Saniye cinsinden geri say�m s�resi
    private float currentTime;
    private bool isCounting = false;

    void Start()
    {
        // Ba�lang��ta metni devre d��� b�rak
        DeactivateText();
    }

    void Update()
    {
        // Geri say�m yap�l�yor mu kontrol et
        if (isCounting)
        {
            // Zaman� g�ncelle
            currentTime -= Time.deltaTime;

            // Geri say�m s�resini g�ncelle
            UpdateCountdownText();

            // Zaman bitti mi kontrol et
            if (currentTime <= 0f)
            {
                // Geri say�m bitti, metni devre d��� b�rak
                DeactivateText();
            }
        }
    }

    // Metni etkinle�tir ve geri say�m ba�lat
    public void ActivateText()
    {
        isCounting = true;
        currentTime = countdownDuration;
        countdownText.gameObject.SetActive(true);
        UpdateCountdownText();
    }

    // Metni devre d��� b�rak
    public void DeactivateText()
    {
        isCounting = false;
        countdownText.gameObject.SetActive(false);
    }

    // Geri say�m metnini g�ncelle
    private void UpdateCountdownText()
    {
        // Zaman� bir tamsay�ya d�n��t�r ve metni g�ncelle
        int displayTime = Mathf.CeilToInt(currentTime);
        countdownText.text = displayTime.ToString();
    }
}
