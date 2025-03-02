using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Abilities
{
    public static List<Combatant> GetTargets(string name, bool isAlly) {

        List<Combatant> output = new List<Combatant>();

        switch(name) {
            case "Punch":
                
                break;
            case "Shoot":
                
                break;
            case "Defend":
                
                break;
        }
        
        output.Add(GameManager.manager.allies[0]);
        return output;
    }

    public static void UseAbility(string name, Combatant target) {
        switch(name) {
            case "Punch":
                Punch(target);
                break;
            case "Shoot":
                Shoot(target);
                break;
            case "Defend":
                Defend(target);
                break;
        }
    }

    static void Punch(Combatant target) {
        Debug.Log("pow");
    }

    static void Shoot(Combatant target) {
        Debug.Log("pew");
    }

    static void Defend(Combatant target) {

    }

}
