using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlPlayer : MonoBehaviour
{

    PlayerMovement playerMovement;
    CharacterController characterController;
    Animator anim;

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
    public GameObject uiBlur;



    void Awake()
    {
        playerMovement = new PlayerMovement();
        characterController = GetComponent<CharacterController>();
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
        bool isWalking = anim.GetBool(isWalkingHash);
        bool isRunning = anim.GetBool(isRunningHash);

        if (isMovingPressed && !isWalking)
        {
            anim.SetBool(isWalkingHash, true);
        }
        else if (!isMovingPressed && isWalking)
        {
            anim.SetBool(isWalkingHash, false);
        }

        if ((isMovingPressed && isRunPressed) && !isRunning)
        {
            anim.SetBool(isRunningHash, true);
        } else if ((!isMovingPressed || !isRunPressed) && isRunning)
        {
            anim.SetBool(isRunningHash, false);
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
                    coffeeUI.SetActive(true);
                    canMove = false;
                    uiBlur.SetActive(true);
                }
            }
            if (hit.transform.gameObject.CompareTag("FlavorStation"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hitObject = hit.transform.gameObject;
                if (isInteractPressed)
                {
                    flavorUI.SetActive(true);
                    canMove = false;
                    uiBlur.SetActive(true);
                }
            }
            if (hit.transform.gameObject.CompareTag("TeaStation"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hitObject = hit.transform.gameObject;
                if (isInteractPressed)
                {
                    teaUI.SetActive(true);
                    canMove = false;
                    uiBlur.SetActive(true);
                }
            }
            if (hit.transform.gameObject.CompareTag("MilkStation"))
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hitObject = hit.transform.gameObject;
                if (isInteractPressed)
                {
                    milkUI.SetActive(true);
                    canMove = false;
                    uiBlur.SetActive(true);
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
