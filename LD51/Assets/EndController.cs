using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{

    private GameObject player;
    public GameObject maleEnding;
    public GameObject femaleEnding;

    public GameObject coffeStation;
    public GameObject iceStation;
    public GameObject teaStation;
    public GameObject milkStation;
    public GameObject flavorStation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
           if (other.GetComponent<NPCNav>().orderComplete)
            {
                other.GetComponent<NPCNav>().AddToPool();
            }
            else
            {
                coffeStation.SetActive(false);
                teaStation.SetActive(false);
                iceStation.SetActive(false);
                flavorStation.SetActive(false);
                milkStation.SetActive(false);
                if (player.GetComponent<ControlPlayer>().isFemale)
                {
                    maleEnding.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    femaleEnding.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
    }
}
