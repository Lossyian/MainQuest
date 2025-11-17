using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject GmaeClearUI;
    public TMP_Text coinScoer;
    private int getCoin;


    public GameManager manager;

    public void nonSee()
    {
        GameOverUI?.SetActive(false);
        GmaeClearUI?.SetActive(false);
    }
    public void NowScoer()
    {
        //현재 점수 텍스트 UI 수정.
        //coinScoer = $"Coin:{getCoin}";
    }

    public void GameOver()
    {
        // 게임 오버 UI Set true 

        //GameOverUI?.SetActive(false);
        OverFadeIN();
    }


    public void GameClear()
    {
        Debug.Log("게임 끝났다요");

        // 게임 클리어 UI Set true 
        GmaeClearUI?.SetActive(true);
       
    }


    IEnumerator ClearFadeIn()
    {
        float showTime = 0f;
        float maxTime =0.5f;

        while (showTime <= maxTime)
        {
            GmaeClearUI.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(1f, 0f, showTime / maxTime));
            showTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
    IEnumerator OverFadeIN()
    {
        float showTime = 0f;
        float maxTime = 0.5f;

        while (showTime <= maxTime)
        {
            GameOverUI.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(1f, 0f, showTime / maxTime));
            showTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

}
