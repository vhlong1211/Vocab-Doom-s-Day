using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UpgradeConfig", menuName = "UpgradeCongfig", order = 1)]
public class UpgradeScriptable : ScriptableObject
{
    public List<int> upgradeCost;

}
