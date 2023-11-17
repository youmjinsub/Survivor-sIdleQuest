using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    // 게임 저장
    public void SaveGame()
    {
        PlayerPrefs.SetInt("Gold", GameManager.instance.Gold);
        PlayerPrefs.SetInt("Wood", GameManager.instance.Wood);
        PlayerPrefs.SetInt("Stone", GameManager.instance.Stone);
    }

    // 게임 불러오기
    public void LoadGame()
    {
        GameManager.instance.Gold = PlayerPrefs.GetInt("Gold", 0);
        GameManager.instance.Wood = PlayerPrefs.GetInt("Wood", 0);
        GameManager.instance.Stone = PlayerPrefs.GetInt("Stone", 0);
    }
}
