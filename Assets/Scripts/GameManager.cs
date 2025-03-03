using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    public Ally[] allies;
    public Enemy[] enemies;
    
    [SerializeField]
    bool allyTurn = true;
    int curActor = 0;

    bool actionReady = true;
    [SerializeField]
    int delayTime = 1;

    InputAction navAction;
    InputAction interAction;

    public static GameManager manager;

    void Awake()
    {
        manager = this;
    }

    void Start()
    {
        navAction = InputSystem.actions.FindAction("Navigate");
        interAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if (actionReady) {

            if (allyTurn) {

                if (interAction.triggered) {

                    
                    
                    allies[curActor].EndTurn();

                    Invoke("TurnDelay",delayTime);
                    actionReady = false;

                }

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


    void TurnDelay() {
        actionReady = true;
    }


}
