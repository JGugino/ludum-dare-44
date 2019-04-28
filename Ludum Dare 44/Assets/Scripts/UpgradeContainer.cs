using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeContainer : MonoBehaviour
{
    public UpgradeItem currentUpgrade;

    [SerializeField]
    private Image upgradeIcon;

    [SerializeField]
    private TextMeshProUGUI upgradeName, upgradeDesc, lungCost, liverCost, kidneyCost, heartCost;

    public void configurePrefab(UpgradeItem _upgrade)
    {
        currentUpgrade = _upgrade;

        if (currentUpgrade != null)
        {
            upgradeIcon.sprite = currentUpgrade.upgradeIcon;

            upgradeName.text = currentUpgrade.upgradeName;
            upgradeDesc.text = currentUpgrade.upgradeDesc;

            lungCost.text = currentUpgrade.lungCost.ToString();
            liverCost.text = currentUpgrade.liverCost.ToString();
            kidneyCost.text = currentUpgrade.kidneyCost.ToString();
            heartCost.text = currentUpgrade.heartCost.ToString();
        }
    }
}
