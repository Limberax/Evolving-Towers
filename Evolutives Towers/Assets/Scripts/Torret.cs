using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torret : MonoBehaviour
{
    [Header("Generic Attributes")]
    [SerializeField] private float range;

    private string enemyTag = "Enemy";
    private Enemy targetEnemy;

    [Header("Requires Fields")]
    [SerializeField] private Transform partToRotate1;
    [SerializeField] private Transform partToRotate2;
    [SerializeField] private Transform fireLocation1;
    [SerializeField] private Transform fireLocation2;

    [Header("Using Bullets")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float fireCountDown;

    [Header("Using PlasmaBeam")]
    [SerializeField] private bool usePlasmaBeam = false;
    [SerializeField] private int damageOverTime;
    [SerializeField] private LineRenderer laserRenderer;
    [SerializeField] private float slowNumber;

    private Transform target;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {

            if (usePlasmaBeam)
            {
                if (laserRenderer.enabled)
                    laserRenderer.enabled = false;
            }

            return;
        }

        if(usePlasmaBeam)
        {
            Laser();
        }
        else
        {
            if (fireCountDown < 0)
            {
                Shoot();
                fireCountDown = 1 / fireRate;
            }

            fireCountDown -= Time.deltaTime;
            PointToTarget();
        }
        
       
    }

    public void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearEnemy = null;
        float shortDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= shortDistance)
            {
                shortDistance = distanceToEnemy;
                nearEnemy = enemy;
            }
        }

        if (nearEnemy != null && shortDistance <= range && nearEnemy.GetComponent<Enemy>().isAlive)
        {
            target = nearEnemy.transform;
            targetEnemy = nearEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void PointToTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate1.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (partToRotate2 != null)
        {
            partToRotate2.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    public void Laser()
    {
        targetEnemy.TakeHit(damageOverTime * Time.deltaTime);

        //Slow
        targetEnemy.Slow(slowNumber);


        if (!laserRenderer.enabled)
            laserRenderer.enabled = true;

        laserRenderer.SetPosition(0, fireLocation1.position);
        laserRenderer.SetPosition(1, target.position);
    }

    public void Shoot()
    {
        GameObject bullet1 = (GameObject)Instantiate(bulletPrefab, fireLocation1.position, fireLocation1.rotation);
        Bullet _bullet1 = bullet1.GetComponent<Bullet>();
        _bullet1.Seek(target);

        if (fireLocation2 != null)
        {
            GameObject bullet2 = (GameObject)Instantiate(bulletPrefab, fireLocation2.position, fireLocation2.rotation);
            Bullet _bullet2 = bullet2.GetComponent<Bullet>();
            _bullet2.Seek(target);
        }
    }
}
