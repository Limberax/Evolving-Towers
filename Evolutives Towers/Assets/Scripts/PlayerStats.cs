using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 100;

    public static int Live;
    public int startLive = 20;

    public static int Rounds;
    private void Start()
    {
        Money = startMoney;
        Live = startLive;

        Rounds = 0;
    }




}
