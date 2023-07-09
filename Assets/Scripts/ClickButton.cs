using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Upgrades upgrades;
    [SerializeField] private float startUpgradeCost;

    public void Start()
    {
        upgrades.upgradeCost = PlayerPrefs.GetFloat("upgradeCost" + upgrades.upgradeNumber, startUpgradeCost);
        upgrades.upgradeCoinsText.text = $"{upgrades.upgradeCost}";
    }

    public void ClickCoins ()
    {
        playerStats.AddCoins();
    }

    public void ClickUpgrade ()
    {
        if (playerStats.coins >= upgrades.upgradeCost)
        {
            playerStats.ClickUp(upgrades.upCoinsPerClick, upgrades.upgradeCost);
            upgrades.upgradeCost *= 2;
            upgrades.UpdateUI();
            upgrades.Save();
        }
         
    }

    public void GetCoinPerTimeUpgrade ()
    {
        if (playerStats.coins >= upgrades.upgradeCost)
        {
            playerStats.AfkUp(upgrades.upCoinsPerSeconds, upgrades.upgradeCost);
            upgrades.upgradeCost *= 2;
            upgrades.UpdateUI();
            upgrades.Save();
        }
        
    }


}
