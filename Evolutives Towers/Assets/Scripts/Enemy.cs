using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{

    [Header("Attributes")]
    public bool isAlive = true;
    [SerializeField] private float HP = 50;
    private float actualHP;
    [SerializeField] public int bounty;
    [SerializeField] public float speed;
    [SerializeField] public float startSpeed;
    //Suport Attributes
     
    EnemyMovement enemyMovement;

    [SerializeField] private Image enemyHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();

        actualHP = HP;
        speed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeHit(float damage)
    {
        
        if (!isAlive)
        {
            return;
        }

        actualHP -= damage;

        enemyHealthBar.fillAmount = actualHP / HP;
        if (actualHP <= 0)
        {
            enemyMovement.Die();
        }
        
    }

    public void Slow(float porcentaje)
    {
        speed = startSpeed * (1f - porcentaje);
    }



}
