using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    public Slider HP;
    public Slider MP;
    public Slider Energy;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HP.value = player.GetComponent<Player_info>().currentLife;
        MP.value = player.GetComponent<Player_info>().currentMana;
        Energy.value = player.GetComponent<Player_info>().pressingMana;
    }
}
