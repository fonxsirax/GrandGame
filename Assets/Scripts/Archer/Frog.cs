using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Rigidbody2D body;
    private float timeAct;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        timeAct = Time.time;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(new Vector2(0, 15));
        if (timeAct + 5f > Time.time)
        {
            body.velocity = new Vector2(-3, body.velocity.y);
        }
        else {
            if (!flag) {
                transform.Rotate(0f, 180f, 0f);
                flag = true;
            }
            body.AddForce(new Vector2(100, 10));
        }
        if (timeAct + 30f < Time.time) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name != "Archer") && (collision.gameObject.tag == "Player"))
        {
            collision.gameObject.GetComponent<Player_info>().Hurt(8, collision.gameObject.GetComponent<Player_info>().turnedLeft, "Archer");
        }
    }
}