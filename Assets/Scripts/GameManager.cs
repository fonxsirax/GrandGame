//using System.Collections;
//using UnityEngine;

//public class GameManager : MonoBehaviour
//{
//    public static GameManager GM;

//    public KeyCode jump { get; set; }
//    public KeyCode atk1 { get; set; }
//    public KeyCode atk2 { get; set; }
//    public KeyCode left { get; set; }
//    public KeyCode right { get; set; }

//    void Awake() {
//        if (GM == null)
//        {
//            DontDestroyOnLoad(gameObject);
//            GM = this;
//        }
//        else if (GM != this) {
//            Destroy(gameObject);
//        }
//        jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space");

//    }
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
