using UnityEngine;
using System.Collections;

public class FairyMeteor : MonoBehaviour {

    public int strength = 5000;
    public Vector3 direction;

    protected Rigidbody2D rgbd;
    public float timeAct = 0;
    public float lifeTime;

    public void Awake()
    {
        timeAct = Time.time;
        rgbd = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        direction = new Vector3(Random.Range(-30f,30f),0,0);
        rgbd.AddForce(direction * strength);
    }
    public void Update()
    {
        if (Time.time > timeAct + lifeTime)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.name == "Wizard") {
        //    Physics.IgnoreCollision(collision.gameObject.,this.gameObject);
        //}
        //To do > fix that
        if ((collision.gameObject.name != "Wizard") && (collision.gameObject.tag == "Player"))
        {
            collision.gameObject.GetComponent<Player_info>().Hurt(10, !collision.gameObject.GetComponent<Player_info>().turnedLeft,"Wizard");
            //collision.gameObject.GetComponent<Player_info>().Hit(2500, !collision.gameObject.GetComponent<Player_info>().turnedLeft);
            Destroy(gameObject, 5);
        }
    }
}
