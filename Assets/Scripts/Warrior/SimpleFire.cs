using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFire : MonoBehaviour
{
    private float ttl;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        ttl = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (ttl + 0.5f < Time.time) {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name != "Warrior") && (collision.gameObject.tag == "Player"))
        {
            collision.gameObject.GetComponent<Player_info>().Hurt(5, GetComponentInParent<Player_info>().turnedLeft);
        }
    }
}
