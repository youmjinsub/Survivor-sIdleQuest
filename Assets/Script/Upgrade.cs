// 업그레이드 정보 구현

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Upgrade
{
    public string upgradeName;  // 업그레이드 이름
    public int cost;    // 업그레이드 비용
    public int productionInc;    // 자원 생산 증가량
}
