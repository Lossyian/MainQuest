using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] PoolManager pools;
    [SerializeField] Player player;
    [SerializeField] Coin coin;

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

    public void splitCoine()
    {
        
        for (int i = 1; i <= 5; i++)
        {
            Vector3 spawnPosition = RandomLotation(); 
            GameObject coin = pools.Get(0);
            coin.transform.position = player.transform.position + Vector3.up * 0.5f;
            StartCoroutine(MoveCoin(coin.transform, spawnPosition, 0.5f));
        }
    }
    public void splitBoom()
    {
        for (int i = 1; i <= 10; i++)
        {
            Vector3 spawnPosition = RandomLotation();
            GameObject Coin = pools.Get(1);
            Coin.transform.position = spawnPosition;
        }
    }
    public void NewOneBoom()
    {
        Vector3 spawnPosition = RandomLotation();
        GameObject Coin = pools.Get(1);
        Coin.transform.position = spawnPosition;
    }

    private IEnumerator MoveCoin(Transform coinTransform, Vector3 targetPos, float duration)
    {
        Vector3 startPos = coinTransform.position;
        float time = 0f;

        while (time < duration)
        {
            coinTransform.position = Vector3.Lerp(startPos, targetPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        coinTransform.position = targetPos; 
    }


}
