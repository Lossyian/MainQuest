using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] PoolManager pools;

    public float minZ = -49.0f;
    public float minX = -49.0f;


    public float maxZ = 49.0f;
    public float maxX = 49.0f;
    public float currentY = 0.5f;
    

    
    
    Vector3 RandomLotation()
    {
        float randomZ = Random.Range(minZ, maxZ);
        float randomX = Random.Range(minX, maxX);
        return new Vector3(randomX, currentY, randomZ);
    }

    public void SpawnCoin()
    {
        for (int i = 1; i<=30;i++)
        {
            Vector3 spawnPosition = RandomLotation();
            GameObject Coin = pools.Get(0);
            Coin.transform.position = spawnPosition;
        }
    }


}
