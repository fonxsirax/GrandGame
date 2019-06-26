using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject owner;
    public Animator animator;
    public Rigidbody2D body;
    public bool slow;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        owner.GetComponent<Player_info>();
        body = GetComponent<Rigidbody2D>();

        bool toTheLeft = owner.GetComponent<Player_info>().turnedLeft;
        if (!toTheLeft)
        {
            body.AddForce(new Vector2(300, 50));
        }
        else {
            body.AddForce(new Vector2(-300, 50));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (collision.gameObject.name != "Archer"))
        {
            //animator.SetTrigger("explosion");
            collision.gameObject.GetComponent<Player_info>().Hurt(1.5f, owner.GetComponent<Player_info>().turnedLeft,"Archer");

            if (slow)
            {
                collision.gameObject.GetComponent<NegativeStatus>().slowPower = 4;
                collision.gameObject.GetComponent<NegativeStatus>().timeSlow = Time.time + 4;
            }
            Destroy(gameObject, 0.3f);

            
        }
        if (collision.gameObject.name == "Path")
        {
            Destroy(gameObject);
        }
    }
}
