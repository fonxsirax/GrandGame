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
    public Player_info knight;
    public Player_info wizard;

    public GameObject ninjaBar;
    public GameObject warriorBar;
    public GameObject knightBar;
    public GameObject wizardBar;

    // Start is called before the first frame update
    void Start()
    {
        dropdown1.GetComponent<TMPro.TMP_Dropdown>();
        dropdown2.GetComponent<TMPro.TMP_Dropdown>();
        dropdown3.GetComponent<TMPro.TMP_Dropdown>();
        dropdown4.GetComponent<TMPro.TMP_Dropdown>();

        ninja.GetComponent<Player_info>();
        warrior.GetComponent<Player_info>();
        knight.GetComponent<Player_info>();
        wizard.GetComponent<Player_info>();
    }

    // Update is called once per frame
    void Update()
    {
        ninja.number = dropdown1.value;
        warrior.number = dropdown2.value;
        knight.number = dropdown3.value;
        wizard.number = dropdown4.value;
    }

    public void Click() {
        if (dropdown1.value == 0) {
            ninja.gameObject.SetActive(false);
            ninjaBar.SetActive(false);
        }
        else ninja.gameObject.SetActive(true); ninjaBar.SetActive(true);
        if (dropdown2.value == 0)
        {
            warrior.gameObject.SetActive(false);
            warriorBar.SetActive(false);
        }
        else warrior.gameObject.SetActive(true); warriorBar.SetActive(true);
        if (dropdown3.value == 0)
        {
            knight.gameObject.SetActive(false);
            knightBar.SetActive(false);
        }
        else knight.gameObject.SetActive(true); knightBar.SetActive(true);
        if (dropdown4.value == 0)
        {
            wizard.gameObject.SetActive(false);
            wizardBar.SetActive(false);
        }
        else wizard.gameObject.SetActive(true); wizardBar.SetActive(true);
    }
}
