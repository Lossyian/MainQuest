using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int needCoin=30;
    public float Timeout= 180.0f;
    public UiManager uiManager;
    public CoinSpawner coinSpawner;
    public PoolManager pools;
    public Player player;

    public int getCoin = 0;
    public bool gameOver = false;
    public bool gameClear= false;

    
    void Start()
    {
        coinSpawner.SpawnCoin();
        coinSpawner.splitBoom();
        uiManager.NowScoer();
        uiManager.nonSee();
    }

     public void MaxCoin()
    {
        if (getCoin >= needCoin)
        {
            GameClear();
        }
    }

    public void Timeouts()
    {
        if (Timeout <= 0) 
        {
            GameOver();
        }
    }
    

    public void GameOver()
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (gameClear || gameOver)
            {
                
                Application.Quit();
            }
        }
    }
    void Restarting()
    {
        
        if (gameClear || gameOver)
        {
            Timeout = 180f;
            pools.Unset(0);
            pools.Unset(1);
            player.ResetPosition();
            coinSpawner.SpawnCoin();
            coinSpawner.splitBoom();
            uiManager.nonSee();
            getCoin = 0;
            gameOver = false;
            gameClear = false;
            uiManager.NowScoer();

        }
        
    }

    
}
