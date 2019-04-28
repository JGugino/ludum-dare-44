using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public GameObject upgradeItemPrefab;

    [SerializeField]
    private UpgradeItem[] possibleUpgrades;

    private List<GameObject> spawnedUpgrades;

    [SerializeField]
    private Transform upgradeParent;

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

            obj.GetComponent<UpgradeContainer>().configurePrefab(possibleUpgrades[i]);
        }
    }
}
