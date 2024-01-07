using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinKrallikText : MonoBehaviour
{
    public Text krallikcoinText1;

    private void Update()
    {
        krallikcoinText1.text = CoinController.instance.currentCoins.ToString();
    }
}
