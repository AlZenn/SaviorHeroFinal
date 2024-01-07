using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class KrallikIzleme : MonoBehaviour
{
    public Transform hedefNesne;
    public float hiz = 5f;
    public float uzaklikLimiti = 10f;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }
    void Update()
    {
        if (hedefNesne != null)
        {
            // Hedefe olan uzakl��� �l�
            float uzaklik = Vector3.Distance(transform.position, hedefNesne.position);

            // Okun rotasyonunu g�ncelle
            Vector3 yon = hedefNesne.position - transform.position;
            float aci = Mathf.Atan2(yon.y, yon.x) * Mathf.Rad2Deg;
            Quaternion rotasyon = Quaternion.AngleAxis(aci, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotasyon, hiz * Time.deltaTime);

            // Uzakl�k kontrol�
            if (uzaklik > uzaklikLimiti)
            {

                // Uzakl�k 10 birimden b�y�kse opakl��� 100 yap
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {

                // Uzakl�k 10 birimden k���kse opakl��� 0 yap veya setActive false yap
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                // veya gameObject.SetActive(false);
            }
        }
    }
}
