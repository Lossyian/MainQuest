using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] UiManager uiManager;
    [SerializeField] LayerMask PlayerLayer;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UiManager>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            
            manager.getCoin++;
            uiManager.NowScoer();
            manager.MaxCoin();
            gameObject.SetActive(false);

        }
    }
}
