using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBtn : MonoBehaviour
{
    public Text buttonText; // ��ư �ؽ�Ʈ
    public int cost = 10;  // ���׷��̵� ���
    public GameManager2 gameManager;    // ���� �Ŵ��� 
    public GameObject upgradeBtn;

    void Start()
    {
        // UpgradeBtn ��ũ��Ʈ�� �ִ� GameObject�� ã�Ƽ� �Ҵ�
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
            // �÷��̾ ����� ��带 ������ ������ �ִ� ü���� ������Ŵ
            if (gameManager.gold >= cost)
            {
                gameManager.gold -= cost; // ��� �Ҹ�
                gameManager.GetGold(10);  // ��� �Ҹ� ���� ���Ƿ� 10 ������Ŵ (���ϴ� ������ ���� ����)

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
