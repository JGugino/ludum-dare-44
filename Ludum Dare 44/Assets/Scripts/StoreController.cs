using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public GameObject upgradeItemPrefab;

    [SerializeField]
    private UpgradeItem[] possibleUpgrades = null;

    private List<GameObject> spawnedUpgrades;

    [SerializeField]
    private Transform upgradeParent = null;

    private void Start()
    {
        spawnedUpgrades = new List<GameObject>();

        populateStore();
    }

    public void populateStore()
    {
        for (int i = 0; i < possibleUpgrades.Length; i++)
        {
            GameObject obj = Instantiate(upgradeItemPrefab, upgradeParent);

            obj.name = possibleUpgrades[i].upgradeName;

            UpgradeContainer uc = obj.GetComponent<UpgradeContainer>();

            uc.configurePrefab(possibleUpgrades[i]);

            uc.getBuyButton().onClick.AddListener(delegate { buyUpgrade(uc.currentUpgrade, uc); });
        }
    }

    public void buyUpgrade(UpgradeItem _itemToPurchase, UpgradeContainer _uc)
    {
        int lungCost = _itemToPurchase.lungCost, liverCost = _itemToPurchase.liverCost, 
            kidneyCost = _itemToPurchase.kidneyCost, heartCost = _itemToPurchase.heartCost;

        GameController gc = GameController.instance;

        if (((gc.getLungAmount() > 0) && (gc.getLungAmount() - lungCost >= 0)) && ((gc.getLiverAmount() > 0) && (gc.getLiverAmount() - liverCost >= 0))
            && ((gc.getKidneyAmount() > 0) && (gc.getKidneyAmount() - kidneyCost >= 0)) && ((gc.getHeartAmount() > 0) && (gc.getHeartAmount() - heartCost >= 0)))
        {
            PlayerController pc = GameController.instance.currentPlayer.GetComponent<PlayerController>();

            switch (_itemToPurchase.upgradeName)
            {
                case "Extra Life":
                    pc.upgradePlayer(_itemToPurchase.upgradeName);
                    break;

                case "Double Shot":
                    pc.upgradePlayer(_itemToPurchase.upgradeName);
                    _uc.getBuyButton().onClick.RemoveAllListeners();
                    _uc.getBuyButton().interactable = false;

                    GameController.instance.createUpgradeIcon(_itemToPurchase.upgradeIcon);
                    break;

                case "Speed Boost":
                    pc.upgradePlayer(_itemToPurchase.upgradeName);
                    _uc.getBuyButton().onClick.RemoveAllListeners();
                    _uc.getBuyButton().interactable = false;

                    GameController.instance.createUpgradeIcon(_itemToPurchase.upgradeIcon);
                    break;

                case "Steel Heart":

                    break;
            }

            subtractAmounts(lungCost, liverCost, kidneyCost, heartCost);
        }
        else
        {
            //Debug.Log("Not enough organs! Lungs: " + gc.getLungAmount() + ", Liver: " + gc.getLiverAmount() + ", Kidney: " + gc.getKidneyAmount() + ", Heart: " + gc.getHeartAmount());
        }
    }

    public void subtractAmounts(int lungCost, int liverCost, int kidneyCost, int heartCost)
    {
        GameController.instance.removeOrgans("lung", lungCost);
        GameController.instance.removeOrgans("liver", liverCost);
        GameController.instance.removeOrgans("kidney", kidneyCost);
        GameController.instance.removeOrgans("heart", heartCost);
    }
}
