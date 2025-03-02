using System;
using UnityEngine;

public class Lily : Ally
{

    const int startHealth = 100;
    const int startMana = 80;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        alive = true;
        abilities = new string[] {"Flip","Shoot","Encourage"};
        stats = new Stats(startHealth,startMana);
    }

}
