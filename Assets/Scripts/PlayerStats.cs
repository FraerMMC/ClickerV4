using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] public float coins;
    [SerializeField] private float coinsPerClick;
    [SerializeField] private float timeAddCoins;
    [SerializeField] private float coinsPerSecond;

    private void Start()
    {
        StartCoroutine(AddResource(timeAddCoins));
        coins = PlayerPrefs.GetFloat("coins");
        coinsPerClick = PlayerPrefs.GetFloat("coinsPerClick", 1);
        coinsPerSecond = PlayerPrefs.GetFloat("coinsPerSecond");
        UpdateUI();
    }

    public void AddCoins ()
    {
        coins += coinsPerClick;
        UpdateUI();
    }

    public void ClickUp (float coinsPerClickValue, float subtractionCoins) 
    {
        coinsPerClick += coinsPerClickValue;
        coins -= subtractionCoins;
        UpdateUI();
    }

    public void AfkUp(float coinsPerSecondValue, float subtractionCoins)
    {
        coinsPerSecond += coinsPerSecondValue;
        coins -= subtractionCoins;
        UpdateUI();
    }

    private IEnumerator AddResource(float rate)
    {
        while (true)
        {
            yield return new WaitForSeconds(rate);
            coins+= coinsPerSecond;
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        coinsText.text = $"{coins}";
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("coins", coins);
        PlayerPrefs.SetFloat("coinsPerClick", coinsPerClick);
        PlayerPrefs.SetFloat("coinsPerSecond", coinsPerSecond);
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
