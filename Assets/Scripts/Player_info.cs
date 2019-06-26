using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerKiller {
    public int qtd;
    public string name;
    public PlayerKiller(int qtd, string name) {
        this.qtd = qtd;
        this.name = name;
    }
}
public class Player_info : MonoBehaviour
{
    //private GameObject referenceObject;
    //private Game_controller referenceScript; //Link to game controller

    //private Player player;
    public List<PlayerKiller> killers = new List<PlayerKiller>();
    public string lastDamagePlayer;
    public MultipleCameraTargets camera;
    public Vector3 initialPosition = new Vector3(0,0,0);
    public GameControl control;
    public int lives;
    public int aux = 0;
    public int number = 1;
    public float totaLife = 100;
    public float currentLife = 100;
    public float totalMana = 100;
    public float currentMana;
    public float pressingMana =0;
    public float manaspeed = 1;          
    private float positionDead = -20f;
    public GameObject effect;
    private bool invulnerable = false;
    
    private float armor = 8;
    private float power = 2;

    private Animator animator;
    private Rigidbody2D body;

    public bool turnedLeft = false;
    public bool Is_walking = false;
    public float move;
    public float speed;
    public bool On_floor;

    public Special_Skills skillScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerKiller Wizard = new PlayerKiller(0,"Wizard");
        PlayerKiller Warrior = new PlayerKiller(0, "Warrior");
        PlayerKiller Ninja = new PlayerKiller(0, "Ninja");
        PlayerKiller Archer = new PlayerKiller(0, "Archer");
        killers.Add(Wizard);
        killers.Add(Warrior);
        killers.Add(Ninja);
        killers.Add(Archer);

        skillScript = GetComponent<Special_Skills>();
        body = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();

       // player = this.GetComponent<Player>();
        //currentLife = totaLife;
        //currentMana = 100;

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (move > 0.02)
        {
            animator.SetBool("walk", true);
            Is_walking = true;
        }
        else if (move < -0.02) //concertar isso
        {
            animator.SetBool("walk", true);
            Is_walking = true;
        }
        else
        {
            Is_walking = false;
            animator.SetBool("walk", false);
        }
        body.velocity = new Vector2(move * speed, body.velocity.y);
        if ((move > 0.02 && turnedLeft) || (!turnedLeft && move < -0.02))
        {
            Flip();
        }

    }
    void Update()
    {
        if (number == 1)
        {
            Player1ManaPressing();
        }
        else if (number == 2)
        {
            Player2ManaPressing();
        }
        else if (number == 3)
        {
            Player3ManaPressing();
        }
        if (number == 1) { move = Input.GetAxis("Horizontal"); }
        if (number == 2) { move = Input.GetAxis("2Horizontal"); }
        if (number == 3) { move = Input.GetAxis("3Horizontal"); }
        currentMana += 0.01f * manaspeed;
        if (currentMana > totalMana)
        {
            currentMana = 100;
        }
        if (currentLife < 0)
        {
            currentLife = 0;
        }
        if ((currentLife == 0) || transform.position.y <= positionDead) {
            Death();
        }
    }
    void Player2ManaPressing()
    {
        if (Input.GetButton("2Fire2"))
        {
            effect.SetActive(true);
            pressingMana += 0.6f;
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
                skillScript.Skill1();
            }
            else if (pressingMana > 60f && pressingMana < 95f)
            {
                currentMana -= 66f;
                pressingMana = 0;
                skillScript.Skill2();
            }
            else if (pressingMana > 95f)
            {
                currentMana = 0;
                pressingMana = 0;
                skillScript.Skill3();
            }
            pressingMana = 0;
        }
    }
    void Player3ManaPressing() {
        if (Input.GetButton("3Fire2"))
        {
            effect.SetActive(true);
            pressingMana += 0.8f;
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
                skillScript.Skill1();
            }
            else if (pressingMana > 60f && pressingMana < 95f)
            {
                currentMana -= 66f;
                pressingMana = 0;
                skillScript.Skill2();
            }
            else if (pressingMana > 95f)
            {
                currentMana = 0;
                pressingMana = 0;
                skillScript.Skill3();
            }
            pressingMana = 0;
        }
    }
    void Player1ManaPressing()
    {
        if (Input.GetButton("Fire2"))
        {
            effect.SetActive(true);
            pressingMana += 0.6f;
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
                skillScript.Skill1();
            }
            else if (pressingMana > 60f && pressingMana < 95f)
            {
                currentMana -= 66f;
                pressingMana = 0;
                skillScript.Skill2();
            }
            else if (pressingMana > 95f)
            {
                currentMana = 0;
                pressingMana = 0;
                skillScript.Skill3();
            }
            pressingMana = 0;
        }
    }
    public void Hurt(float damage, bool turnedLeft, string damagerPlayer){
        if (!invulnerable) {
            this.lastDamagePlayer = damagerPlayer;
            if (pressingMana > 0)
            {
                currentMana -= pressingMana;
                pressingMana = 0;
                //animator critico.
                damage *= 2;
            }
            animator.SetTrigger("hurt");
            //float impact = 2000f;
            float impact = (100 / currentLife) * 160 / armor;
            //float impact = 20000;
            currentLife -= damage;
            Hit(impact, (100 - ((int)currentLife) / 10 + 1), turnedLeft);
        }
    }
    public void Hit(float impact,int times, bool turnedLeft) {
        if (turnedLeft)
        {
            if (!this.turnedLeft)
            {
                Flip();
            }
            for (int i = 0; i < times; i++)
            {
                body.AddRelativeForce(new Vector3(impact * (-1), (impact) / 20, 0));
            }
        }
        else
        {
            if (this.turnedLeft)
            {
                Flip();
            }
            for (int i = 0; i < times; i++)
            {
                body.AddRelativeForce(new Vector3(impact, impact / 20, 0));
            }
            
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
    public void Invulnerable(bool active)
    {
        if (active)
        {
            invulnerable = true;
        }
        else {
            invulnerable = false;
        }
    }
    public void Death() {
        for (int i = 0; i <killers.Count;i++) {
            if (killers[i].name == lastDamagePlayer) {
                killers[i].qtd++;
                break;
            }
        } //recording the killer.
        lives--;
        gameObject.transform.position = initialPosition;
        //camera.targets.Add(gameObject.transform);
        currentLife = 100f;
        currentMana = 0;

        if (lives == 0) {
            control.RemoveChar(name);
            Destroy(gameObject);
        }

    }
    public Rigidbody2D Body
    {
        get
        {
            return this.body;
        }
    }
    void OnCollisionEnter2D(Collision2D theCollision)
    {
        if (theCollision.gameObject.tag == "Path" || theCollision.gameObject.tag == "Player")
        {
            On_floor = true;
        }
    }
    public float GetSpeed() {
        return this.speed;
    }
    public void SetSpeed(float speed) {
        this.speed = speed;
    }
}
