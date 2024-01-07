using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textCooldown : MonoBehaviour
{
    public Text countdownText;
    public float countdownDuration = 5f; // Saniye cinsinden geri sayým süresi
    private float currentTime;
    private bool isCounting = false;

    void Start()
    {
        // Baþlangýçta metni devre dýþý býrak
        DeactivateText();
    }

    void Update()
    {
        // Geri sayým yapýlýyor mu kontrol et
        if (isCounting)
        {
            // Zamaný güncelle
            currentTime -= Time.deltaTime;

            // Geri sayým süresini güncelle
            UpdateCountdownText();

            // Zaman bitti mi kontrol et
            if (currentTime <= 0f)
            {
                // Geri sayým bitti, metni devre dýþý býrak
                DeactivateText();
            }
        }
    }

    // Metni etkinleþtir ve geri sayým baþlat
    public void ActivateText()
    {
        isCounting = true;
        currentTime = countdownDuration;
        countdownText.gameObject.SetActive(true);
        UpdateCountdownText();
    }

    // Metni devre dýþý býrak
    public void DeactivateText()
    {
        isCounting = false;
        countdownText.gameObject.SetActive(false);
    }

    // Geri sayým metnini güncelle
    private void UpdateCountdownText()
    {
        // Zamaný bir tamsayýya dönüþtür ve metni güncelle
        int displayTime = Mathf.CeilToInt(currentTime);
        countdownText.text = displayTime.ToString();
    }
}
