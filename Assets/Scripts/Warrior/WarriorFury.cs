using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorFury : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
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

    }
    private void OnDisable()
    {
        GetComponentInParent<Player_info>().Invulnerable(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.name != "Warrior") && (collision.gameObject.tag == "Player"))
        {
            collision.attachedRigidbody.AddForce(new Vector2(10,80));
            collision.gameObject.GetComponent<Player_info>().Hurt(0.5f, GetComponentInParent<Player_info>().turnedLeft,"Warrior");
        }
    }

}
