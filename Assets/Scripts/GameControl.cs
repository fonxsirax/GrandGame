using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public List<Player_info> Characteres = new List<Player_info>();

    // Start is called before the first frame update
    void Start()
    {

        Player_info player1 = new Player_info();
        player1.name = "Knight";
        player1.number = 1;
        player1.totaLife = 100;
        player1.currentLife = 100;

        Player_info player2 = new Player_info();
        player2.name = "Ninja";
        player2.number = 2;
        player2.totaLife = 100;
        player2.currentLife = 100;



        Characteres.Add(player1);
        Characteres.Add(player2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
