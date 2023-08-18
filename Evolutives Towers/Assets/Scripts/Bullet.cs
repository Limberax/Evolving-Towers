using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float explosionRadius = 0f;


    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            
            return;
        }


        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance (transform.position, target.position) <= 0.25f)
        {
            HitTarget(damage);
            return;
        }
    }

    public void HitTarget (float _damage)
    {
        //Particle system

        

        if (explosionRadius >= 0f)
        {
            Explode();
            Destroy(gameObject);
        }
        else
        {
            Damage(target);
            Destroy(gameObject);
        }

    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
                
            }
        }
    }

    void Damage(Transform enemyGo)
    {
        Enemy enemy = enemyGo.GetComponent<Enemy>();
        
        if(enemy != null)
        {
            enemy.TakeHit(damage);
        }
    }


}
