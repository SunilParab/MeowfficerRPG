using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{

    public static UIManager reference;
    public bool active = false;
    public bool optionChosen = false;
    string ability = null;
    Combatant target = null;

    GameManager manager;

    [SerializeField]
    GameObject optionsMenu;

    void Awake()
    {
        reference = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameManager.reference;
    }

    // Update is called once per frame
    void Update()
    {
        if (active && optionChosen) {
            if (target == null) {
                MakeButtons(manager.allies[manager.curActor].GetAbilities());
            } else {

                List<Combatant> targets = Abilities.GetTargets(ability,true);
                string[] names = new string[targets.Count];

                for (int i = 0; i < targets.Count; i++) {
                    names[i] = targets[i].GetName();
                }

                MakeButtons(names);

            }
        }
    }

    public void StartChoices() {
        MakeButtons(manager.allies[manager.curActor].GetAbilities());
    }

    void MakeButtons(string[] input) {
        
    }

    public void ButtonPressed() {
        GameObject button = EventSystem.current.currentSelectedGameObject;
    }

}
