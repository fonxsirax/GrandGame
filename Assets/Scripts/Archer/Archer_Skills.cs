using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_Skills : Special_Skills
{
    public GameObject arrow;
    public float timeskill2;
    public float timeskill3;
    public float timeEffect;

    public GameObject effect2;
    public GameObject effect3;

    public GameObject trap;
    
    // Start is called before the first frame update
    public override void Skill1()
    {
        trap.SetActive(true);
        Instantiate(trap, trap.transform.position, trap.transform.rotation);
        trap.SetActive(false);
    }
    public override void Skill2()
    {
        timeskill2 = Time.time;
        arrow.GetComponent<Arrow>().slow = true;
        arrow.GetComponent<SpriteRenderer>().color = Color.blue;
        timeEffect = Time.time;
        effect2.SetActive(true);
    }
    public override void Skill3()
    {
        timeskill3 = Time.time;
        arrow.GetComponent<Arrow>().poison = true;
        arrow.GetComponent<SpriteRenderer>().color = Color.green;
        timeEffect = Time.time;
        effect3.SetActive(true);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeskill2 + 25f < Time.time) {
            arrow.GetComponent<Arrow>().slow = false;

        }
        if (timeskill3 + 40f < Time.time) {
            arrow.GetComponent<Arrow>().poison = false;

        }
        if (timeEffect + 2f < Time.time) {
            effect2.SetActive(false);
            effect3.SetActive(false);
        }
        if ((arrow.GetComponent<Arrow>().poison == false) && (arrow.GetComponent<Arrow>().slow == false)) {
            Color tmp = arrow.gameObject.GetComponent<SpriteRenderer>().color;
            tmp.r = 255;
            tmp.g = 255;
            tmp.b = 255;
            tmp.a = 255;
            arrow.GetComponent<SpriteRenderer>().color = tmp;
        }
        
    }
}
