// 생산 시설 구현 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using goods;
public class Production : MonoBehaviour
{
    public int productionRate = 1;  // 초당 자원 생산량
    public ResourceType productionResource; // 생산되는 자원 종류
    public Text productionText;
    
    private void Start()
    {
        StartCoroutine(ProductionResource());    
        
    }

    // 자원을 주기적으로 생산시켜주는 코루틴
    IEnumerator ProductionResource()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            int resourceIncrease = 0;
            switch (productionResource)
            {
                case ResourceType.Gold:
                    resourceIncrease = GameManager.instance.goldIncrease;
                    break;
                case ResourceType.Wood:
                    resourceIncrease = GameManager.instance.woodIncrease;
                    break;
                case ResourceType.Stone:
                    resourceIncrease = GameManager.instance.stoneIncrease;
                    break;

            }

            GameManager.instance.InCreaseResources(0, 0, 0);
            
            UpdateProductionText(resourceIncrease);
            
        }
    }
    void UpdateProductionText(int resourceIncrease)
    {
        if(productionText != null)
        {
            productionText.text = $"{productionResource} : {resourceIncrease}";
        }
    }

    

    
}
