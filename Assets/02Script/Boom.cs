using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] CoinSpawner coinspawner;
    [SerializeField] UiManager uiManager;
    [SerializeField] float radius= 10.0f;
    [SerializeField] float boomsSpeed = 4.0f;
    [SerializeField] LayerMask PlayerLayer;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coinspawner = FindObjectOfType<CoinSpawner>();
        uiManager = FindObjectOfType<UiManager>();
        manager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        
        
    }

   
    void Update()
    {
        Chase();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        if (manager.getCoin < 5)
        {
            manager.GameOver();
            gameObject.SetActive(false);
        }
        else
        {
            manager.getCoin -= 5;
            uiManager.NowScoer();
            coinspawner.splitCoine();
            gameObject.SetActive(false);
            coinspawner.NewOneBoom();
        }
       
    }
    
    void Chase()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radius, PlayerLayer);
        if (cols.Length == 0) return;
        Collider nearest = cols[0];
        float minDist = Vector3.Distance(transform.position, nearest.transform.position);

        foreach (Collider c in cols)
        {
            float dist = Vector3.Distance(transform.position, c.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = c;
            }
        }

        Vector3 targetPos = new Vector3(nearest.transform.position.x, 1.027f, nearest.transform.position.z);
        Vector3 dir = (targetPos - transform.position).normalized;
        rb.MovePosition(transform.position + dir * boomsSpeed * Time.fixedDeltaTime);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 1f, 0.3f);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
}
