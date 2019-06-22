using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody2D))]
public class FairyDust : MonoBehaviour {
    public float intervalInSec;
    public Vector3 minCoord;
    public Vector3 maxCoord;
    public float speed;
    public float maxVelocityMagnitude;
    protected Vector3 initPos;
    protected Rigidbody2D rgbd;
    protected Vector3 nextPos;

    public GameObject owner;

    public void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        rgbd.drag = 1;
        initPos = transform.position;
        InvokeRepeating("GetNextPosition", 0, intervalInSec);
    }

    public void FixedUpdate()
    {
        if (rgbd.velocity.sqrMagnitude > maxVelocityMagnitude * maxVelocityMagnitude)
            return;
        Vector3 directionToNextPos;
        directionToNextPos = (nextPos - transform.position).normalized;
        rgbd.AddForce(directionToNextPos * speed);

        //Debug.DrawLine(transform.position, nextPos, Color.red);
    }

    public void GetNextPosition()
    {
        Vector3 tmp;
        float x, y, z;
        x = Random.Range(minCoord.x, maxCoord.x);
        y = Random.Range(minCoord.y, maxCoord.y);
        z = Random.Range(minCoord.z, maxCoord.z);
        tmp = new Vector3(owner.transform.position.x + x, owner.transform.position.y + y, owner.transform.position.z + z);
        nextPos = tmp + initPos;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.name == "Wizard") {
        //    Physics.IgnoreCollision(collision.gameObject.,this.gameObject);
        //}
        //To do > fix that
        if ((collision.gameObject.name != "Wizard") && (collision.gameObject.tag == "Player")) {
            if (collision.gameObject.GetComponent<Player_info>().currentMana > 5)
            {
                collision.gameObject.GetComponent<Player_info>().currentMana -= 5;
                owner.GetComponent<Player_info>().currentMana += 3;
            }


            collision.gameObject.GetComponent<Player_info>().Hit(2500,2, !collision.gameObject.GetComponent<Player_info>().turnedLeft);
        }
    }   

}
