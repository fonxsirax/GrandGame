using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeStatus : MonoBehaviour
{
    private Player_info player;
    private float playerInitialSpeed;
    public float timePoison;
    public float poisonPower;

    public float timeSlow;
    public float slowPower;

    public float timeact1;
    public float timeact2;

    public bool flag1;
    public bool flag2;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player_info>();
        playerInitialSpeed = player.speed;
    }
    public void Slow() {
        player.speed = playerInitialSpeed - slowPower;
        Color tmp = player.gameObject.GetComponent<SpriteRenderer>().color;
        tmp.r = 0;
        tmp.g = 191;
        tmp.b = 191;
        tmp.a = 255;
        player.gameObject.GetComponent<SpriteRenderer>().color = tmp;
    }
    public void PoisonColor() {

        Color tmp = Color.green;
            
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
    }
    public void Poison() {
        player.currentLife -= poisonPower;
        gameObject.GetComponent<Animator>().SetTrigger("hurt");
    }
    void Update()
    {
        if (slowPower > 0)
        {
            Slow();
            if (flag1 == false)
            {
                timeact1 = Time.time;
                flag1 = true;
            }
        }
        if ((timeact1 + timeSlow < Time.time) && (flag1 == true))
        { 
            player.speed = playerInitialSpeed;
            flag1 = false;
            slowPower = 0;

            Color tmp = player.gameObject.GetComponent<SpriteRenderer>().color;
            tmp.r = 255;
            tmp.g = 255;
            tmp.b = 255;
            tmp.a = 255;
            player.gameObject.GetComponent<SpriteRenderer>().color = tmp;
        }
        if (poisonPower > 0)
        {
            PoisonColor();
            if (flag2 == false)
            {
                InvokeRepeating("Poison", 0, 1f);
                timeact2 = Time.time;
                flag2 = true;
            }
        }
        if ((timeact2 + timePoison < Time.time) && (flag2 == true))
        {
            player.speed = playerInitialSpeed;
            flag2 = false;
            poisonPower = 0;
            CancelInvoke("Poison");
            Color tmp = player.gameObject.GetComponent<SpriteRenderer>().color;
            tmp.r = 255;
            tmp.g = 255;
            tmp.b = 255;
            tmp.a = 255;
            player.gameObject.GetComponent<SpriteRenderer>().color = tmp;
        }
    }
}
