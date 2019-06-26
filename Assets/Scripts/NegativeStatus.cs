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

    public float timeact;
    public bool flag;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player_info>();
        playerInitialSpeed = player.speed;
    }
    public void Slow() {
        player.speed = playerInitialSpeed - slowPower;
    }
    // Update is called once per frame
    void Update()
    {
        Slow();
        if (timeSlow < Time.time) {
            if (!flag)
            {
                player.speed = playerInitialSpeed;
            }
        }
        //mudar esse script depois
    }
}
