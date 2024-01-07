using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Krallik_Ticaret : MonoBehaviour
{
    public int[] itemCosts = new int[4];
    public Text[] textCurrentLevels = new Text[4];
    public int[] currentLevels = new int[4];
    public Text krallikcoinText;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public Text CostText1;
    public Text CostText2;
    public Text CostText3;
    public Text CostText4;

    public int CostValue1;
    public int CostValue2;
    public int CostValue3;
    public int CostValue4;

    private void Start()
    {
        krallikcoinText.text = CoinController.instance.currentCoins.ToString();
    }
    private void Update()
    {
        for (int i = 0; i < currentLevels.Length; i++)
        {
            textCurrentLevels[i].text = "Current Level: " + currentLevels[i];
        }

        CostText1.text = CostValue1.ToString();
        CostText2.text = CostValue2.ToString();
        CostText3.text = CostValue3.ToString();
        CostText4.text = CostValue4.ToString();

        if (CostValue1 > 250)
        {
            button1.SetActive(false);
        }
        else if (CostValue2 > 500)
        {
            button2.SetActive(false);
        }
        else if (CostValue3 > 2500)
        {
            button3.SetActive(false);
        }
        else if (CostValue4 > 1000)
        {
            button4.SetActive(false);
        }
    }

    private bool CanAfford(int itemCost)
    {
        return CoinController.instance.currentCoins >= itemCost;
    }

    private void BuyItem(int itemIndex)
    {
        int itemCost = itemCosts[itemIndex];

        if (CanAfford(itemCost))
        {
            CoinController.instance.SpendCoins(itemCost);
            currentLevels[itemIndex]++;




            switch (itemIndex)
            {
                case 0:
                    PlayerStatController.instance.PurchaseHealth();
                    CostValue1 += 10;
                    Debug.Log("can arttý");
                    break;
                case 1:
                    PlayerStatController.instance.PurchaseMoveSpeed();
                    CostValue2 += 5;
                    Debug.Log("hýz arttý");
                    break;
                case 2:
                    PlayerStatController.instance.PurchasePickupRange();
                    CostValue3 += 50;
                    Debug.Log("range arttý");
                    break;
                case 3:
                    PlayerStatController.instance.PurchaseMaxWeapons();
                    CostValue4 += 500;
                    Debug.Log("silah arttý");
                    break;
                default:
                    break;
            }
        }
    }

    public void OnButtonClick_Item(int itemIndex)
    {
        // Butona týklandýðýnda ilgili öðenin seviyesini arttýr
        BuyItem(itemIndex);
        // Buraya eþyanýn alýndýðýna dair ek bir iþlem veya geri bildirim ekleyebilirsiniz.

        // Eklenen Purchase fonksiyonunu çaðýr

    }

    public void OnButtonClick_Item1()
    {
        OnButtonClick_Item(0);
    }

    public void OnButtonClick_Item2()
    {
        OnButtonClick_Item(1);
    }

    public void OnButtonClick_Item3()
    {
        OnButtonClick_Item(2);
    }

    public void OnButtonClick_Item4()
    {
        OnButtonClick_Item(3);
    }
}