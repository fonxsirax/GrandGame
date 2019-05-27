using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public Character slot1;
    public Character slot2;
    public Character slot3;
    public int slotcontrol;
    public int aux = 0;
    // Start is called before the first frame update
    void Start()
    {
        slot1.GetComponent<Character>();
        slot2.GetComponent<Character>();
        slot3.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !slot1.selected && !slot1.done)
        {
            slot1.selected = true;
            slot1.Player.text = "Player 1";
        }
        if (Input.GetButtonDown("2Fire1") && !slot2.selected && !slot2.done)
        {
            slot2.selected = true;
            slot2.Player.text = "Player 2";
        }
        if (Input.GetButtonDown("Fire2") && slot1.done)
        {
            slot3.selected = true;
            slot3.Player.text = "CPU";
        }
        
        
    }
}
