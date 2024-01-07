using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krallik_Kodu : MonoBehaviour
{

    public Transform kontrolEdilecekTransform; // Kontrol edilecek objenin transformu
    public string playerTag = "Player"; // Player objesinin tag'i
    public GameObject krallikButon; // krallik_buton GameObject'i


    public float kontrolMesafesi = 5f; // Player objesinin kontrol edilecek transform'a olan maksimum mesafesi

    void Update()
    {
        // Player objesini kontrol et
        KontrolEt();
    }

    void KontrolEt()
    {
        // Player objesini bul
        GameObject playerObjesi = GameObject.FindGameObjectWithTag(playerTag);

        // Player objesi var mý ve kontrol edilecek transform'a olan mesafe 5 birimden az mý?
        if (playerObjesi != null && Vector3.Distance(kontrolEdilecekTransform.position, playerObjesi.transform.position) < kontrolMesafesi)
        {
            // Eðer þartlar saðlanýyorsa krallik_buton'u aktif yap
            krallikButon.SetActive(true);
        }
        else
        {
            // Þartlar saðlanmýyorsa krallik_buton'u deaktif yap
            krallikButon.SetActive(false);
        }
    }
}