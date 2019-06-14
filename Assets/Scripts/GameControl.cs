using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public int aux = 0;

    public List<string> Characteres = new List<string>();

    // Start is called before the first frame update
    private void Awake()
    {
        if (player1 != null)
        {
            Characteres.Add(player1.GetComponent<Player_info>().name);
        }
        if (player2 != null)
        {
            Characteres.Add(player2.GetComponent<Player_info>().name);
        }
        if (player3 != null)
        {
            Characteres.Add(player3.GetComponent<Player_info>().name);
        }
    }
    void Start()
    {

       // Characteres.Add(player1);
       // Characteres.Add(player2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Characteres.Count == 1) {
            aux = 19;
        }
        
    }
    public void RemoveChar(string name)
    {
        Characteres.Remove(name);
    }
}
