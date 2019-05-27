using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    private float damage = 10f;
    public Animator animator;
    public Player_info owner;

    void Start()
    {
        animator = owner.gameObject.GetComponent<Animator>();
        float damage = owner.getPower;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Player_info somebody = other.gameObject.GetComponent<Player_info>();
        if (somebody != null && somebody != owner)
        {
			somebody.Hurt(damage,owner.turnedLeft);
        }
        //else {
        //    aux = 23;
        //}
    }
}
