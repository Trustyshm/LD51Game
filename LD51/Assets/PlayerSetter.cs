using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetter : MonoBehaviour
{
    private CharacterMaker characterMaker;
    public GameObject femalePlayer;
    public GameObject malePlayer;

    private string savedString;


    void Awake()
    {
        characterMaker = GameObject.FindGameObjectWithTag("PSave").GetComponent<CharacterMaker>();
        if (characterMaker.isFemale)
        {
            malePlayer.SetActive(false);
            femalePlayer.SetActive(true);
        }
        else
        {
            femalePlayer.SetActive(false);
            malePlayer.SetActive(true);
        }
        savedString = characterMaker.savedName;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveName()
    {
        savedString = characterMaker.savedName; 
    }

}
