using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject effectExplosion;
    // Start is called before the first frame update
    void Start()
    {
        
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
            collision.gameObject.GetComponent<Player_info>().Hurt(7, collision.gameObject.GetComponent<Player_info>().turnedLeft, "Archer");
            collision.gameObject.GetComponent<NegativeStatus>().slowPower = 5;
            collision.gameObject.GetComponent<NegativeStatus>().timeSlow = 10;
            collision.gameObject.GetComponent<NegativeStatus>().poisonPower = 1;
            collision.gameObject.GetComponent<NegativeStatus>().timePoison = 4;
            effectExplosion.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }
}
