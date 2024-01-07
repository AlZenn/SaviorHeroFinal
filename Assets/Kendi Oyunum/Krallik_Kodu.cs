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

        // Player objesi var m� ve kontrol edilecek transform'a olan mesafe 5 birimden az m�?
        if (playerObjesi != null && Vector3.Distance(kontrolEdilecekTransform.position, playerObjesi.transform.position) < kontrolMesafesi)
        {
            // E�er �artlar sa�lan�yorsa krallik_buton'u aktif yap
            krallikButon.SetActive(true);
        }
        else
        {
            // �artlar sa�lanm�yorsa krallik_buton'u deaktif yap
            krallikButon.SetActive(false);
        }
    }
}