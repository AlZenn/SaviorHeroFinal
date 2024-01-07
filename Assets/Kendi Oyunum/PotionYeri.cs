
/*public GameObject potiondest;

public void _potionCharacter()
{
    PlayerHealthController.instance.PotionCharacterHealth();
} 
public void _potionKingdom()
{
    KingdomHealthController.instance.KingdomHealthFull();
}
public void _potionDestory()
{
    potiondest.SetActive(true);
}
*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PotionYeri : MonoBehaviour
{
    public GameObject potiondest;

    public Button potionButton1;
    public Text countdownText1;
    public GameObject text1;

    public Button potionButton2;
    public Text countdownText2;
    public GameObject text2;

    public Button potionButton3;
    public Text countdownText3;
    public GameObject text3;

    private bool isCooldown1 = false;
    private bool isCooldown2 = false;
    private bool isCooldown3 = false;

    public float cooldownTime1 = 20f;
    public float cooldownTime2 = 30f;
    public float cooldownTime3 = 40f;

    private void Start()
    {
        // Baþlangýçta butonlar aktif olmalý
        potionButton1.interactable = true;
        potionButton2.interactable = true;
        potionButton3.interactable = true;

        // Baþlangýçta sayaç metinleri sýfýr olarak ayarlanmalý
        countdownText1.text = "0";
        countdownText2.text = "0";
        countdownText3.text = "0";
    }

    public void _potionCharacter1()
    {
        if (!isCooldown1)
        {
            potiondest.SetActive(true);
            StartCoroutine(PotionCooldown1());
            
        }
    }

    public void _potionCharacter2()
    {
        if (!isCooldown2)
        {
            KingdomHealthController.instance.KingdomHealthFull();
            StartCoroutine(PotionCooldown2());
            // Ýkinci butona özgü iþlem buraya eklenir
            
        }
    }

    public void _potionCharacter3()
    {
        if (!isCooldown3)
        {
            PlayerHealthController.instance.PotionCharacterHealth();
            StartCoroutine(PotionCooldown3());
            PlayerHealthController.instance.PotionCharacterHealth();
        }
    }

    private IEnumerator PotionCooldown1()
    {
        isCooldown1 = true;
        potionButton1.interactable = false;
        text1.SetActive(true);

        float currentTime = cooldownTime1;

        while (currentTime > 0f)
        {
            countdownText1.text = Mathf.Floor(currentTime).ToString();
            currentTime -= Time.deltaTime;
            yield return null;
        }

        isCooldown1 = false;
        potionButton1.interactable = true;
        text1.SetActive(false);
        countdownText1.text = "0";
    }

    private IEnumerator PotionCooldown2()
    {
        isCooldown2 = true;
        potionButton2.interactable = false;
        text2.SetActive(true);

        float currentTime = cooldownTime2;

        while (currentTime > 0f)
        {
            countdownText2.text = Mathf.Floor(currentTime).ToString();
            currentTime -= Time.deltaTime;
            yield return null;
        }

        isCooldown2 = false;
        potionButton2.interactable = true;
        text2.SetActive(false);
        countdownText2.text = "0";
    }

    private IEnumerator PotionCooldown3()
    {
        isCooldown3 = true;
        potionButton3.interactable = false;
        text3.SetActive(true);

        float currentTime = cooldownTime3;

        while (currentTime > 0f)
        {
            countdownText3.text = Mathf.Floor(currentTime).ToString();
            currentTime -= Time.deltaTime;
            yield return null;
        }

        isCooldown3 = false;
        potionButton3.interactable = true;
        text3.SetActive(false);
        countdownText3.text = "0";
    }
}
