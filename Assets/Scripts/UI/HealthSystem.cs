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
        if (player != null) {
            HP.value = (player.GetComponent<Player_info>().currentLife) / 100;
            MP.value = (player.GetComponent<Player_info>().currentMana) / 100;
            Energy.value = (player.GetComponent<Player_info>().pressingMana) / 100;
            if (!player.active)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void FixedUpdate()
    {
        if (player == null) {
            Destroy(gameObject);
        }
    }
}
