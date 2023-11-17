using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour
{
    public Text buttonText; // 버튼 텍스트
    public int cost = 10;  // 업그레이드 비용
    public GameManager2 gameManager;    // 게임 매니저 
    public GameObject upgradeBtn;

    void Start()
    {
        // UpgradeBtn 스크립트가 있는 GameObject를 찾아서 할당
        gameManager = GetComponentInParent<GameManager2>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager2 not found!");
        }

        if (buttonText != null)
        {
            buttonText.text = "Upgrade\nCost: " + cost.ToString();
        }
    }


    public void UpgradeMaxHealth()
    {
        Debug.Log("UpgradeMaxHealth method called!");
        if (gameManager != null)
        {
            // 플레이어가 충분한 골드를 가지고 있으면 최대 체력을 증가시킴
            if (gameManager.gold >= cost)
            {
                gameManager.gold -= cost; // 골드 소모
                gameManager.GetGold(10);  // 골드 소모에 따라 임의로 10 증가시킴 (원하는 값으로 변경 가능)

                Debug.Log("Upgrade successful!");
            }
            else
            {
                Debug.Log("Not enough gold!");
            }
        }
        else
        {
            Debug.LogError("GameManager is null!");
        }
    }
}
