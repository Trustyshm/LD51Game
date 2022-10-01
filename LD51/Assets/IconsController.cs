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

    public ControlPlayer playerControls;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (fourthIcon != null)
        {
            fourthIcon.SetActive(false);
        }

        oneBig.SetActive(true);
    }

    public void ClickedTwo()
    {
        firstIcon.SetActive(false);
        secondIcon.SetActive(false);
        thirdIcon.SetActive(false);
        if (fourthIcon != null)
        {
            fourthIcon.SetActive(false);
        }

        twoBig.SetActive(true);
    }
    public void ClickedThree()
    {
        firstIcon.SetActive(false);
        secondIcon.SetActive(false);
        thirdIcon.SetActive(false);
        if (fourthIcon != null)
        {
            fourthIcon.SetActive(false);
        }

        threeBig.SetActive(true);
    }
    public void ClickedFour()
    {
        firstIcon.SetActive(false);
        secondIcon.SetActive(false);
        thirdIcon.SetActive(false);
        fourthIcon.SetActive(false);

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

        oneBig.SetActive(false);
        twoBig.SetActive(false);
        threeBig.SetActive(false);
        if (fourBig != null)
        {
            fourBig.SetActive(false);
        }
    }

    public void FinishedPouring()
    {
        ResetButtons();
        uiBlur.gameObject.SetActive(false);
        playerControls.canMove = true;
        this.gameObject.SetActive(false);

    }

}
