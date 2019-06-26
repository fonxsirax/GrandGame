using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControl : MonoBehaviour
{
    public int aux = 0;

    public List<string> Characteres = new List<string>();

    public GameObject panelGameover;
    public GameObject panelStartGame;
    public GameObject imageWinner;

    public Sprite wizardSprite;
    public Sprite warriorSprite;
    public Sprite ninjaSprite;
    public Sprite archerSprite;

    // Start is called before the first frame update
    private void Awake()
    {

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
            panelGameover.SetActive(true);
            switch (Characteres[0]) {
                case "Warrior":
                    imageWinner.GetComponent<Image>().sprite = warriorSprite;
                    break;
                case "Ninja":
                    imageWinner.GetComponent<Image>().sprite = ninjaSprite;
                    break;
                case "Wizard":
                    imageWinner.GetComponent<Image>().sprite = wizardSprite;
                    break;
                case "Archer":
                    imageWinner.GetComponent<Image>().sprite = archerSprite;
                    break;
            }
            Characteres.RemoveAt(0);
        }
        
    }
    public void RemoveChar(string name)
    {
        Characteres.Remove(name);
    }

    public void LoadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
