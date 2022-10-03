using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    private GameController gameController;
    private ControlPlayer player;


    private GameObject menuOne;
    private GameObject menuTwo;
    public GameObject femaleMenuOne;
    public GameObject femaleMenuTwo;
    public GameObject maleMenuOne;
    public GameObject maleMenuTwo;
    public GameObject tutorialMenu;
    public TMPro.TextMeshProUGUI femaleText;
    public TMPro.TextMeshProUGUI maleText;
    private TMPro.TextMeshProUGUI tutText;

    private bool boolOne;
    private bool boolTwo;
    private bool boolThree;

    private bool doOnceOne;
    private bool doOnceTwo;
    private bool doOnceThree;

    private int textCounter;

    // Start is called before the first frame update
    void Start()
    {
        gameController = this.gameObject.GetComponent<GameController>();
        gameController.gameRunning = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayer>();
        player.canMove = false;
        boolOne = false;
        boolTwo = false;
        boolThree = false;
        doOnceOne = false;
        doOnceTwo = false;
        doOnceThree = false;
        femaleMenuOne.SetActive(false);
        femaleMenuTwo.SetActive(false);
        maleMenuOne.SetActive(false);
        maleMenuTwo.SetActive(false);
        maleText.gameObject.SetActive(false);
        femaleText.gameObject.SetActive(false);
        BeginTutorial();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BeginTutorial()
    {
        if (player.isFemale)
        {
            menuOne = maleMenuOne;
            menuTwo = maleMenuTwo;
            tutText = maleText;
            maleText.gameObject.SetActive(true);
        }
        else{
            menuOne = femaleMenuOne;
            menuTwo = femaleMenuTwo;
            tutText = femaleText;
            femaleText.gameObject.SetActive(true);
        }
        Debug.Log("Done");
        menuOne.SetActive(true);
        menuTwo.SetActive(false);
        textCounter = 0;
        FirstLine();
    }

    public void PlayNext()
    {
        Debug.Log(textCounter);
        if (textCounter == 0)
        {
            SecondLine();
        }
        else if (textCounter == 1)
        {
            ThirdLine();
        }
        else if (textCounter == 2)
        {
            StartGame();
        }
    }

    void FirstLine()
    {
        Debug.Log("Done");
        tutText.text = "Hey buddy, bad news.You're gonna be doing this shift alone. I know it feels like there's a customer every ten seconds but you have to fill those orders quickly or the line will go out the door. And if that happens, you're outta here.";

    }

    void SecondLine()
    {
        menuOne.SetActive(false);
        menuTwo.SetActive(true);
        tutText.text = "Get the customers orders from the register and then stop by each station to put their drink together. Hand it over to them at the register. If you screw up don't be surprised if they refuse to take it. Grab a new cup and try again";
        textCounter += 1;
    }

    void ThirdLine()
    {
        menuOne.SetActive(true);
        menuTwo.SetActive(false);
        tutText.text = "WASD/ZQSD/Arrow Keys to move and space to interact with the stations. Click on the drink you want to pour at each station";
        textCounter += 1;
    }

    void StartGame()
    {
        tutorialMenu.SetActive(false);
        gameController.StartGame();
        player.canMove = true;
    }

}
