using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMaker : MonoBehaviour
{

    public GameObject femalePlayer;
    public GameObject malePlayer;

    private GameObject activePlayer;

    public bool isFemale;

    public TMPro.TextMeshProUGUI enteredName;
    public string savedName;



    // Start is called before the first frame update
    void Start()
    {
        isFemale = true;
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangedActiveScene(Scene current, Scene next)
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        if (scene.name == "Home")
        {
            GameObject playerSelect = GameObject.FindGameObjectWithTag("PSave");
            Destroy(playerSelect);
        }
    }

    public void SetMale()
    {
        femalePlayer.SetActive(false);
        malePlayer.SetActive(true);
        activePlayer = malePlayer;
        isFemale = false;
    }

    public void SetFemale()
    {
        femalePlayer.SetActive(true);
        malePlayer.SetActive(false);
        activePlayer = femalePlayer;
        isFemale = true;
    }

    public void EnterGame()
    {
        savedName = enteredName.text;
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("GameScene");
    }

    public void StartImpossible()
    {
        savedName = enteredName.text;
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("Impossible");
    }

}
