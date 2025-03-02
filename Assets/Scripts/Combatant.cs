using UnityEngine;

public class Combatant : MonoBehaviour
{
    [SerializeField]
    protected Stats stats;
    protected bool alive;
    protected string[] abilities;
    
    public string[] GetAbilities() {
        return abilities;
    }

    public void TakeDamage(int damage) {
        stats.health -= damage;
    }

}

[System.Serializable]
public struct Stats {
    
    public int health;
    public int energy;

    public Stats(int health, int energy) {
        this.health = health;
        this.energy = energy;
    }

}