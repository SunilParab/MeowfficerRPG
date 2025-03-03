using System;
using UnityEngine;

public class Civilian : Enemy
{

    const int startHealth = 50;
    const int startMana = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        alive = true;
        abilities = new string[] {"Punch","Shoot"};
        stats = new Stats(startHealth,startMana,"Civilian");
    }

}
