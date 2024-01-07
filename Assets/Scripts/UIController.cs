using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    private void Awake()
    {
        instance = this;
    }

    public Slider explvlSlider;
    public TMP_Text expLvlText;

    public LevelUpSelectionButton[] levelUpButtons;

    public GameObject levelUpPanel;

    public TMP_Text coinText;
    public Text krallikcoinText;

    public PlayerStatUpgradeDisplay moveSpeedUpgradeDisplay, healthUpgradeDisplay, pickupRangeUpgradeDisplay, maxWeaponsUpgradeDisplay;

    public TMP_Text timeText;

    public GameObject levelEndScreen;
    public TMP_Text endTimeText;

    public string mainMenuName;

    public GameObject pauseScreen;
    public GameObject shopScreen;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = CoinController.instance.currentCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void UpdateExperience(int currentExp, int levelExp, int currentLvl)
    {
        explvlSlider.maxValue = levelExp;
        explvlSlider.value = currentExp;

        expLvlText.text = "Level: " + currentLvl;
    }

    public void SkipLevelUp()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpdateCoins()
    {
        coinText.text =CoinController.instance.currentCoins.ToString();
        krallikcoinText.text = CoinController.instance.currentCoins.ToString();
    }

    public void PurchaseMoveSpeed()
    {
        PlayerStatController.instance.PurchaseMoveSpeed();
        SkipLevelUp();
    }

    public void PurchaseHealth()
    {
        PlayerStatController.instance.PurchaseHealth();
        SkipLevelUp();
    }

    public void PurchasePickupRange()
    {
        PlayerStatController.instance.PurchasePickupRange();
        SkipLevelUp();
    }

    public void PurchaseMaxWeapons()
    {
        PlayerStatController.instance.PurchaseMaxWeapons();
        SkipLevelUp();
    }

    public void UpdateTimer(float time)
    {
        float minutes = Mathf.FloorToInt( time / 60f);
        float seconds = Mathf.FloorToInt( time % 60);

        timeText.text = "Time: " + minutes + ":" + seconds.ToString("00");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public GameObject krallik;
    
    public void pauseButtonCheck()
    {
        pauseScreen.SetActive(true);
        krallik.SetActive(false);
        Time.timeScale = 0f;
    }
    public void shopButtonCheck()
    {
        shopScreen.SetActive(true);
        krallik.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseUnpause()
    {
        if (pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        } else
        {
            
            pauseScreen.SetActive(false);
            if (levelUpPanel.activeSelf == false)
            {
                krallik.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }
    public void ShopUnpause()
    {
        if (shopScreen.activeSelf == false)
        {
            shopScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {

            shopScreen.SetActive(false);
            if (levelUpPanel.activeSelf == false)
            {
                krallik.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }
}
