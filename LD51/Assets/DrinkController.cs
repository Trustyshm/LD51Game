using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkController : MonoBehaviour
{
    [Header("Coffees")]
    public bool hasLight;
    public float lightAmount;
    public bool hasMedium;
    public float mediumAmount;
    public bool hasDark;
    public float darkAmount;
    public bool hasWater;
    public float waterAmount;

    [Header("Teas")]
    public bool hasGreen;
    public bool hasChai;
    public bool hasBlack;

    [Header("Flavors")]
    public bool hasStraw;
    public int strawPumps;
    public bool hasFrench;
    public int frenchPumps;
    public bool hasPumpkin;
    public int pumpkinPumps;

    [Header("Milk")]
    public bool hasWhole;
    public float wholeAmount;
    public bool hasSkim;
    public float skimAmount;
    public bool hasAlmond;
    public float almondAmount;


    [Header("Ice")]
    public bool hasIce;

    [Header("GameObjects")]
    public GameObject theDrink;
    public GameObject theLiquid;
    public GameObject theTeabag;
    public GameObject theIce;
    public GameObject iceOne;
    public GameObject iceTwo;
    public GameObject iceThree;
    public GameObject iceFour;
    public GameObject iceFive;

    [Header("StartColor")]
    public Color startColor;

    [Header("TeaPourControllers")]
    public PourController teaOne;
    public PourController teaTwo;
    public PourController teaThree;

    public bool isEmpty;
    private bool doOnce;

    // Start is called before the first frame update
    void Start()
    {
        isEmpty = true;
        doOnce = false;
    }

    public void ResetDrink()
    {
        teaOne.gameObject.SetActive(true);
        teaOne.ResetTeas();
        teaOne.gameObject.SetActive(false);
        teaTwo.gameObject.SetActive(true);
        teaTwo.ResetTeas();
        teaTwo.gameObject.SetActive(false);
        teaThree.gameObject.SetActive(true);
        teaThree.ResetTeas();
        teaThree.gameObject.SetActive(false);
        doOnce = false;
        isEmpty = true;
        theLiquid.gameObject.GetComponent<Image>().color = startColor;
        LeanTween.scaleY(theLiquid, 0f, 0f);
        pumpkinPumps = 0;
        strawPumps = 0;
        frenchPumps = 0;
        hasLight = false;
        lightAmount = 0f;
        hasMedium = false;
        mediumAmount = 0f;
        hasDark = false;
        darkAmount = 0f;
        hasWater = false;
        waterAmount = 0f;
        hasGreen = false;
        hasChai = false;
        hasBlack = false;
        hasStraw = false;
        hasFrench = false;
        hasPumpkin = false;
        hasWhole = false;
        wholeAmount = 0f;
        hasAlmond = false;
        almondAmount = 0f;
        hasSkim = false;
        skimAmount = 0f;
        hasIce = false;
        theTeabag.SetActive(false);
        Debug.Log("This Happened");
        iceOne.SetActive(false);
        iceTwo.SetActive(false);
        iceThree.SetActive(false);
        iceFour.SetActive(false);
        iceFive.SetActive(false);
        theIce.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((hasAlmond || hasWhole || hasSkim || hasDark || hasMedium || hasLight || hasWater || hasChai || hasBlack || hasGreen || hasIce) && !doOnce)
        {
            doOnce = true;
            isEmpty = false;
        }
    }
}
