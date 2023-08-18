using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    //[SerializeField] private float timeBetweenEnemies;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float countDown = 2f;
   // [SerializeField] private int[] Waves;
    [SerializeField] private Transform enemyHolder;


    //[SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Wave[] waves;
    [SerializeField] private TMP_Text timer;
    private int index;

    [SerializeField] GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (index == waves.Length)
        {
            gm.WinLevel();
            this.enabled = false;
        }

        if (countDown <= 0)
        {
            StartCoroutine(SpawnWaveCoroutine());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        timer.text = string.Format("{0:00:00}", countDown);
    }

    IEnumerator SpawnWaveCoroutine()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[index];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        index++;


    }

    public void SpawnEnemy(GameObject enemy)
    {
        //Instanciar al Enemy
        Instantiate(enemy, WayPoint.path_0[0].position, WayPoint.path_0[0].rotation, enemyHolder);
        //EnemiesAlive++;
    }
}
