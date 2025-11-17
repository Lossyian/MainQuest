using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int needCoin=30;
    [SerializeField] float Timeout= 60.0f;
    [SerializeField] UiManager uiManager;

    public int getCoin = 0;
    bool gameOver = false;
    bool gameClear= false;

    private void Awake()
    {
        uiManager = FindObjectOfType<UiManager>();
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
        Restarting();
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
         //모든 오브젝트를 오브젝트 풀로 되돌려주기
         // 플레이어 캐릭터 스폰위치로 스폰.
         uiManager.nonSee();
        }
        
    }
}
