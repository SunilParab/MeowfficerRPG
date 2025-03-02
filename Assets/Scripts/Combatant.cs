using UnityEngine;

public class Combatant : MonoBehaviour
{
    protected Stats stats;
    protected bool alive;
    protected string[] abilities;
    
    public string[] getAbilities() {
        return abilities;
    }

}

public struct Stats {

    int health;
    int energy;

    public Stats(int health, int energy) {
        this.health = health;
        this.energy = energy;
    }

}