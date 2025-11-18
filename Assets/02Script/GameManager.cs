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
                Debug.Log("°ÔÀÓ²ö´Ù¿ä");
                Application.Quit();
            }
        }
    }
    void Restarting()
    {
        
        if (gameClear || gameOver)
        {
         
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
