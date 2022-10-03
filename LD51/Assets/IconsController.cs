using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsController : MonoBehaviour
{

    public GameObject firstIcon;
    public GameObject secondIcon;
    public GameObject thirdIcon;
    public GameObject fourthIcon;

    public GameObject oneBig;
    public GameObject twoBig;
    public GameObject threeBig;
    public GameObject fourBig;
    public GameObject uiBlur;
    public GameObject replaceButton;
    public GameObject theCup;
    public GameObject teaRack;

    public bool isTeas;

    public bool isIce;

    public GameObject exitButton;

    private bool doOnce;




    private ControlPlayer playerControls;

    // Start is called before the first frame update
    void Start()
    {
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayer>();
    }

    private void OnEnable()
    {
        doOnce = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickedOne()
    {
        firstIcon.SetActive(false);
        secondIcon.SetActive(false);
        thirdIcon.SetActive(false);
        replaceButton.SetActive(true);
        if (fourthIcon != null)
        {
            fourthIcon.SetActive(false);
        }
        if (isTeas)
        {
            teaRack.SetActive(false);
        }

        oneBig.SetActive(true);
    }

    public void ClickedTwo()
    {
        firstIcon.SetActive(false);
        secondIcon.SetActive(false);
        thirdIcon.SetActive(false);
        replaceButton.SetActive(true);
        if (fourthIcon != null)
        {
            fourthIcon.SetActive(false);
        }
        if (isTeas)
        {
            teaRack.SetActive(false);
        }
        twoBig.SetActive(true);
    }
    public void ClickedThree()
    {
        firstIcon.SetActive(false);
        secondIcon.SetActive(false);
        replaceButton.SetActive(true);
        thirdIcon.SetActive(false);
        if (fourthIcon != null)
        {
            fourthIcon.SetActive(false);
        }
        if (isTeas)
        {
            teaRack.SetActive(false);
        }
        threeBig.SetActive(true);
    }
    public void ClickedFour()
    {
        firstIcon.SetActive(false);
        secondIcon.SetActive(false);
        thirdIcon.SetActive(false);
        fourthIcon.SetActive(false);
        replaceButton.SetActive(true);
        fourBig.SetActive(true);
    }

    public void ResetButtons()
    {
        firstIcon.SetActive(true);
        secondIcon.SetActive(true);
        thirdIcon.SetActive(true);
        if (fourthIcon != null)
        {
            fourthIcon.SetActive(true);
        }
        replaceButton.SetActive(false);
        oneBig.SetActive(false);
        twoBig.SetActive(false);
        threeBig.SetActive(false);
        if (isTeas)
        {
            teaRack.SetActive(true);
            replaceButton.SetActive(true);
        }
        if (fourBig != null)
        {
            fourBig.SetActive(false);
        }
    }

    public void FinishedPouring()
    {
        
        if (!isIce)
        {
            ResetButtons();
        }
        theCup.SetActive(false);
        uiBlur.gameObject.SetActive(false);
        playerControls.canMove = true;
        Debug.Log("ran exit code");
        this.gameObject.SetActive(false);
        
    }

}
