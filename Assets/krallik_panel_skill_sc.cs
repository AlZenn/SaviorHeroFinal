using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class krallik_panel_skill_sc : MonoBehaviour
{
    public GameObject button1;public GameObject button2;public GameObject button3; public GameObject button4;
    public GameObject yokolbuton1;public GameObject yokolbuton2;public GameObject yokolbuton3;
    public GameObject skill1; public GameObject skill2; public GameObject skill3; 
    public Text cost1;public Text cost2;public Text cost3;public Text cost4;
    public int costvalue1; public int costvalue2; public int costvalue3; public int costvalue4;

    public void Start()
    {
        cost1.text = costvalue1.ToString();cost2.text = costvalue2.ToString();cost3.text = costvalue3.ToString();cost4.text = costvalue4.ToString();
    }

    private void Update()
    {
        cost1.text = costvalue1.ToString(); cost2.text = costvalue2.ToString(); cost3.text = costvalue3.ToString(); cost4.text = costvalue4.ToString();
    }

    public void _buyitem1()
    {
        if (CoinController.instance.currentCoins >= costvalue1)
        {
            CoinController.instance.SpendCoins(costvalue1);
            button1.SetActive(false);
            
        }
    }
    public void _buyitem2()
    {
        if (CoinController.instance.currentCoins >= costvalue2)
        {
            CoinController.instance.SpendCoins(costvalue2);
            button2.SetActive(false);
            skill1.SetActive(true);
            yokolbuton1.SetActive(false);
        }
    }
    public void _buyitem3()
    {
        if (CoinController.instance.currentCoins >= costvalue3)
        {
            CoinController.instance.SpendCoins(costvalue3);
            button3.SetActive(false);
            skill2.SetActive(true);
            yokolbuton2.SetActive(false);
        }
    }
    public void _buyitem4()
    {
        if (CoinController.instance.currentCoins >= costvalue4)
        {
            CoinController.instance.SpendCoins(costvalue4);
            button4.SetActive(false);
            skill3.SetActive(true);
            yokolbuton3.SetActive(false);
        }
    }



}
