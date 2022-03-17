using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAScript : MonoBehaviour
{
    public Transform target;
    public float range = 15f;
    public Transform rotator;
    public string enemyTag = "Enemy";
    public Rigidbody2D rb;

    Vector3 firepointOffset = new Vector3(0, -1, 0);

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce;

    public float lifeSpan;
    public float duration;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    private void Awake()
    {
        lifeSpan = duration;
        Invoke("killTurret", lifeSpan);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            } else
            {
                target = null;
            }
        }

    }
    private void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 180f;
        rb.rotation = angle;

        if (fireCountdown <= 0f)
        {
            FindObjectOfType<AudioManager>().Play("TurretShot");
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        /*if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }*/
        fireCountdown -= Time.deltaTime;
        //lifeSpan -= Time.deltaTime;
    }

    void Shoot()
    {
        print("spawned bullet");
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position + firepointOffset, firePoint.rotation);
        bullet Bullet = bulletGo.GetComponent<bullet>();
        Rigidbody2D rb = bulletGo.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        if (Bullet != null)
            Bullet.Seek(target);
    }
    void killTurret()
    {
        Destroy(gameObject);
    }
}
