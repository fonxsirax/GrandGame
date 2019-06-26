using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorLaser : MonoBehaviour
{
    public float timeact;
    // Start is called before the first frame update
    private void Awake()
    {
        //timeact = Time.time;
    }
    void Start()
    {
       
    }
    private void OnEnable()
    {
        GetComponentInParent<Player_info>().Invulnerable(true);
    }
    // Update is called once per frame
    void Update()
    {
        GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.name != "Warrior") && (collision.gameObject.tag == "Player"))
        {
            collision.gameObject.GetComponent<Player_info>().Hurt(1, GetComponentInParent<Player_info>().turnedLeft,"Warrior");
            collision.gameObject.GetComponent<Player_info>().Hit(10,10, GetComponentInParent<Player_info>().turnedLeft);
        }
    }
    private void OnDisable()
    {
        GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponentInParent<Player_info>().Invulnerable(false);
    }
}
