using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int needCoin=30;
    [SerializeField] float Timeout= 60.0f;
    public UiManager uiManager;
    public CoinSpawner coinSpawner;
    public PoolManager pools;
    public Player player;

    public int getCoin = 0;
    bool gameOver = false;
    bool gameClear= false;

    private void Awake()
    {
        coinSpawner. SpawnCoin();
        uiManager.NowScoer();
    }
    void Start()
    {
        uiManager.nonSee();
    }

     public void MaxCoin()
    {
        if (getCoin >= needCoin)
        {
            GameClear();
        }
    }

    

    void GameOver()
    {
        gameOver = true;
        uiManager.GameOver();
        
    }

    void GameClear()
    {
        
        gameClear = true;
        uiManager.GameClear();


    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restarting();
        }
    }
    void Restarting()
    {
        
        if (gameClear || gameOver)
        {
         Debug.Log("다시 시작한다요");
            pools.Unset(0);
            player.ResetPosition();
            coinSpawner.SpawnCoin();
            uiManager.nonSee();
            needCoin = 0;
            uiManager.NowScoer();
        }
        
    }
}
