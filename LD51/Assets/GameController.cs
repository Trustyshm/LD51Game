using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;

    public Transform spawnSpot;
    public GameObject malePlayer;
    public GameObject femalePlayer;

    public GameObject npcController;

    public float gameTimer;
    public bool gameRunning = false;
    private float savedTime;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private int spawnedNPCs;
    private NPCNav previousNPC;

    // Start is called before the first frame update
    void Start()
    {
        spawnedNPCs = 0;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject npc = Instantiate(pool.prefab);
                npc.SetActive(false);
                objectPool.Enqueue(npc);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public void SpawnNPC()
    {
        int selectedPool = Random.Range(0, 2);
        switch (selectedPool) {
            case 0:
                GameObject npcToSpawn = poolDictionary["Male"].Dequeue();
                npcToSpawn.SetActive(true);
                npcToSpawn.transform.SetParent(npcController.transform);
                npcToSpawn.transform.position = spawnSpot.position;
                npcToSpawn.transform.rotation = spawnSpot.rotation;
                if (spawnedNPCs == 0)
                {
                    npcToSpawn.GetComponent<NPCNav>().followedNPC = null;
                    npcToSpawn.GetComponent<NPCNav>().SetRegister();
                    previousNPC = npcToSpawn.GetComponent<NPCNav>();
                    spawnedNPCs += 1;
                }
                else
                {
                    
                    if (previousNPC.GetComponent<NPCNav>().orderComplete == true)
                    {
                        
                        npcToSpawn.GetComponent<NPCNav>().followedNPC = null;
                    }
                    else
                    {
                        previousNPC.followingNPC = npcToSpawn.GetComponent<NPCNav>();
                        npcToSpawn.GetComponent<NPCNav>().followedNPC = previousNPC;
                    }
                   
                    npcToSpawn.GetComponent<NPCNav>().SetRegister();
                    previousNPC = npcToSpawn.GetComponent<NPCNav>();
                    spawnedNPCs += 1;
                }
                break;
            case 1:
                GameObject fnpcToSpawn = poolDictionary["Female"].Dequeue();
                fnpcToSpawn.SetActive(true);
                fnpcToSpawn.transform.SetParent(npcController.transform);
                fnpcToSpawn.transform.position = spawnSpot.position;
                fnpcToSpawn.transform.rotation = spawnSpot.rotation;
                if (spawnedNPCs == 0)
                {
                    fnpcToSpawn.GetComponent<NPCNav>().followedNPC = null;
                    fnpcToSpawn.GetComponent<NPCNav>().SetRegister();
                    previousNPC = fnpcToSpawn.GetComponent<NPCNav>();
                    spawnedNPCs += 1;
                }
                else
                {
                    if (previousNPC.GetComponent<NPCNav>().orderComplete == true)
                    {

                        fnpcToSpawn.GetComponent<NPCNav>().followedNPC = null;
                    }
                    else
                    {
                        previousNPC.followingNPC = fnpcToSpawn.GetComponent<NPCNav>();
                        fnpcToSpawn.GetComponent<NPCNav>().followedNPC = previousNPC;
                    }

                    fnpcToSpawn.GetComponent<NPCNav>().SetRegister();
                    previousNPC = fnpcToSpawn.GetComponent<NPCNav>();
                    spawnedNPCs += 1;
                }
                break;
            default:
                GameObject afnpcToSpawn = poolDictionary["Female"].Dequeue();
                afnpcToSpawn.SetActive(true);
                afnpcToSpawn.transform.SetParent(npcController.transform);
                afnpcToSpawn.transform.position = spawnSpot.position;
                afnpcToSpawn.transform.rotation = spawnSpot.rotation;
                if (spawnedNPCs == 0)
                {
                    afnpcToSpawn.GetComponent<NPCNav>().followedNPC = null;
                    afnpcToSpawn.GetComponent<NPCNav>().SetRegister();
                    previousNPC = afnpcToSpawn.GetComponent<NPCNav>();
                    spawnedNPCs += 1;
                }
                else
                {
                    if (previousNPC.GetComponent<NPCNav>().orderComplete == true)
                    {

                        afnpcToSpawn.GetComponent<NPCNav>().followedNPC = null;
                    }
                    else
                    {
                        previousNPC.followingNPC = afnpcToSpawn.GetComponent<NPCNav>();
                        afnpcToSpawn.GetComponent<NPCNav>().followedNPC = previousNPC;
                    }

                    afnpcToSpawn.GetComponent<NPCNav>().SetRegister();
                    previousNPC = afnpcToSpawn.GetComponent<NPCNav>();
                    spawnedNPCs += 1;
                }
                break;
        }
    }

    public void SetInactive()
    {
        gameRunning = false;
    }

    public void ResetGame()
    {
        gameTimer = 0f;
        spawnedNPCs = 0;
    }

    public void StartGame()
    {
        SpawnNPC();
        savedTime = 0f;
        gameRunning = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
        {
            gameTimer += Time.deltaTime;
        }

        if(gameTimer >= savedTime + 10f)
        {
            savedTime = gameTimer;
            SpawnNPC();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
