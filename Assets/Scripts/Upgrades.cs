using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] public float upCoinsPerClick;
    [SerializeField] public float upCoinsPerSeconds;
    [SerializeField] public TextMeshProUGUI upgradeCoinsText;
    [SerializeField] public float upgradeCost;
    [SerializeField] public int upgradeNumber;

    public void UpdateUI()
    {
        upgradeCoinsText.text = $"{upgradeCost}";
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("upgradeCost" + upgradeNumber, upgradeCost);
    }
}
