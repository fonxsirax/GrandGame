using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Juliana : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private Player_info this_player;
    public GameObject wind;
    public GameObject projectile1;
    public Transform firepoint;
    public Transform firepoint2;


    private float timeAct = 0;
    private float timeAct2 = 0;
    public float Cdshoot;
    public float Cdwind;

    public bool Is_jumping = false;
    public int energy = 2;

    public GameObject floor;
    public float jumpForce = 600f;


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
        if (this_player.number == 1)
        {
            Player1Movements();
        }
        if (this_player.number == 2) {
            Player2Movements();
        }
        if (this_player.number == 3)
        {
            Player3Movements();
        }
    }
    public void Player1Movements() {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("atk", true);
            Projectile();
        }
        else
        {
            animator.SetBool("atk", false);
        }
        if (Input.GetButtonDown("Fire2")) {
            Wind();
        }
        if (Is_jumping)
        {
            this_player.On_floor = false;
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(0f, jumpForce));
            //animator.SetBool("jump", true);
            energy--;
            Is_jumping = false;   
        }
    }
    public void Player3Movements() {
        if (Input.GetButtonDown("3Fire1"))
        {
            animator.SetBool("atk", true);
            Projectile();
        }
        else
        {
            animator.SetBool("atk", false);
        }
        if (Input.GetButtonDown("3Fire2"))
        {
            Wind();
        }
        if (Is_jumping)
        {
            this_player.On_floor = false;
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(0f, jumpForce));
            //animator.SetBool("jump", true);
            energy--;
            Is_jumping = false;
        }
    }
    public void Player2Movements() {
        if (Input.GetButtonDown("2Fire1"))
        {
            animator.SetBool("atk", true);
            Projectile();
        }
        else
        {
            animator.SetBool("atk", false);
        }
        if (Input.GetButtonDown("2Fire2"))
        {
            Wind();
        }
        if (Is_jumping)
        {
            this_player.On_floor = false;
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(0f, jumpForce));
            //animator.SetBool("jump", true);
            energy--;
            Is_jumping = false;
        }
    }

    public void Wind() {
        if (Time.time - timeAct2 > Cdwind)
        {
            animator.SetTrigger("tornado");
            wind.SetActive(true);
            Instantiate(wind, firepoint2.position, firepoint2.rotation);
            wind.SetActive(false);
            timeAct2 = Time.time;
        }
    }

    public void Projectile()
    {
        if (Time.time - timeAct > Cdshoot) {
            projectile1.SetActive(true);
            Instantiate(projectile1,firepoint.transform.position, firepoint.transform.rotation);
            projectile1.SetActive(false);
            timeAct = Time.time;
        }
    }
}
