using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;
    private Player_info this_player;
    public int aux;
    public bool Is_jumping;
    public int energy = 5;
    public float jumpForce = 900f;

    public float timeAct;

    public GameObject projectile1;
    public GameObject cannon;
    public GameObject simpleFire;
    public GameObject RainFireEffect;

    public Transform firepoint;

    private float timeactRain;

    public GameObject dragonBar;
    //public GameObject warrior;
    // Start is called before the first frame update

    private void Awake()
    {

        ////warrior.SetActive(true);
        //this_player.currentLife = warrior.GetComponent<Player_info>().currentLife;
        //this_player.currentMana = 0;
        //this_player.number = warrior.GetComponent<Player_info>().number;
        //this_player.manaspeed = 0;
        //warrior.SetActive(false);
    }
    void Start()
    {
        this_player = GetComponent<Player_info>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        dragonBar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (this_player.On_floor)
        {
            animator.SetBool("jump", false);
            energy = 5;
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
        if (Is_jumping && Input.GetButtonUp("Fire1") && this_player.number == 1) {
            FireBlast();
        }
        if (Is_jumping && Input.GetButtonUp("2Fire1") && this_player.number == 2)
        {
            FireBlast();
        }
        if (Is_jumping && Input.GetButtonUp("3Fire1") && this_player.number == 3)
        {
            FireBlast();
        }

    }
    private void FixedUpdate()
    {
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

    public void Player1Movements()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("fire");
            //Projectile();
            simpleFire.SetActive(true);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Cannon();
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
    public void Player2Movements()
    {
        if (Input.GetButtonDown("2Fire1"))
        {
            animator.SetTrigger("fire");
            //Projectile();
            simpleFire.SetActive(true);
        }
        if (Input.GetButtonDown("2Fire2"))
        {
            Cannon();
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
    public void Player3Movements()
    {
        if (Input.GetButtonDown("3Fire1"))
        {
            animator.SetTrigger("fire");
            //Projectile();
            simpleFire.SetActive(true);
        }
        if (Input.GetButtonDown("3Fire2"))
        {
            Cannon();
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
    public void Cannon() {
        if (Time.time - timeAct > 10f)
        {
            animator.SetTrigger("cannon");
            cannon.SetActive(true);
            Instantiate(cannon, firepoint.position, firepoint.rotation);
            cannon.SetActive(false);
            timeAct = Time.time;
        }
    }

    public void FireBlast() {

        timeactRain = Time.time;
        InvokeRepeating("CreateFire", 0.5f, 0.4f);
        RainFireEffect.SetActive(true);
        animator.SetTrigger("fireup");
    }

    public void CreateFire()
    {
        float randomx = Random.Range(-15f, 15f);
        Instantiate(projectile1, new Vector3(randomx, 15f, 0f), Quaternion.identity);
        if (Time.time > timeactRain + 8f)
        {
            RainFireEffect.SetActive(false);
            CancelInvoke("CreateFire");
        }
    }


}
