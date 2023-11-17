using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using goods;
public class GameManager : MonoBehaviour
{
    
    // 싱글톤 패턴 인스턴스 변수
    private static GameManager _instance;

    // 외부 접근 가능 속성
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                
                _instance = FindObjectOfType<GameManager>();
                if(_instance == null)
                {
                    Debug.LogError("not found in the Scene");
                }
            }
            return _instance;
        }
    }


    [SerializeField]private int gold;
    [SerializeField]private int wood;
    [SerializeField]private int stone;

    
    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    public int Wood
    {
        get { return wood; }
        set { wood = value; }
    }

    public int Stone
    {
        get { return stone; }
        set { stone = value; }
    }

    // 자원에 대한 상승량 관리
    public int goldIncrease {get; private set;}
    public int woodIncrease {get; private set;}
    public int stoneIncrease {get; private set;}
    void Start()
    {
        
        goldIncrease = 3;  
        woodIncrease = 3;  
        stoneIncrease = 3; 

        // UpdateResourceUI();
        StartCoroutine(ProductionResource());
    }

    IEnumerator ProductionResource()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            InCreaseResources(goldIncrease, woodIncrease, stoneIncrease);
            
        }
    }
    // 자원 증가
    public void InCreaseResources(int goldAmount, int woodAmount, int stoneAmount)
    {
        gold += goldAmount;
        wood += woodAmount;
        stone += stoneAmount;
       // Debug.Log($"Increased resources: Gold={gold}, Wood={wood}, Stone={stone}");
        // goldIncrease = goldAmount;
        // woodIncrease = woodAmount;
        // stoneIncrease = stoneAmount;
        
        UpdateResourceUI();
    }
    // UI Text 업데이트
    [SerializeField] private Text goldText;
    [SerializeField] private Text woodText;
    [SerializeField] private Text stoneText;
    void UpdateResourceUI()
    {
        if(goldText != null)
        {
            goldText.text = "Gold: " + Gold.ToString();
        }

        if(woodText != null)
        {
            woodText.text = "Wood: " + Wood.ToString();
        }

        if(stoneText != null)
        {
            stoneText.text = "Stone: " + Stone.ToString();
        }
    }
    
}
