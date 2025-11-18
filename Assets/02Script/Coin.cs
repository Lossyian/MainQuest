using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] UiManager uiManager;
    [SerializeField] LayerMask PlayerLayer;
    Rigidbody rb;
    [SerializeField] float coinSpeed =5f;
    [SerializeField] private float radius = 2.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
    private void FixedUpdate()
    {
        Itmepulling();
    }
    void Itmepulling()
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
        rb.MovePosition(transform.position + dir * coinSpeed * Time.fixedDeltaTime);


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 1f, 0.3f);
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
