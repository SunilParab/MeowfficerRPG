using System;
using UnityEngine;

public class Protag : Ally
{

    const int startHealth = 150;
    const int startMana = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        alive = true;
        abilities = new string[] {"Punch","Shoot","Defend"};
        stats = new Stats(startHealth,startMana,"Protag");
    }

}
