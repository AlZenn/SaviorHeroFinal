using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrallikCanvas : MonoBehaviour
{
    public GameObject _krallikButton;
    public GameObject _krallikPanel;

    // bu scripti krallýga giriþte kapat, krallýktan çýkarken aç (gerek olursa)
    //public GameObject _krallikKontrolScript;

    public void _KrallikGiris()
    {
        _krallikButton.SetActive(false);
        _krallikPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void _KrallikCikis()
    {
        _krallikPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
