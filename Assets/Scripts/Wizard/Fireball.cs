using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Fireball : MonoBehaviour {

    public GameObject fieryEffect;
    public GameObject smokeEffect;
    public GameObject explodeEffect;

    protected Rigidbody2D rgbd;

    public void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {

    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        rgbd.Sleep();
        StopParticleSystem(fieryEffect);
        StopParticleSystem(smokeEffect);
        explodeEffect.SetActive(true);
        Destroy(gameObject, 0.5f);

        if ((col.gameObject.name != "Wizard") && (col.gameObject.tag == "Player")) {
            col.gameObject.GetComponent<Player_info>().Hurt(20, col.gameObject.GetComponent<Player_info>().turnedLeft,"Wizard");
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if((other.gameObject.name != "Wizard") && (other.gameObject.tag == "Player")) {
            other.gameObject.GetComponent<Player_info>().Hurt(1, other.gameObject.GetComponent<Player_info>().turnedLeft,"Wizard");
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(50,10),ForceMode2D.Force);
        }
        //ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);

        //for (int i = 0; i < collisionEvents.Count; i++)
        //{
        //    splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
        //    EmitAtLocation(collisionEvents[i]);
        //}

    }


    public void StopParticleSystem(GameObject g)
    {
        ParticleSystem[] par;
        par = g.GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem p in par)
        {
            p.Stop();
        }
    }

    public void OnEnable()
    {
        fieryEffect.SetActive(true);
        smokeEffect.SetActive(true);
        explodeEffect.SetActive(false);
    }
}


