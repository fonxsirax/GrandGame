using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_projectile : MonoBehaviour
{
    public GameObject owner;
    private Animator animator;
    public float speed;
    private bool left;

    public float timeAct=0;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        owner.GetComponent<Player_info>();
    }
    private void Awake()
    {
        timeAct = Time.time;
        if (owner.GetComponent<Player_info>().turnedLeft)
        {
            left = true;
        }
        else
        {
            left = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeAct + lifeTime) {
            Destroy(gameObject);
        }
        if (!left)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (collision.gameObject.name != "Wizard"))
        {
            animator.SetTrigger("explosion");
            collision.gameObject.GetComponent<Player_info>().Hurt(2, owner.GetComponent<Player_info>().turnedLeft,"Wizard");
            Destroy(gameObject, 0.3f);
        }
        //if (collision.gameObject.name == "Path")
        //{
        //    Destroy(gameObject, 2f);
        //}
    }
}
