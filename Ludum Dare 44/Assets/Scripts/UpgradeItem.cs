using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Create new Upgrade")]
public class UpgradeItem : ScriptableObject
{
    public Sprite upgradeIcon;
    public string upgradeName;
    public string upgradeDesc;
    public int lungCost, liverCost, kidneyCost, heartCost;
}
