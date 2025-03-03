using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{

    public List<Ally> allies;
    public List<Enemy> enemies;
    
    [SerializeField]
    bool allyTurn = true;
    public int curActor = 0;

    bool optionsShown = false;

    bool actionReady = true;
    [SerializeField]
    int delayTime = 1;

    [SerializeField]
    TextMeshProUGUI text;

    public static GameManager reference;

    void Awake()
    {
        reference = this;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (actionReady) {

            if (allyTurn && !optionsShown) {

                optionsShown = true;
                UIManager.reference.StartChoices();

            } else {

                string[] abilityList = enemies[curActor].GetAbilities();

                string chosenAbility = abilityList[Random.Range(0,abilityList.Length)];

                List<Combatant> targets = Abilities.GetTargets(chosenAbility,allyTurn);

                Abilities.UseAbility(chosenAbility,targets[Random.Range(0,targets.Count)]);

                Invoke("TurnDelay",delayTime);
                actionReady = false;

            }

        }
    }

    public void TakeChoice() {
        allies[curActor].EndTurn();

        Invoke("TurnDelay",delayTime);
        actionReady = false;
        optionsShown = false;
    }

    void TurnDelay() {
        actionReady = true;
    }


}
