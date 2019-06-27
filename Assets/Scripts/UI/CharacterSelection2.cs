using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterSelection2 : MonoBehaviour
{
   // public Canvas panel;
    public TMPro.TMP_Dropdown dropdown1;
    public TMPro.TMP_Dropdown dropdown2;
    public TMPro.TMP_Dropdown dropdown3;
    public TMPro.TMP_Dropdown dropdown4;

    public Player_info ninja;
    public Player_info warrior;
    public Player_info archer;
    public Player_info wizard;

    public GameObject ninjaBar;
    public GameObject warriorBar;
    public GameObject archerBar;
    public GameObject wizardBar;

    public GameControl control;

    // Start is called before the first frame update
    void Start()
    {
        dropdown1.GetComponent<TMPro.TMP_Dropdown>();
        dropdown2.GetComponent<TMPro.TMP_Dropdown>();
        dropdown3.GetComponent<TMPro.TMP_Dropdown>();
        dropdown4.GetComponent<TMPro.TMP_Dropdown>();

        ninja.GetComponent<Player_info>();
        warrior.GetComponent<Player_info>();
        archer.GetComponent<Player_info>();
        wizard.GetComponent<Player_info>();
    }

    // Update is called once per frame
    void Update()
    {
        ninja.number = dropdown1.value;
        warrior.number = dropdown2.value;
        archer.number = dropdown3.value;
        wizard.number = dropdown4.value;
    }

    public void Click() {
        if (dropdown1.value == 0)
        {
            ninja.gameObject.SetActive(false);
            ninjaBar.SetActive(false);
        }
        else
        {
            ninja.gameObject.SetActive(true);
            ninjaBar.SetActive(true);
            control.Characteres.Add(ninja.gameObject.name);
        }
        if (dropdown2.value == 0)
        {
            warrior.gameObject.SetActive(false);
            //warriorBar.SetActive(false);
        }
        else { 
            warrior.gameObject.SetActive(true);
            warriorBar.SetActive(true);
            control.Characteres.Add(warrior.gameObject.name);
        }
        if (dropdown3.value == 0)
        {
            archer.gameObject.SetActive(false);
            archerBar.SetActive(false);
        }
        else
        {
            archer.gameObject.SetActive(true);
            archerBar.SetActive(true);
            control.Characteres.Add(archer.gameObject.name);
        }
        if (dropdown4.value == 0)
        {
            wizard.gameObject.SetActive(false);
            wizardBar.SetActive(false);
        }
        else
        {
            wizard.gameObject.SetActive(true);
            wizardBar.SetActive(true);
            control.Characteres.Add(wizard.gameObject.name);
        }
    }
}
