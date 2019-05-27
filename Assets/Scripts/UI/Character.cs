using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Character : MonoBehaviour
{
    public bool selected =false;
    public TextMeshProUGUI Fighter;
    public TextMeshProUGUI Player;
    public TextMeshProUGUI Team;
    public Image FighterImage;
    public bool done = false;
    public int index =0;
    public float move;
    public int aux = 0;
    public List<string> FighterList = new List<string>();
    public List<string> PlayerList = new List<string>();
    public List<Image> SpriteList = new List<Image>();
    public int number;
    public string name;


    void Start() {
        //Fighter = GetComponent<TextMeshProUGUI>();
        //Player = GetComponent<TextMeshProUGUI>();
        //Team = GetComponent<TextMeshProUGUI>();
        FighterList.Add("Ninja");
        FighterList.Add("Knight");
        PlayerList.Add("CPU");
        PlayerList.Add("Player 0");

    }
    void FixedUpdate() {
        if (Player.text == "Player 1" || Player.text == "CPU") { move = Input.GetAxis("Horizontal"); }
        else if (Player.text == "Player 2") { move = Input.GetAxis("2Horizontal"); }
        Fighter.text = FighterList[index];
        Team.text = "NotImpl.";

        //team here
        Selection();

        number = FindNumber();
        name = Fighter.text;

    }
    public int FindNumber() {
        if (Player.text == "Player 1") { return 1;aux = 1; }
        else if (Player.text == "Player 2") { return 2; aux = 2; }
        else { return 0; aux = 3; }
    }
    public void Selection() {
        if (selected) {
                if (move > 0)
                {
                    index++;
                    if (index > FighterList.Count - 1)
                    {
                        index = FighterList.Count - 1;
                    }
                }
                else if (move < 0)
                {
                    index--;
                    if (index < 0)
                    {
                        index = 0;
                    }
                }
            if (Player.text == "Player 1")
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    selected = false;
                    done = true;
                }
            }
            else if(Player.text == "Player 2")
            {
                if (Input.GetButtonDown("2Fire1"))
                {
                    selected = false;
                    done = true;

                }
            }
            //else if (Player.text == "Player 2")
            //{

            //}
            else if (Player.text == "CPU")
            {
                if (move > 0)
                {
                    index++;
                    if (index > FighterList.Count - 1)
                    {
                        index = FighterList.Count - 1;
                    }
                }
                else if (move < 0)
                {
                    index--;
                    if (index < 0)
                    {
                        index = 0;
                    }
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    selected = false;
                    done = true;
                }
            }
        } // if selected
     }
}
