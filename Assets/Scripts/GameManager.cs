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
    Combatant curActorRef;

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
        curActorRef = allies[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (actionReady) {

            if (allyTurn) {

                if (!optionsShown) {

                    optionsShown = true;
                    UIManager.reference.StartChoices();
                }

            } else {

                string[] abilityList = enemies[curActor].GetAbilities();

                string chosenAbility = abilityList[Random.Range(0,abilityList.Length)];

                List<Combatant> targets = Abilities.GetTargets(chosenAbility,allyTurn);

                Abilities.UseAbility(chosenAbility,targets[Random.Range(0,targets.Count)]);

                enemies[curActor].EndTurn();

                int curPos = enemies.FindIndex(Enemy => curActorRef);
                curPos++;

                if (curPos >= enemies.Count) {
                    allyTurn = true;
                    curActor = 0;
                    curActorRef = allies[curActor];
                } else {
                    curActor = curPos;
                    curActorRef = enemies[curActor];
                }

                Invoke("TurnDelay",delayTime);
                actionReady = false;

            }

        }
    }

    public void TakeChoice(string ability, Combatant target) {

        Abilities.UseAbility(ability,target);

        allies[curActor].EndTurn();

        int curPos = allies.FindIndex(Ally => Ally == curActorRef);
        Debug.Log(curPos);
        curPos++;
        
        if (curPos >= allies.Count) {
            allyTurn = false;
            curActor = 0;
            curActorRef = enemies[curActor];
        } else{
            curActor = curPos;
            curActorRef = allies[curActor];
        }

        Invoke("TurnDelay",delayTime);
        actionReady = false;
        optionsShown = false;

    }

    void TurnDelay() {
        actionReady = true;
    }


}
