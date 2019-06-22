using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Destroy(gameObject, 20f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name != "Warrior") && (collision.gameObject.tag == "Player"))
        {
            collision.gameObject.GetComponent<Player_info>().Hurt(8, collision.gameObject.GetComponent<Player_info>().turnedLeft);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Path") {
            Destroy(gameObject);
        }
    }
}
