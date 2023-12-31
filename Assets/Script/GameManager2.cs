using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;

    [Header("# Game Control")]
    public bool isLive;
    public float gameTime;
    public float MaxGameTime = 2 * 10f;
    [Header("# Player Info")]
    public float health;
    public int maxHealth = 100;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600};
    public int level;
    public int kill;
    public int exp;
    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;
    public LevelUp uiLevelUp;
    public Result uiResult;
    public GameObject enemyCleaner;
    public int gold;
    public int goldToHealthRatio = 100;
    public void GetGold(int amount)
    {
        // 골드를 얻을 때마다 최대 체력을 일정 비율로 증가시킴
        gold += amount;
        maxHealth += Mathf.FloorToInt(amount / (float) goldToHealthRatio);
    }
    private void Awake()
    {
        //instance = this;
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameStart()
    {
        health = maxHealth;

        uiLevelUp.Select(0);
        Resume();
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(1);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }
    IEnumerator GameOverRoutine()
    {
        isLive = false;

        yield return new WaitForSeconds(0.5f);

        uiResult.gameObject.SetActive(true);
        uiResult.Lose();
        Stop();
    }

    public void GameVictroy()
    {
        StartCoroutine(GameVictroyRoutine());
    }
    IEnumerator GameVictroyRoutine()
    {
        isLive = false;
        enemyCleaner.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        uiResult.gameObject.SetActive(true);
        uiResult.Win();
        Stop();
    }

    void Update()
    {
        if (!isLive)
            return;

        gameTime += Time.deltaTime;

        if (gameTime > MaxGameTime)
        {
            gameTime = MaxGameTime;
            GameVictroy();
        }
    }

    public void GetExp()
    {
        if (!isLive)
            return;

        exp++;
        

        if(exp == nextExp[Mathf.Min(level, nextExp.Length-1)])
        {
            level++;
            exp = 0;
            uiLevelUp.Show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }

    
}
