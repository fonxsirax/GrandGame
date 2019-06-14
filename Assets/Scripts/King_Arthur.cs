using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Arthur : MonoBehaviour
{
    public Player_info this_player;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        this_player = this.GetComponent<Player_info>();

    }

    // Update is called once per frame
    void Update()
    {
        if (this_player.number == 1)
        {
            Player1Movements();
        }
        else if (this_player.number == 2)
        {
            Player2Movements();
        }

    }

    void Player1Movements()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("atk", true);
            //sword.SetActive(true);
        }
        else
        {
            animator.SetBool("atk", false);
            //sword.SetActive(false);
        }
    }


    void Player2Movements()
    {
    }

}
