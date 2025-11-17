using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject GameClearUI;
    public TextMeshProUGUI coinScoer;




    public GameManager manager;


   
    public void nonSee()
    {
        GameOverUI?.SetActive(false);
        GameClearUI?.SetActive(false);
    }
    public void NowScoer()
    {
        coinScoer.text =$"Coin : {manager.getCoin} / {manager.needCoin}";
        if (manager.getCoin >= manager.needCoin)
        {
            coinScoer.text = "Coin : Complete";
        }
    }

    public void GameOver()
    {

        GameOverUI?.SetActive(true);
        StartCoroutine(OverFadeIN());
    }


    public void GameClear()
    {

        GameClearUI?.SetActive(true);
        StartCoroutine(ClearFadeIn());
    }

    

    IEnumerator ClearFadeIn()
    {
        float showTime = 0f;
        float maxTime = 0.5f;

        while (showTime <= maxTime)
        {
            GameClearUI.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(0f, 1f, showTime / maxTime));
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
            GameOverUI.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(0f, 1f, showTime / maxTime));
            showTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    


}
