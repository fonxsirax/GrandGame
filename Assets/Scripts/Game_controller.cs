using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Game_controller : MonoBehaviour
{
    //public Player_info player1;
    //public Player_info player2;
    //public Player_info player3;
    //public Player_info player4;
    public int aux;
    public Sprite knightSprite;
    public Sprite NinjaSprite;
    
    public List<Player_info> Characteres = new List<Player_info>();
    //private GameObject referenceObject1;
    //private GameObject referenceObject2;
    //private GameObject referenceObject3;
    //private GameObject referenceObject4;

    public Image referenceObject1;
    public Image referenceObject2;
    public Image referenceObject3;
    public Image referenceObject4;
    public GameObject knight1;
    public GameObject knight2;
    public GameObject ninja1;
    public GameObject ninja2;

    public Text T1;
    public Text T2;
    public Text T3;
    public Text T4;

    public Character panel1;
    public Character panel2;
    public Character panel3;

    private bool done1 = false;
    private bool done2 = false;
    private bool done3 = false;

    // Start is called before the first frame update
    //void Awake() {

    //}
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "scne")
        {
            for (int i = 0; i < Characteres.Count; i++) {
                if (Characteres[i].number == 1)
                {
                    if (Characteres[i].name == "Knight")
                    {
                        if (knight1.active == false)
                        {
                            knight1.SetActive(true);
                            knight1.GetComponent<Player_info>().number = 1;
                        }
                        else
                        {
                            knight2.SetActive(true);
                            knight2.GetComponent<Player_info>().number = 1;
                        }
                    }
                    else if (Characteres[i].name == "Ninja")
                    {
                        if (ninja1.active == false)
                        {
                            ninja1.SetActive(true);
                            ninja1.GetComponent<Player_info>().number = 1;
                        }
                        else {
                            ninja2.SetActive(true);
                            ninja2.GetComponent<Player_info>().number = 1;
                        }
                    }
                }
                if (Characteres[i].number == 2)
                {
                    if (Characteres[i].name == "Knight")
                    {
                        if (!knight1.active)
                        {
                            knight1.SetActive(true);
                            knight1.GetComponent<Player_info>().number = 2;
                        }
                        else
                        {
                            knight2.SetActive(true);
                            knight2.GetComponent<Player_info>().number = 2;
                        }
                    }
                    else if (Characteres[i].name == "Ninja")
                    {
                        if (!ninja1.active)
                        {
                            ninja1.SetActive(true);
                            ninja1.GetComponent<Player_info>().number = 2;
                        }
                        else
                        {
                            ninja2.SetActive(true);
                            ninja2.GetComponent<Player_info>().number = 2;
                        }
                    }
                }
            }
            }

            //Resources.Load("Prefabs/Character 1") as GameObject;
        }
        //referenceObject1 = GameObject.FindWithTag("p1");
        //referenceObject2 = GameObject.FindWithTag("p2");
        //referenceObject3 = GameObject.FindWithTag("p3");
        //referenceObject4 = GameObject.FindWithTag("p4");

        //referenceText1 = GameObject.FindWithTag("T1");
        //referenceText2 = GameObject.FindWithTag("T2");
        //referenceText3 = GameObject.FindWithTag("T3");
        //referenceText4 = GameObject.FindWithTag("T4");

        //panel1 = GetComponent<Character>();
        //panel2 = GetComponent<Character>();
        //panel3 = GetComponent<Character>();
        //Player_info player1 = new Player_info();
        //player1.name = "Knight";
        //player1.number = 1;
        //player1.totaLife = 100;
        //player1.currentLife = 100;

        //Player_info player2 = new Player_info();
        //player2.name = "Ninja";
        //player2.number = 2;
        //player2.totaLife = 100;
        //player2.currentLife = 100;



        //Characteres.Add(player1);
        //Characteres.Add(player2);
        //referenceObject1.GetComponent<UnityEngine.UI.Image>().sprite = knightSprite;

        //FillCharacteresSprites();
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("enter") && Characteres.Count > 0)
        {
            LoadGame();
        }
        if ((SceneManager.GetActiveScene().name == "CharacterSelection") && (panel1.done) && (!done1)){
            Build(panel1.name,panel1.number);
            done1 = true;
        }
        if ((SceneManager.GetActiveScene().name == "CharacterSelection") && (panel2.done) && (!done2))
        {
            Build(panel2.name, panel2.number);
            done2 = true;
        }
        if ((SceneManager.GetActiveScene().name == "CharacterSelection") && (panel3.done) && (!done3))
        {
            Build(panel3.name, panel3.number);
            done3 = true;
        }
        //aux = Characteres[0].currentLife;
        if (Characteres.Count == 0 && (SceneManager.GetActiveScene().name == "scne"))
        {
            Application.LoadLevel("GameOver");
        }

        //mText.text = "99%";
        //UpdateHP();
    }
    public void Build(string name, int number) {
        Player_info player = new Player_info();
        player.name = name;
        player.number = number;
        player.totaLife = 100;
        player.currentLife = 100;
        Characteres.Add(player);
    }
    void LoadGame()
    {
        aux = 12;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("scne");

    }

    //void UpdateHP() {
    //    for (int i = 0; i < Characteres.Count; i++)
    //        if (i == 0)
    //        {
    //            T1.text = Characteres[i].currentLife.ToString() + " %";
    //        }
    //        else if (i == 1) {
    //            T2.text = Characteres[i].currentLife.ToString() + " %";
    //        }
    //}


    //void FillCharacteresSprites() {
    //    for (int i = 1; i < Characteres.Count+1; i++)
    //    {

    //        if (i == 1)
    //        {
    //            if (Characteres[0].name == "Knight")
    //            {

    //                referenceObject1.GetComponent<UnityEngine.UI.Image>().sprite = knightSprite;
    //            }
    //            else
    //            {
    //                referenceObject1.GetComponent<UnityEngine.UI.Image>().sprite = NinjaSprite;
    //            }
    //        }
    //        else if (i == 2)
    //        {
    //            if (Characteres[1].name == "Knight")
    //            {
    //                referenceObject2.GetComponent<UnityEngine.UI.Image>().sprite = knightSprite;
    //            }
    //            else
    //            {
    //                referenceObject2.GetComponent<UnityEngine.UI.Image>().sprite = NinjaSprite;
    //            }
    //        }
    //    }
    //}
}
