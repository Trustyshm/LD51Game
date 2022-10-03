using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNav : MonoBehaviour
{
    public NPCNav followedNPC;
    public NPCNav followingNPC;

    public Transform followSpot;

    private Transform registerSpot;
    private Transform nextToRegister;
    private Transform leaveStore;

    private Transform targetSpot;
    private Transform recievedSpot;
    private bool followingOther;

    private NavMeshAgent agent;
    private Animator anim;
    private bool setRegister = false;
    private bool setNext = false;
    public bool orderComplete;

    private OrderController orderController;
    private GameController gameController;

    public bool isFemale;

    private bool isRegistered;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameCont").GetComponent<GameController>();
        registerSpot = GameObject.FindGameObjectWithTag("RegisterSpot").transform;
        nextToRegister = GameObject.FindGameObjectWithTag("NextRegister").transform;
        leaveStore = GameObject.FindGameObjectWithTag("LeaveSpot").transform;
        orderController = GameObject.FindGameObjectWithTag("OrderController").GetComponent<OrderController>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetRegister()
    {
        if (followedNPC != null)
        {
            targetSpot = followedNPC.followSpot.transform;
            followingOther = true;
        }
        else
        {
            setRegister = true;
            followingOther = false;
            targetSpot = registerSpot;
        }
        
    }

    public void SetNext()
    {
        if (followingNPC != null)
        {
            followingNPC.followedNPC = null;
            followingNPC.SetRegister();
        }
        
        setRegister = false;
        setNext = true;
        followingOther = false;
        targetSpot = nextToRegister;
    }

    public void SetLeave()
    {
        followingOther = false;
        targetSpot = leaveStore;
        isRegistered = false;
    }

    public void SetOther(Transform recievedTarget)
    {
        if (recievedSpot == null)
        {
            recievedSpot = recievedTarget;
            targetSpot = recievedTarget;
        }
        else
        {
            targetSpot = recievedSpot;
        }
        
    }

    public void AddToPool()
    {
        if (isFemale)
        {
            gameController.poolDictionary["Female"].Enqueue(this.gameObject);
            this.transform.SetParent(null);
            this.gameObject.SetActive(false);
        }
        else
        {
            gameController.poolDictionary["Male"].Enqueue(this.gameObject);
            this.transform.SetParent(null);
            this.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
      //  if (followingOther)
      //  {
        //    SetOther(recievedSpot);
       // }

        if (Vector3.Distance(this.transform.position, targetSpot.position) < 0.3)
        {
            anim.SetBool("isWalking", false);
            if (followingOther || setRegister)
            {
                transform.rotation = targetSpot.transform.rotation;
                if (!isRegistered && setRegister)
                {
                    isRegistered = true;
                    RegisterNPC();
                }
            }
            
            if (setNext)
            {
                SetLeave();
            }
        }
        else
        {
            anim.SetBool("isWalking", true);
            agent.SetDestination(targetSpot.position);
        }

        if (setRegister && orderComplete)
        {
            SetNext();
        }

        if (followedNPC = null)
        {
            SetRegister();
        }

    }

    private void RegisterNPC()
    {
        orderController.MyRegisteredNPC(this.GetComponent<NPCNav>());
    }
}
