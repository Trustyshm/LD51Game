using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlPlayer : MonoBehaviour
{

    PlayerMovement playerMovement;
    CharacterController characterController;
    Animator anim;

    public GameObject theHandCup;

    public float movementSpeed = 2f;
    public float runningSpeed = 3f;
    private Vector2 currentMoveInput;
    private Vector3 runMovement;
    private Vector3 movementDirection;
    public float rotationSpeed = 15f;

    private bool isMovingPressed;
    private bool isRunPressed;
    private bool isInteractPressed;
    public bool canMove;

    private int isWalkingHash;
    private int isRunningHash;

    public float raycastRange = 1f;
    public GameObject rayOrigin;
    private GameObject hitObject;

    public GameObject coffeeUI;
    public GameObject teaUI;
    public GameObject flavorUI;
    public GameObject milkUI;
    public GameObject iceUI;
    public GameObject uiBlur;

    public GameObject theCup;

    public bool hasOrder;

    private OrderController orderController;
    private DrinkController drinkController;
    private GameController gameController;

    public GameObject coffeeIUI;
    public GameObject flavorIUI;
    public GameObject milkIUI;
    public GameObject iceIUI;
    public GameObject teaIUI;

    public bool isFemale;

    public AudioSource soundEffects;
    public AudioClip registerSound;
    public AudioClip cupSound;

    public bool isImpossible;

    void Awake()
    {
        playerMovement = new PlayerMovement();
        characterController = GetComponent<CharacterController>();
        orderController = GameObject.FindGameObjectWithTag("OrderController").GetComponent<OrderController>();
        drinkController = GameObject.FindGameObjectWithTag("DrinkController").GetComponent<DrinkController>();
        gameController = GameObject.FindGameObjectWithTag("GameCont").GetComponent<GameController>();
        anim = GetComponent<Animator>();
        canMove = true;
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");


        playerMovement.PlayerControls.Movement.started += onMoveInput;
        playerMovement.PlayerControls.Movement.canceled += onMoveInput;
        playerMovement.PlayerControls.Movement.performed += onMoveInput;

        playerMovement.PlayerControls.Run.started += onRun;
        playerMovement.PlayerControls.Run.canceled += onRun;

        playerMovement.PlayerControls.Use.started += onInteracted;
        playerMovement.PlayerControls.Use.canceled += onInteracted;
    }

    void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    void onInteracted(InputAction.CallbackContext context)
    {
        isInteractPressed = context.ReadValueAsButton();
    }

    void onMoveInput (InputAction.CallbackContext context)
    {
        currentMoveInput = context.ReadValue<Vector2>();
        movementDirection.x = currentMoveInput.x;
        movementDirection.z = currentMoveInput.y;
        runMovement.x = currentMoveInput.x * runningSpeed;
        runMovement.z = currentMoveInput.y * runningSpeed;
        isMovingPressed = currentMoveInput.x != 0 || currentMoveInput.y != 0;
    }

    void doRotation()
    {
        Vector3 lookAtPosition;
        lookAtPosition.x = movementDirection.x;
        lookAtPosition.y = 0.0f;
        lookAtPosition.z = movementDirection.z;

        Quaternion currentRotation = transform.rotation;

        if (isMovingPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookAtPosition);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

    }

    void doAnimation()
    {
        bool isWalking = anim.GetBool("isWalking");
        bool isRunning = anim.GetBool("isRunning");

        if (isMovingPressed && !isWalking)
        {
            anim.SetBool("isWalking", true);
        }
        else if (!isMovingPressed && isWalking)
        {
            anim.SetBool("isWalking", false);
        }

        if ((isMovingPressed && isRunPressed) && !isRunning)
        {
            anim.SetBool("isRunning", true);
        } else if ((!isMovingPressed || !isRunPressed) && isRunning)
        {
            anim.SetBool("isRunning", false);
        }

    }

    void doRaycast()
    {
        

        RaycastHit hit;
        if (Physics.SphereCast(rayOrigin.transform.position, .2f, this.transform.forward, out hit, 0.5f))
        {

            if (hit.transform.gameObject.CompareTag("CoffeeStation"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hitObject = hit.transform.gameObject;
                if (isInteractPressed)
                {
                    anim.SetBool("isWalking", false);
                    coffeeUI.SetActive(true);
                    coffeeIUI.SetActive(false);
                    canMove = false;
                    uiBlur.SetActive(true);
                    theCup.SetActive(true);
                }
            }
            if (hit.transform.gameObject.CompareTag("FlavorStation"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hitObject = hit.transform.gameObject;
                if (isInteractPressed)
                {
                    anim.SetBool("isWalking", false);
                    flavorUI.SetActive(true);
                    flavorIUI.SetActive(false);
                    canMove = false;
                    uiBlur.SetActive(true);
                    theCup.SetActive(true);
                }
            }
            if (hit.transform.gameObject.CompareTag("TeaStation"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hitObject = hit.transform.gameObject;
                if (isInteractPressed)
                {
                    anim.SetBool("isWalking", false);
                    teaUI.SetActive(true);
                    teaIUI.SetActive(false);
                    canMove = false;
                    uiBlur.SetActive(true);
                    theCup.SetActive(true);
                }
            }
            if (hit.transform.gameObject.CompareTag("MilkStation"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hitObject = hit.transform.gameObject;
                if (isInteractPressed)
                {
                    anim.SetBool("isWalking", false);
                    milkUI.SetActive(true);
                    milkIUI.SetActive(false);
                    canMove = false;
                    uiBlur.SetActive(true);
                    theCup.SetActive(true);
                }
            }
            if (hit.transform.gameObject.CompareTag("IceStation"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hitObject = hit.transform.gameObject;
                if (isInteractPressed)
                {
                    anim.SetBool("isWalking", false);
                    iceUI.SetActive(true);
                    iceIUI.SetActive(false);
                    canMove = false;
                    uiBlur.SetActive(true);
                    theCup.SetActive(true);
                }
            }
            if (hit.transform.gameObject.CompareTag("RegisterStation"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hitObject = hit.transform.gameObject;
                if (isInteractPressed)
                {
                    soundEffects.clip = registerSound;
                    soundEffects.Play();
                    //Check if npc waiting
                    if (!hasOrder && orderController.registeredNPC != null)
                    {
                        hasOrder = true;
                        orderController.CreateOrder();
                    }
                    else if (hasOrder && !drinkController.isEmpty)
                    {
                        Debug.Log("Oops");
                        orderController.CheckOrder();
                    }
                    else
                    {
                        //Do Nothing
                    }
                }
            }
            if (hit.transform.gameObject.CompareTag("TheCups"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hitObject = hit.transform.gameObject;
                if (isInteractPressed)
                {
                    soundEffects.clip = cupSound;
                    soundEffects.Play();
                    drinkController.ResetDrink();
                }
            }
        }
        else 
        {
           if (hitObject != null)
           {
                hitObject.transform.GetChild(0).gameObject.SetActive(false);
                hitObject = null;
            }
               
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (!isImpossible)
            {
                gameController.gameRunning = true;
            }
            doRotation();
            doAnimation();

            if (isRunPressed)
            {
                characterController.Move(runMovement * Time.deltaTime);
            }
            else
            {
                characterController.Move(movementDirection * movementSpeed * Time.deltaTime);
            }

            doRaycast();
        }
        else
        {
            if (!isImpossible)
            {
                gameController.gameRunning = false;
            }
            
        }
        if (hasOrder)
        {
            theHandCup.SetActive(true);
            anim.SetBool("HasCup", true);
        }
        if (!hasOrder)
        {
            theHandCup.SetActive(false);
            anim.SetBool("HasCup", false);
        }
    }

    void LateUpdate()
    {
        if (canMove)
        {
            doRaycast();
        }
        
    }


    void OnEnable()
    {
        playerMovement.PlayerControls.Enable();
    }

    void OnDisable()
    {
        playerMovement.PlayerControls.Disable(); 
    }
}
