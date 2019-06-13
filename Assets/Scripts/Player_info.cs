using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_info : MonoBehaviour
{
    //private GameObject referenceObject;
    //private Game_controller referenceScript; //Link to game controller

    //private Player player;
    public int aux = 0;
    public string name;
    public int number = 1;
    public float totaLife = 100;
    public float currentLife;
    public float totalMana = 100;
    public float currentMana;
    public float pressingMana =0;  //
    public int skill;              //

    public GameObject effect;

    private float armor = 8;
    private float power = 2;

    private Animator animator;
    private Rigidbody2D body;

    public bool turnedLeft = false;
    public bool Is_walking = false;
    public float move;
    public float speed = 9;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();

       // player = this.GetComponent<Player>();
        currentLife = totaLife;
        currentMana = 0;

    }

    // Update is called once per frame
    void FixedUpdate() {
        body.velocity = new Vector2(move * speed, body.velocity.y);
        if ((move > 0 && turnedLeft) || (!turnedLeft && move < 0))
        {
            aux = 19;
            Flip();
        }
        if (number == 1)
        {
            Player1ManaPressing();
        }
        else if (number == 2) {
            Player2ManaPressing();
        }
    }
    void Update()
    {
        if (number == 1) { move = Input.GetAxis("Horizontal"); }
        else if (number == 2) { move = Input.GetAxis("2Horizontal"); }
        currentMana += 0.01f;
        if (currentMana > totalMana)
        {
            currentMana = 100;
        }
        if (currentLife < 0)
        {
            currentLife = 0;
        }
        if (move > 0)
        {
            animator.SetBool("walk", true);
            Is_walking = true;
        }
        else if (move < 0) //concertar isso
        {
            animator.SetBool("walk", true);
            Is_walking = true;
        }
        else
        {
            Is_walking = false;
            animator.SetBool("walk", false);
        }
    }
    void Player2ManaPressing()
    {
        if (Input.GetButton("2Fire2"))
        {
            effect.SetActive(true);
            pressingMana += 0.3f;
            if (pressingMana > currentMana)
            {
                pressingMana = currentMana;
            }
        }
        else
        {
            effect.SetActive(false);
            if (pressingMana > 33f && pressingMana < 60f)
            {
                currentMana -= 33f;
                pressingMana = 0;
                skill = 1;
            }
            else if (pressingMana > 60f && pressingMana < 95f)
            {
                currentMana -= 66f;
                pressingMana = 0;
                skill = 2;
            }
            else if (pressingMana > 95f)
            {
                currentMana = 0;
                pressingMana = 0;
                skill = 3;
            }
            pressingMana = 0;
        }
    }
    void Player1ManaPressing()
    {
        if (Input.GetButton("2Fire2"))
        {
            effect.SetActive(true);
            pressingMana += 0.3f;
            if (pressingMana > currentMana)
            {
                pressingMana = currentMana;
            }
        }
        else
        {
            effect.SetActive(false);
            if (pressingMana > 33f && pressingMana < 60f)
            {
                currentMana -= 33f;
                pressingMana = 0;
                skill = 1;
            }
            else if (pressingMana > 60f && pressingMana < 95f)
            {
                currentMana -= 66f;
                pressingMana = 0;
                skill = 2;
            }
            else if (pressingMana > 95f)
            {
                currentMana = 0;
                pressingMana = 0;
                skill = 3;
            }
            pressingMana = 0;
        }
    }
    public void Hurt(float damage, bool turnedLeft){

        //float impact = 2000f;
        float impact = 3000 - 2 * currentLife * armor;
        //float impact = 20000;
        animator.SetTrigger("hurt");
        currentLife -= damage;
        if (turnedLeft)
        {

            body.AddRelativeForce(new Vector3(impact * (-1), (impact) / 20, 0));    
        }
        else {
            body.AddRelativeForce(new Vector3(impact, impact/20, 0));
        }
    }
    public float getPower
    {
        get
        {
            return this.power;
        }
    }
    public void Flip()
    {
        turnedLeft = !turnedLeft;
        transform.Rotate(0f, 180f, 0f);
    }
    public float GetHP() {
        return currentLife;
    }
    public Rigidbody2D Body
    {
        get
        {
            return this.body;
        }
    }
}
