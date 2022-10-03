using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private ControlPlayer player;
    private bool pauseToggle;
    public GameObject pauseMenu;
    private bool currentMove;
    public GameObject scoreScreen;

    public GameObject tutorialMenuController;
    public TMPro.TextMeshProUGUI scoreValue;

    private OrderController orderController;


    public GameObject femaleFail;
    public GameObject maleFail;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayer>();
        orderController = GameObject.FindGameObjectWithTag("OrderController").GetComponent<OrderController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorialMenuController.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                Debug.Log(currentMove);
                if (pauseToggle)
                {
                    pauseMenu.SetActive(false);
                    player.canMove = currentMove;
                }

                else
                {
                    pauseMenu.SetActive(true);
                    currentMove = player.canMove;
                    player.canMove = false;
                }


                pauseToggle = !pauseToggle;
            }
        }
    }

    public void ResumeGame()
    {



            if (pauseToggle)
            {
                pauseMenu.SetActive(false);
                player.canMove = currentMove;
            }

            else
            {
                pauseMenu.SetActive(true);
                currentMove = player.canMove;
                player.canMove = false;
            }


            pauseToggle = !pauseToggle;
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenScore()
    {
        maleFail.SetActive(false);
        femaleFail.SetActive(false);
        scoreValue.text = orderController.servedNPCs.ToString();
        scoreScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuSet()
    {
        SceneManager.LoadScene("Home");
    }

}
