// 업그레이드 관리
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public Upgrade[] upgrades; // 업그레이드 배열

    // 업그레이드 구매
    public void PurchaseUp(int index)
    {
        Upgrade selectedUpgrade = upgrades[index];
        if (GameManager.instance.Gold >= selectedUpgrade.cost)
        {
            GameManager.instance.Gold -= selectedUpgrade.cost;
            GameManager.instance.InCreaseResources(0, selectedUpgrade.productionInc, 0);
        }
    }
}
