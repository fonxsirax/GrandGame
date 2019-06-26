using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_star : MonoBehaviour
{
    public GameObject owner;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //lifeTime = Time.time;
        animator = GetComponent<Animator>();
        owner.GetComponent<Player_info>();
    }
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (collision.gameObject.name != "Ninja")) {
            animator.SetTrigger("explosion");
            collision.gameObject.GetComponent<Player_info>().Hurt(1,owner.GetComponent<Player_info>().turnedLeft,"Ninja");
            Destroy(gameObject,0.3f);
        }
        if (collision.gameObject.name == "Path") {
            Destroy(gameObject, 2f);
        }
        
    }
    private void OnDestroy()
    {
        
    }
}
