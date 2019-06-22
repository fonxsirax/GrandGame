using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardWind : MonoBehaviour
{
    public GameObject owner;
    private Animator animator;
    public float speed;
    public bool left;
    public float timeAct = 0;
    public float lifeTime;
    // Start is called before the first frame update
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
    void Start()
    {
        animator = GetComponent<Animator>();
        owner.GetComponent<Player_info>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeAct + lifeTime)
        {
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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 10));
        }
    }


}
