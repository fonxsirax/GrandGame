using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Destroy(gameObject,5f);
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.name != "Dragon") && (collision.gameObject.tag == "Player"))
        {
            collision.gameObject.GetComponent<Player_info>().Hurt(0.5f, collision.gameObject.GetComponent<Player_info>().turnedLeft,"Warrior");
        }
    }

}
