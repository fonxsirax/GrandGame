using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Skills : Special_Skills
{
    public GameObject effect1;
    //public GameObject effect2;
    public GameObject effect3;

    public GameObject skill1;
    public GameObject skill2;

    private float timeSkill =0;
    private float timeSkill3 = float.MaxValue;
    private float timeSkill2;
    public GameObject dragon;
    public override void Skill1()
    {
        timeSkill = Time.time;
        owner.GetComponent<Animator>().SetBool("strike", true);
        effect1.SetActive(true);
        skill1.SetActive(true);
    }
    public override void Skill2()
    {
        timeSkill2 = Time.time;
        owner.GetComponent<Animator>().SetBool("block", true);
        skill2.SetActive(true);

    }
    public override void Skill3()
    {
        timeSkill3 = Time.time;
        owner.GetComponent<Animator>().SetTrigger("win");
        effect3.SetActive(true);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeSkill + 8f < Time.time) {
            skill1.SetActive(false);
            effect1.SetActive(false);
            owner.GetComponent<Animator>().SetBool("strike", false);
        } //when skill turn off


        if (timeSkill3 + 1f < Time.time)
        {
            effect3.SetActive(false);
            dragon.SetActive(true);
            dragon.GetComponent<Player_info>().currentLife  = owner.GetComponent<Player_info>().currentLife;
            dragon.GetComponent<Player_info>().number = owner.GetComponent<Player_info>().number;
            dragon.GetComponent<Player_info>().currentMana = 0;
            dragon.GetComponent<Player_info>().manaspeed = 0;
            dragon.gameObject.transform.position = this.gameObject.transform.position;
            gameObject.SetActive(false);
        }

        if (timeSkill2 + 10f < Time.time) {
            owner.GetComponent<Animator>().SetBool("block", false);
            //owner.GetComponent<Player_info>().Invulnerable(false);
            skill2.SetActive(false);
        }
    }
}
