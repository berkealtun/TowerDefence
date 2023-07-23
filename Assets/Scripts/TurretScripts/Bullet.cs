using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public int damage = 10;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }
    void Update()
    {
        transform.position =Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        target.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        Destroy(this.gameObject);
    }
}
