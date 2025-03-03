using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{

    public static UIManager reference;
    public bool active = false;
    string ability = null;
    Combatant target = null;

    GameManager manager;

    [SerializeField]
    GameObject optionsMenu;

    [SerializeField]
    GameObject button1;
    [SerializeField]
    GameObject button2;
    [SerializeField]
    GameObject button3;
    [SerializeField]
    GameObject button4;

    void Awake()
    {
        reference = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameManager.reference;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartChoices() {

        gameObject.SetActive(true);

        MakeButtons(manager.allies[manager.curActor].GetAbilities());
    }

    void MakeButtons(string[] input) {
        
        int buttons = input.Length;

        if (buttons >= 1) {
            button1.SetActive(true);
            button1.GetComponentInChildren<TextMeshProUGUI>().text = input[0];
        } else {
            button1.SetActive(false);
        }
        if (buttons >= 2) {
            button2.SetActive(true);
            button2.GetComponentInChildren<TextMeshProUGUI>().text = input[1];
        } else {
            button2.SetActive(false);
        }
        if (buttons >= 3) {
            button3.SetActive(true);
            button3.GetComponentInChildren<TextMeshProUGUI>().text = input[2];
        } else {
            button3.SetActive(false);
        }
        if (buttons >= 4) {
            button4.SetActive(true);
            button4.GetComponentInChildren<TextMeshProUGUI>().text = input[3];
        } else {
            button4.SetActive(false);
        }

    }

    public void ButtonPressed() {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        if (ability == null) {

            ability = button.GetComponentInChildren<TextMeshProUGUI>().text;

            List<Combatant> targets = Abilities.GetTargets(ability,true);
            string[] names = new string[targets.Count];

            for (int i = 0; i < targets.Count; i++) {
                names[i] = targets[i].GetName();
            }

            MakeButtons(names);

        } else {

            int targNum = Int32.Parse(button.name);

            target = manager.enemies[targNum-1];

            manager.TakeChoice(ability,target);

            ClearInfo();

        }
        

    }

    void ClearInfo() {
        ability = null;
        target = null;
        active = false;

        gameObject.SetActive(false);
    }

}
