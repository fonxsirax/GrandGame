using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public float jumpForce;
    public bool Is_jumping;
    public int energy = 3;

    private Player_info this_player;
    public GameObject floor;

    protected Animator animator;

    public GameObject firepoint;

    public GameObject arrow;
    private float timeAct = 0;
    public float Cdshoot;
    private float timeactBigjump;
    private Rigidbody2D body;

    public GameObject heart;
    // Start is called before the first frame update
    void Start()
    {
        this_player = GetComponent<Player_info>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (energy == 0 && !this_player.On_floor)
        {
            //animator.SetTrigger("doublejump");
            animator.SetBool("jump", true);
        }
        if (this_player.On_floor)
        {
            animator.SetBool("jump", false);
            energy = 2;
        }
        if (Input.GetButtonDown("Jump") && energy > 0 && this_player.number == 1)
        {
            Is_jumping = true;
        }
        if (Input.GetButtonDown("2Jump") && energy > 0 && this_player.number == 2)
        {
            Is_jumping = true;
        }
        if (Input.GetButtonDown("3Jump") && energy > 0 && this_player.number == 3)
        {
            Is_jumping = true;
        }
    }
    private void FixedUpdate()
    {
        if (Is_jumping)
        {
            this_player.On_floor = false;
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(0f, jumpForce));
            //animator.SetBool("jump", true);
            energy--;
            Is_jumping = false;
        }
        if (this_player.number == 1)
        {
            Player1Movements();
        }
        if (this_player.number == 2)
        {
            Player2Movements();
        }
        if (this_player.number == 3)
        {
            Player3Movements();
        }
    }

    private void Player3Movements()
    {
        throw new NotImplementedException();
    }

    private void Player2Movements()
    {
        throw new NotImplementedException();
    }

    private void Player1Movements()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("atk", true);
            Arrow();
        }
        else
        {
            animator.SetBool("atk", false);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (timeactBigjump + 0.7f < Time.time) {
                heart.SetActive(true);
                heart.GetComponentInChildren<ParticleSystem>().Play(true);
                timeactBigjump = Time.time;
                InvokeRepeating("BigJump", 0f, 0.05f);
            }
        }
    }

    private void BigJump()
    {
        if (this_player.turnedLeft) {
            this.body.AddRelativeForce(new Vector2(1700, 50));
        }
        else {
            this.body.AddRelativeForce(new Vector2(-1700, 50));
        }
        if (timeactBigjump +0.5f <Time.time)
        {
            CancelInvoke("BigJump");
            heart.GetComponentInChildren<ParticleSystem>().Stop();
            heart.SetActive(false);
        }
    }

    public void Arrow()
    {
        if (Time.time - timeAct > Cdshoot)
        {
            arrow.SetActive(true);
            Instantiate(arrow, firepoint.transform.position, firepoint.transform.rotation);
            arrow.SetActive(false);
            timeAct = Time.time;
        }
    }
}
