using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buttonCooldown : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    public Text text1;
    public Text text2;
    public Text text3;

    void Start()
    {
        // Her butonun t�klama olay�na abone oluyoruz
        button1.onClick.AddListener(() => StartCoroutine(DisableButton(button1, text1)));
        button2.onClick.AddListener(() => StartCoroutine(DisableButton(button2, text2)));
        button3.onClick.AddListener(() => StartCoroutine(DisableButton(button3, text3)));
    }

    IEnumerator DisableButton(Button button, Text text)
    {
        // Butonun etkile�imini devre d��� b�rak
        button.interactable = false;

        // Text'i aktifle�tir
        text.gameObject.SetActive(true);

        // 10 saniye geri say�m
        for (int i = 3; i > 0; i--)
        {
            text.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        // Butonun etkile�imini tekrar etkinle�tir
        button.interactable = true;

        // Text'i devre d��� b�rak
        text.gameObject.SetActive(false);
    }
}
