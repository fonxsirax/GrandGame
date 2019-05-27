using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int aux = 0;
    public float jumpForce;
    public bool Is_jumping;
    public GameObject sword;
    public bool On_floor = false;
    private SpriteRenderer sprite;
    public int energy = 3;
    private Player_info this_player;
    public GameObject floor;
    //public FighterStates currentState = FighterStates.IDLE;

    protected Animator animator;
    private Rigidbody2D body;
    //private StateBehavior exampleSmb;
    public HeroStates currentState = HeroStates.Idle;
    //private AudioSource audioPlayer;


    void Start()
    {
        this_player = GetComponent<Player_info>();
        sprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //audioPlayer = GetComponent<AudioSource>();
    }
 
    void Update()
    {
        //update life
        //if (health <= 0) //&& currentState != HeroStates.dead)
        //{
        //    animator.SetTrigger("dead");
        //}

        if (this_player.number == 1)
        {
            Player1Movements();
        }
        else if (this_player.number == 2) {
            Player2Movements();
        }
    }
    void FixedUpdate() {

        if (On_floor)
        {
            animator.SetBool("jump", false);
            //animator.SetBool("jump", false);
            energy = 2;
            Is_jumping = false;
        }

    }

    void Player1Movements()
    {

        if (Is_jumping)
        {
            animator.SetBool("jump", false);
            if (Input.GetButton("Fire2"))
            {
                aux = 19;
                animator.SetTrigger("duck");
                // shuriken
                energy = 0;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("atk");
        }
        //double jump.
        if (Input.GetButtonDown("Jump") && energy > 0)
        {
            animator.SetBool("jump", true);
            On_floor = false;
            Is_jumping = true;
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(0f, jumpForce));
            //animator.SetBool("jump", true);
            energy--;
            //
        }
    }
    void Player2Movements()
    {

        if (Is_jumping)
        {
            animator.SetBool("jump", false);
            if (Input.GetButton("2Fire2"))
            {
                aux = 19;
                animator.SetTrigger("duck");
                // shuriken
                energy = 0;
            }
        }
        if (Input.GetButtonDown("2Fire1"))
        {
            animator.SetTrigger("atk");
        }
        //double jump.
        if (Input.GetButtonDown("2Jump") && energy > 0)
        {
            animator.SetBool("jump", true);
            On_floor = false;
            Is_jumping = true;
            body.velocity = new Vector2(body.velocity.x, 0f);
            body.AddForce(new Vector2(0f, jumpForce));
            //animator.SetBool("jump", true);
            energy--;
        }
    }

    //get and set
    public Rigidbody2D Body
    {
        get
        {
            return this.body;
        }
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject == floor)
        {
            On_floor = true;
        }
    }
}
