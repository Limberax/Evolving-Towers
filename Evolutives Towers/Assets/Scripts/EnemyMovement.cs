using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int wayPointIndex = 0;
    private Enemy enemy;

    private Transform initPos;
    public Animator anim;
    void Start()
    {
        enemy = GetComponent<Enemy>();

        initPos = WayPoint.path_0[0];

        anim = transform.GetChild(0).GetComponent<Animator>();
        MoveToWayPoints();
        anim.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {

        if (!enemy.isAlive)
        {
            return;
        }

        GetNextWaypoint();

    }

    public void MoveToWayPoints()
    {
        Vector3 dir = initPos.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, initPos.position) <= 0.3f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;

        //target = WayPoint.path_0[wayPointIndex].position;
        //Identifica hacia que lado moverse entre WayPoints
        /*
        if (Mathf.Abs (target.x - transform.position.x) > 0.4f)
        {
            if (target.x > transform.position.x)
            {
                transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 90f, 0);
            }
            else
            {
                transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 270f, 0);
            }
        }
        else
        {
            if (Mathf.Abs (target.z - transform.position.z) > 0.4f)
            {
                if (target.z > transform.position.z)
                {
                    transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0f, 0);
                }
                else
                {
                    transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 180f, 0);
                }
            }
        }
        */
    }

    private void GetNextWaypoint()
    {

        transform.position = Vector3.MoveTowards(transform.position, WayPoint.path_0[wayPointIndex].position, enemy.speed * Time.deltaTime);

        if (wayPointIndex >= WayPoint.path_0.Length - 1)
        {
            EndPath();
            return;
        }

        if (Vector3.Distance(transform.position, WayPoint.path_0[wayPointIndex].position) < 0.25f)
        {
            wayPointIndex++;
        }
    }
    public void EndPath()
    {
        PlayerStats.Live--;
        WaveSpawner.EnemiesAlive--;
        Destroy(this.gameObject);
    }
    public void Die()
    {
        PlayerStats.Money += enemy.bounty;
        enemy.isAlive = false;
        anim.SetBool("isWalking", false);
        anim.SetBool("isDead", true);

        WaveSpawner.EnemiesAlive--;

        Destroy(this.gameObject, 3f);
        //SFX
        // FindObjectOfType<AudioManager>().Play("ZombiemanScream");
    }

}
