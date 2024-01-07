using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class krallik_panel_heal_sc : MonoBehaviour
{
    public int cost1; public int cost2;

    public Text costvalue1; public Text costvalue2;

    public Text healthValueplayer;
    public Text healthValuekingdom;


    public void Start()
    {
        costvalue1.text = cost1.ToString(); costvalue2.text = cost2.ToString();

    }

    void Update()
    {
        costvalue1.text = cost1.ToString(); costvalue2.text = cost2.ToString();

        sliderupdate();
    }

    void sliderupdate()
    {

        healthValueplayer.text = "Player " + PlayerHealthController.instance.maxHealth +"/"+ PlayerHealthController.instance.currentHealth;
        healthValuekingdom.text = "Kingdom "+KingdomHealthController.instance.maxHealth + "/" + KingdomHealthController.instance.currentHealth;
    }

    public void _buyitem33()
    {
        if (CoinController.instance.currentCoins >= cost1)
        {
            PlayerHealthController.instance.PotionCharacterHealth();
            sliderupdate();
            cost2 += 50;
        }
    }
    public void _buyitem44()
    {
        if (CoinController.instance.currentCoins >= cost2)
        {
            KingdomHealthController.instance.KingdomHealthFull();
            sliderupdate();
            cost1 += 50;
        }
    }

}