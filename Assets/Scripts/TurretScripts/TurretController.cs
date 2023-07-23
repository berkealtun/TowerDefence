using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float range = 10.0f;
    public float fireRate = 1f;
    public float currentfireCount =0f;
    public GameObject ballPrefab;
    public Transform target;
    public Transform firePoint;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Update()
    {
        float distanceToEnemy = Vector3.Distance(transform.position, target.position);
        if(distanceToEnemy <= range)
        {
            Vector3 targetDirection = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation,5f*Time.deltaTime);
            
            if (currentfireCount <= 0f)
            {
                Fire();
                currentfireCount = 1f / fireRate;
            }
            currentfireCount -= Time.deltaTime;
        }
    }
    void Fire()
    {
        GameObject ball = Instantiate(ballPrefab,firePoint.position,firePoint.rotation);       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
