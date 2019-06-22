using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public int aux = 0;

    private Rigidbody2D body;
    public bool Is_jumping = false;
    public int energy = 2;

    public Player_info this_player;
    private float Timeact;
    private float CdDash;
    public Animator animator;
    public GameObject floor;
    public float jumpForce = 600f;
    public LayerMask ground;
    public GameObject dashWind;
    public GameObject sword;
    //public Transform GroundCheck;
    private float initialSpeed = 9;
    public float radius = 0.2f;
    // Use this for initialization

    void Start()
    {
        animator = this.GetComponent<Animator>();
        this_player = this.GetComponent<Player_info>();
        //game_control = GetComponent<Game_controller>();
        body = GetComponent<Rigidbody2D>();
        Timeact = 0;
        //sprite = GetComponent<SpriteRenderer>();
        //Player_info player1 = new Player_info();
        //player1.name = "Knight";
        //player1.number = 1;
        //player1.totaLife = 100;
        //player1.currentLife = 100;
        //this_player = player1;
    }
    void Update()
    {
        //check if is dead
        if (this_player.number == 1)
        {
            Player1Movements();
        }
        else if (this_player.number == 2) {
            Player2Movements();
        }
    }
    private void FixedUpdate()
    {
        if (energy == 0 && !this_player.On_floor) {
            animator.SetBool("jump", true);
        }
        // separado para o futuro
        if (this_player.Is_walking && !this_player.turnedLeft)
        {
            if ((Time.time - Timeact) < 0.5f && (Time.time - Timeact) > 0.05f)
            {
                this_player.speed += 6;
            }
            Timeact = Time.time;
        }
        else if (this_player.Is_walking && this_player.turnedLeft)
        {
            if ((Time.time - Timeact) < 0.5f && (Time.time - Timeact) > 0.05f)
            {
                this_player.speed += 6;
            }
            Timeact = Time.time;
        }

        if (Is_jumping)
        {
            energy--;
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(0f, jumpForce));
            Is_jumping = false;
            
        }
        if (this.this_player.On_floor)
        {
            animator.SetBool("jump", false);
            energy = 2;
        }
        //Dash is over
        if (Time.time - CdDash > 0.2f)
        {
            animator.SetBool("dash", false);
            dashWind.SetActive(false);
        }
        if (this_player.number == 1) {
            if (body.velocity.y > 0f && !Input.GetButton("Jump"))
            {
                body.velocity += Vector2.up * -0.8f;
            }
        }
        else if (this_player.number == 2) {
            if (body.velocity.y > 0f && !Input.GetButton("2Jump"))
            {
                body.velocity += Vector2.up * -0.8f;
            }
        }
    }
    void Player1Movements() {

        if (this_player.Is_walking)
        {
            if (Input.GetButtonDown("Fire2") && Time.time - CdDash > 1f)
            {
                animator.SetBool("dash", true);
                dashWind.SetActive(true);
                CdDash = Time.time; //to turn dash off
                energy = 0;
            }
        }
        else
        {
            this_player.speed = initialSpeed;
        }

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
        //double jump.
        if (Input.GetButtonDown("Jump") && energy > 0)
        {
           this_player.On_floor = false;
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(0f, jumpForce));
            //animator.SetBool("jump", true);
            energy--;
        }
    }
    void Player2Movements()
    {
        if (this_player.Is_walking)
        {
            if (Input.GetButtonDown("2Fire2") && Time.time - CdDash > 1f)
            {
                animator.SetBool("dash", true);
                dashWind.SetActive(true);
                CdDash = Time.time; //to turn dash off
                energy = 0;
            }
        }
        else
        {
            this_player.speed = initialSpeed;
        }

        if (Input.GetButtonDown("2Fire1"))
        {
            animator.SetBool("atk", true);
            //sword.SetActive(true);
        }
        else
        {
            animator.SetBool("atk", false);
            //sword.SetActive(false);
        }
        //double jump.
        if (Input.GetButtonDown("2Jump") && energy > 0)
        {
            this_player.On_floor = false;
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(0f, jumpForce));
            //animator.SetBool("jump", true);
            energy--;
        }
    }
    //void death()
    //{
    //    for (int i = 0; i < referenceScriptGame_controller.Characteres.Count; i++)
    //    {
    //        if (i + 1 == this_player.number)
    //        {
    //            referenceScriptGame_controller.Characteres.RemoveAt(i);
    //            Destroy(gameObject);
    //            break;
    //        }
    //    }
    //}

   // void Getdamage(int damage) {
     //       referenceScriptGame_controller.Characteres[this_player.number].currentLife -= damage;  
    //}
    public Rigidbody2D Body
    {
        get
        {
            return this.body;
        }
    }
}
