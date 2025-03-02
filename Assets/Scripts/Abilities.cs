using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Abilities
{
    public static List<Combatant> GetTargets(string name, bool isAlly) {

        switch(name) {

            default:
                if (isAlly) {
                    return new List<Combatant>(GameManager.manager.enemies);
                } else {
                    return new List<Combatant>(GameManager.manager.allies);
                }
        }
    }

    public static void UseAbility(string name, Combatant target) {

        object[] input = {target};
        typeof(Abilities).GetMethod(name).Invoke(null,input);

    }

    static public void Punch(Combatant target) {
        target.TakeDamage(10);
    }

    static public void Shoot(Combatant target) {
        target.TakeDamage(30);
    }

    static public void Defend(Combatant target) {

    }

}
