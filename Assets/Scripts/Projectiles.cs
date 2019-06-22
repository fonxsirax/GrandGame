using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectiles : MonoBehaviour
{
    public GameObject owner;
    protected Animator animator;
    public float speed;
    public bool left;
    public float timeAct = 0;
    public float lifeTime;
    // Start is called before the first frame update
    protected abstract void Awake();

    protected abstract void Start();

    // Update is called once per frame
    protected abstract void Update();

}
