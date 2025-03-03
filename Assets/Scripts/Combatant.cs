using UnityEngine;

public class Combatant : MonoBehaviour
{
    [SerializeField]
    protected Stats stats;
    protected bool alive;
    protected string[] abilities;

    public Combatant blocker;
    
    public string[] GetAbilities() {
        return abilities;
    }

    public void TakeDamage(int damage) {

        if (blocker == null) {
            stats.health -= damage;
        } else {
            blocker.TakeDamage(damage);
        }
    }

    public void EndTurn() {
        stats.energy += 10;
        blocker = null;
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