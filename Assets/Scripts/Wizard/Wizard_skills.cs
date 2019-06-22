using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_skills : Special_Skills
{
    public GameObject fairyDust;
    public GameObject fairyMeteor;
    public GameObject fireball;
    public Transform fireballPosition;

    public GameObject effect1;
    public GameObject effect2;
    public GameObject effect3;

    public float timeAct2;

    public float timeact;
    public int aux;
    public override void Skill1() {
        GetComponent<Animator>().SetTrigger("tornado");
        effect1.SetActive(true);
        timeAct2 = Time.time;
        aux = 1;
        fairyDust.SetActive(true);
        fairyDust.transform.position = owner.transform.position;
    }
    public override void Skill2()
    {
        effect2.SetActive(true);
        timeAct2 = Time.time;
        GetComponent<Animator>().SetTrigger("tornado");
        Instantiate(fireball, fireballPosition);
    }
    public override void Skill3()
    {
        effect3.SetActive(true);
        timeAct2 = Time.time;
        GetComponent<Animator>().SetTrigger("tornado");
        timeact = Time.time;
        //Vector3 randompos;
        InvokeRepeating("CreateMeteor", 2.0f, 0.4f);
        //FairyMeteor.transform.position = new Vector3(1  ,1,1);

        //Instantiate(FairyMeteor, new Vector3(1,1,1));

    }
    public void CreateMeteor() {
        float randomx = Random.Range(-30f, 30f);
        Instantiate(fairyMeteor, new Vector3(randomx, 15f, 0f), Quaternion.identity);
        if (Time.time > timeact + 25f) {
            CancelInvoke("CreateMeteor");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAct2 + 1f < Time.time)
        {
            effect1.SetActive(false);
            effect2.SetActive(false);
            effect3.SetActive(false);
        }
    }
}
