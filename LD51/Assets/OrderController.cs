using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderController : MonoBehaviour
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

    [Header("Order Type")]
    public int orderType; //0 =Coffee Order, 1 =Tea Order, 2 =Milk Order
    public int orderDifficulty; //0 =Easy, 1 =Medium, 2 =Hard
    public int orderNumber;


    [Header("Made Drink")]
    public DrinkController madeDrink;

    [Header("UI Elements")]
    public TMPro.TextMeshProUGUI orderText;
    public TMPro.TextMeshProUGUI resultText;

    public NPCNav registeredNPC;
    public bool orderActive;
    private ControlPlayer thePlayer;
    private DrinkController drinkController;
    private GameController gameController;

    public AudioSource voicesSource;
    public List<AudioClip> badClipsM = new List<AudioClip>();
    public List<AudioClip> doneClipsM = new List<AudioClip>();

    public List<AudioClip> badClipsF = new List<AudioClip>();
    public List<AudioClip> doneClipsF = new List<AudioClip>();

    public int servedNPCs;

    // Start is called before the first frame update
    void Start()
    {
        servedNPCs = 0;
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlPlayer>();
        gameController = GameObject.FindGameObjectWithTag("GameCont").GetComponent<GameController>();
        drinkController = GameObject.FindGameObjectWithTag("DrinkController").GetComponent<DrinkController>();
        orderText.text = "";
        LeanTween.scale(resultText.gameObject, Vector3.zero, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MyRegisteredNPC(NPCNav npcNav)
    {
        registeredNPC = npcNav;
    }

    public void DeRegisterNPC()
    {
        registeredNPC = null;
    }

    public void CreateEasyOrder()
    {
        ClearValues();
        resultText.text = "";
        orderText.text = "";
        orderType = Random.Range(0, 3);
        Debug.Log(orderType);
        if (orderType == 0) //Create Coffee Drink
        {
            orderNumber = Random.Range(0, 4);
            if (orderNumber == 0)
            {
                hasDark = true;
                orderText.text = "Dark Roast Coffee";
                darkAmount = 1f;
            }
            else if (orderNumber == 1)
            {
                hasMedium = true;
                orderText.text = "Medium Roast Coffee";
                mediumAmount = 1f;
            }
            else
            {
                hasLight = true;
                lightAmount = 1f;
                orderText.text = "Light Roast Coffee";
            }
        }
        if (orderType == 1) //Create Tea Drink
        {
            orderNumber = Random.Range(0, 4);
            if (orderNumber == 0)
            {
                hasChai = true;
                hasWater = true;
                waterAmount = 1f;
                orderText.text = "Chai Tea";
            }
            else if (orderNumber == 1)
            {
                hasBlack = true;
                hasWater = true;
                waterAmount = 1f;
                orderText.text = "Black Tea";
            }
            else
            {
                hasGreen = true;
                hasWater = true;
                waterAmount = 1f;
                orderText.text = "Green Tea";
            }
        }
        if (orderType == 2) //Create Milk Drink
        {
            orderNumber = Random.Range(0, 4);
            if (orderNumber == 0)
            {
                hasWhole = true;
                wholeAmount = 1f;
                orderText.text = "Whole Milk";
            }
            else if (orderNumber == 1)
            {
                hasSkim = true;
                skimAmount = 1f;
                orderText.text = "Skim Milk";
            }
            else
            {
                hasAlmond = true;
                almondAmount = 1f;
                orderText.text = "Almond Milk";
            }
        }
    }

    public void CreateMediumOrder()
    {
        orderText.text = "";
        orderType = Random.Range(0, 3);
        Debug.Log(orderType);
        if (orderType == 0) //Create Coffee Drink
        {
            orderNumber = Random.Range(0, 3);
            if (orderNumber == 0)
            {
                hasDark = true;
                orderText.text = "Dark Roast Coffee";
                int darkRoll = Random.Range(0, 3);
                if (darkRoll == 0)
                {
                    darkAmount = 0.75f;
                } else if (darkRoll == 1)
                {
                    darkAmount = 0.5f;
                }
                else
                {
                    darkAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - darkAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (darkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - darkAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - darkAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                
            }
            else if (orderNumber == 1)
            {
                hasMedium = true;
                orderText.text = "Medium Roast Coffee";
                int mediumRoll = Random.Range(0, 3);
                if (mediumRoll == 0)
                {
                    mediumAmount = 0.75f;
                }
                else if (mediumRoll == 1)
                {
                    mediumAmount = 0.5f;
                }
                else
                {
                    mediumAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - mediumAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - mediumAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - mediumAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                
            }
            else
            {
                hasLight = true;
                orderText.text = "Light Roast Coffee";
                int lightRoll = Random.Range(0, 3);
                if (lightRoll == 0)
                {
                    lightAmount = 0.75f;
                }
                else if (lightRoll == 1)
                {
                    lightAmount = 0.5f;
                }
                else
                {
                    lightAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - lightAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - lightAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - lightAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
            }
        }
        if (orderType == 1) //Create Tea Drink
        {
            orderNumber = Random.Range(0, 4);
            if (orderNumber == 0)
            {
                hasChai = true;
                hasWater = true;
                orderText.text = "Chai Tea";
                int waterRoll = Random.Range(0, 3);
                if (waterRoll == 0)
                {
                    waterAmount = 0.75f;
                }
                else if (waterRoll == 1)
                {
                    waterAmount = 0.5f;
                }
                else
                {
                    waterAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - waterAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - waterAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - waterAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
            }
            else if (orderNumber == 1)
            {
                hasBlack = true;
                hasWater = true;
                orderText.text = "Black Tea";
                int waterRoll = Random.Range(0, 3);
                if (waterRoll == 0)
                {
                    waterAmount = 0.75f;
                }
                else if (waterRoll == 1)
                {
                    waterAmount = 0.5f;
                }
                else
                {
                    waterAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - waterAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - waterAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - waterAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
            }
            else
            {
                hasGreen = true;
                hasWater = true;
                orderText.text = "Green Tea";
                int waterRoll = Random.Range(0, 3);
                if (waterRoll == 0)
                {
                    waterAmount = 0.75f;
                }
                else if (waterRoll == 1)
                {
                    waterAmount = 0.5f;
                }
                else
                {
                    waterAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - waterAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - waterAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - waterAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
            }
        }
        if (orderType == 2) //Create Milk Drink
        {
            orderNumber = Random.Range(0, 4);
            if (orderNumber == 0)
            {
                hasWhole = true;
                wholeAmount = 1f;
                orderText.text = "Whole Milk";
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
            else if (orderNumber == 1)
            {
                hasSkim = true;
                skimAmount = 1f;
                orderText.text = "Skim Milk";
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
            else
            {
                hasAlmond = true;
                almondAmount = 1f;
                orderText.text = "Almond Milk";
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
        }
    }

    public void CreateHardOrder()
    {
        orderText.text = "";
        orderType = Random.Range(0, 2);
        Debug.Log(orderType);
        if (orderType == 0) //Create Coffee Drink
        {
            orderNumber = Random.Range(0, 4);
            if (orderNumber == 0)
            {
                hasDark = true;
                orderText.text = "Dark Roast Coffee";
                int darkRoll = Random.Range(0, 3);
                if (darkRoll == 0)
                {
                    darkAmount = 0.75f;
                }
                else if (darkRoll == 1)
                {
                    darkAmount = 0.5f;
                }
                else
                {
                    darkAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - darkAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (darkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - darkAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - darkAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }

            }
            else if (orderNumber == 1)
            {
                hasMedium = true;
                orderText.text = "Medium Roast Coffee";
                int mediumRoll = Random.Range(0, 3);
                if (mediumRoll == 0)
                {
                    mediumAmount = 0.75f;
                }
                else if (mediumRoll == 1)
                {
                    mediumAmount = 0.5f;
                }
                else
                {
                    mediumAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - mediumAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - mediumAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - mediumAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }

            }
            else
            {
                hasLight = true;
                orderText.text = "Light Roast Coffee";
                int lightRoll = Random.Range(0, 3);
                if (lightRoll == 0)
                {
                    lightAmount = 0.75f;
                }
                else if (lightRoll == 1)
                {
                    lightAmount = 0.5f;
                }
                else
                {
                    lightAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - lightAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - lightAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - lightAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
        }
        else if (orderType == 1) //Create Tea Drink
        {
            orderNumber = Random.Range(0, 4);
            if (orderNumber == 0)
            {
                hasChai = true;
                hasWater = true;
                orderText.text = "Chai Tea";
                int waterRoll = Random.Range(0, 3);
                if (waterRoll == 0)
                {
                    waterAmount = 0.75f;
                }
                else if (waterRoll == 1)
                {
                    waterAmount = 0.5f;
                }
                else
                {
                    waterAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - waterAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - waterAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - waterAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
            else if (orderNumber == 1)
            {
                hasBlack = true;
                hasWater = true;
                orderText.text = "Black Tea";
                int waterRoll = Random.Range(0, 3);
                if (waterRoll == 0)
                {
                    waterAmount = 0.75f;
                }
                else if (waterRoll == 1)
                {
                    waterAmount = 0.5f;
                }
                else
                {
                    waterAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - waterAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - waterAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - waterAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
            else
            {
                hasGreen = true;
                hasWater = true;
                orderText.text = "Green Tea";
                int waterRoll = Random.Range(0, 3);
                if (waterRoll == 0)
                {
                    waterAmount = 0.75f;
                }
                else if (waterRoll == 1)
                {
                    waterAmount = 0.5f;
                }
                else
                {
                    waterAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - waterAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - waterAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - waterAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
        }
    }

    public void CreateVeryHardOrder()
    {
        orderText.text = "";
        orderType = Random.Range(0, 2);
        orderText.text = "Iced";
        if (orderType == 0) //Create Coffee Drink
        {
            orderNumber = Random.Range(0, 4);
            if (orderNumber == 0)
            {
                hasDark = true;
                orderText.text += " Dark Roast Coffee";
                int darkRoll = Random.Range(0, 3);
                if (darkRoll == 0)
                {
                    darkAmount = 0.75f;
                }
                else if (darkRoll == 1)
                {
                    darkAmount = 0.5f;
                }
                else
                {
                    darkAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - darkAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (darkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - darkAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - darkAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }

            }
            else if (orderNumber == 1)
            {
                hasMedium = true;
                orderText.text += " Medium Roast Coffee";
                int mediumRoll = Random.Range(0, 3);
                if (mediumRoll == 0)
                {
                    mediumAmount = 0.75f;
                }
                else if (mediumRoll == 1)
                {
                    mediumAmount = 0.5f;
                }
                else
                {
                    mediumAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - mediumAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - mediumAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - mediumAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }

            }
            else
            {
                hasLight = true;
                orderText.text += " Light Roast Coffee";
                int lightRoll = Random.Range(0, 3);
                if (lightRoll == 0)
                {
                    lightAmount = 0.75f;
                }
                else if (lightRoll == 1)
                {
                    lightAmount = 0.5f;
                }
                else
                {
                    lightAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - lightAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - lightAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - lightAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
        }
        else if (orderType == 1) //Create Tea Drink
        {
            orderNumber = Random.Range(0, 4);
            if (orderNumber == 0)
            {
                hasChai = true;
                hasWater = true;
                orderText.text += " Chai Tea";
                int waterRoll = Random.Range(0, 3);
                if (waterRoll == 0)
                {
                    waterAmount = 0.75f;
                }
                else if (waterRoll == 1)
                {
                    waterAmount = 0.5f;
                }
                else
                {
                    waterAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - waterAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - waterAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - waterAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
            else if (orderNumber == 1)
            {
                hasBlack = true;
                hasWater = true;
                orderText.text += " Black Tea";
                int waterRoll = Random.Range(0, 3);
                if (waterRoll == 0)
                {
                    waterAmount = 0.75f;
                }
                else if (waterRoll == 1)
                {
                    waterAmount = 0.5f;
                }
                else
                {
                    waterAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - waterAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - waterAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - waterAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
            else
            {
                hasGreen = true;
                hasWater = true;
                orderText.text += " Green Tea";
                int waterRoll = Random.Range(0, 3);
                if (waterRoll == 0)
                {
                    waterAmount = 0.75f;
                }
                else if (waterRoll == 1)
                {
                    waterAmount = 0.5f;
                }
                else
                {
                    waterAmount = 0.25f;
                }
                int milkRoll = Random.Range(0, 3);
                string milkName;
                if (milkRoll == 0)
                {
                    hasWhole = true;
                    wholeAmount = 1 - waterAmount;
                    milkName = "Whole Milk";
                    orderText.text += "\n with " + wholeAmount * 100f + "% " + milkName;
                }
                else if (milkRoll == 1)
                {
                    hasSkim = true;
                    skimAmount = 1 - waterAmount;
                    milkName = "Skim Milk";
                    orderText.text += "\n with " + skimAmount * 100f + "% " + milkName;
                }
                else
                {
                    hasAlmond = true;
                    almondAmount = 1 - waterAmount;
                    milkName = "Almond Milk";
                    orderText.text += "\n with " + almondAmount * 100f + "% " + milkName;
                }
                int flavorRoll = Random.Range(0, 3);
                if (flavorRoll == 0)
                {
                    hasStraw = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        strawPumps = 1;
                        orderText.text += "\n with " + strawPumps + " pump of Strawberry";
                    }
                    else
                    {
                        strawPumps = 2;
                        orderText.text += "\n with " + strawPumps + " pumps of Strawberry";
                    }
                }
                else if (flavorRoll == 1)
                {
                    hasPumpkin = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        pumpkinPumps = 1;
                        orderText.text += "\n with " + pumpkinPumps + " pump of Pumpkin Spice";
                    }
                    else
                    {
                        pumpkinPumps = 2;
                        orderText.text += "\n with " + pumpkinPumps + " pumps of Pumpkin Spice";
                    }
                }
                else
                {
                    hasFrench = true;
                    int pumpRoll = Random.Range(0, 2);
                    if (pumpRoll == 0)
                    {
                        frenchPumps = 1;
                        orderText.text += "\n with " + frenchPumps + " pump of French Vanilla";
                    }
                    else
                    {
                        frenchPumps = 2;
                        orderText.text += "\n with " + frenchPumps + " pumps of French Vanilla";
                    }
                }
            }
        }
    }

    public void CreateOrder()
    {
        if (gameController.gameTimer <= 40)
        {
            ClearValues();
            orderActive = true;
            int orderSelecter = Random.Range(0, 2);
            switch (orderSelecter)
            {
                case 0:
                    CreateEasyOrder();
                    break;
                case 1:
                    CreateMediumOrder();
                    break;
                default:
                    CreateMediumOrder();
                    break;
            }
        }else if (gameController.gameTimer >40 && gameController.gameTimer <= 80)
        {
            ClearValues();
            orderActive = true;
            int aorderSelecter = Random.Range(0, 3);
            switch (aorderSelecter)
            {
                case 0:
                    CreateEasyOrder();
                    break;
                case 1:
                    CreateMediumOrder();
                    break;
                case 2:
                    CreateHardOrder();
                    break;
                default:
                    CreateMediumOrder();
                    break;
            }
        }
        else
        {
            ClearValues();
            orderActive = true;
            int borderSelecter = Random.Range(0, 4);
            switch (borderSelecter)
            {
                case 0:
                    CreateEasyOrder();
                    break;
                case 1:
                    CreateMediumOrder();
                    break;
                case 2:
                    CreateHardOrder();
                    break;
                case 3:
                    CreateVeryHardOrder();
                    break;
                default:
                    CreateMediumOrder();
                    break;
            }
        }

                
        
    }
    public void ClearValues()
    {
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
        strawPumps = 0;
        hasFrench = false;
        frenchPumps = 0;
        hasPumpkin = false;
        pumpkinPumps = 0;       
        hasWhole = false;
        wholeAmount = 0f;
        hasSkim = false;
        skimAmount = 0f;
        hasAlmond = false;
        almondAmount = 0f;
        hasIce = false;
}


    public void CheckOrder()
    {
        if (hasIce == madeDrink.hasIce)
        {
            if (hasDark == madeDrink.hasDark && hasLight == madeDrink.hasLight && hasMedium == madeDrink.hasMedium && hasWater == madeDrink.hasWater)
            {
                if (hasChai == madeDrink.hasChai && hasBlack == madeDrink.hasBlack && hasGreen == madeDrink.hasGreen)
                {
                    if (hasSkim == madeDrink.hasSkim && hasWhole == madeDrink.hasWhole && hasAlmond == madeDrink.hasAlmond)
                    {
                        if (hasStraw == madeDrink.hasStraw && hasFrench == madeDrink.hasFrench && hasPumpkin == madeDrink.hasPumpkin)
                        {
                            if (hasDark)
                            {
                                if (madeDrink.darkAmount <= darkAmount + 0.15 && madeDrink.darkAmount >= darkAmount - 0.15)
                                {
                                    if (hasAlmond)
                                    {
                                        if (madeDrink.almondAmount <= almondAmount + 0.15 && madeDrink.almondAmount >= almondAmount -0.15) 
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                    else if (hasSkim)
                                    {
                                        if (madeDrink.skimAmount <= skimAmount + 0.15 && madeDrink.skimAmount >= skimAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                    else
                                    {
                                        if (madeDrink.wholeAmount <= wholeAmount + 0.15 && madeDrink.wholeAmount >= wholeAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                }
                                else
                                {
                                    FailedDrink();
                                }
                            }
                            else if (hasMedium)
                            {
                                if (madeDrink.mediumAmount <= mediumAmount + 0.15 && madeDrink.mediumAmount >= mediumAmount - 0.15)
                                {
                                    if (hasAlmond)
                                    {
                                        if (madeDrink.almondAmount <= almondAmount + 0.15 && madeDrink.almondAmount >= almondAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                    else if (hasSkim)
                                    {
                                        if (madeDrink.skimAmount <= skimAmount + 0.15 && madeDrink.skimAmount >= skimAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                    else
                                    {
                                        if (madeDrink.wholeAmount <= wholeAmount + 0.15 && madeDrink.wholeAmount >= wholeAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                }
                                else
                                {
                                    FailedDrink();
                                }
                            }
                            else if (hasLight)
                            {
                                if (madeDrink.lightAmount <= lightAmount + 0.15 && madeDrink.lightAmount >= lightAmount - 0.15)
                                {
                                    if (hasAlmond)
                                    {
                                        if (madeDrink.almondAmount <= almondAmount + 0.15 && madeDrink.almondAmount >= almondAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                    else if (hasSkim)
                                    {
                                        if (madeDrink.skimAmount <= skimAmount + 0.15 && madeDrink.skimAmount >= skimAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                    else
                                    {
                                        if (madeDrink.wholeAmount <= wholeAmount + 0.15 && madeDrink.wholeAmount >= wholeAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                }
                                else
                                {
                                    FailedDrink();
                                }
                            }
                            else if (hasWater)
                            {
                                if (madeDrink.waterAmount <= waterAmount + 0.15 && madeDrink.waterAmount >= waterAmount - 0.15)
                                {
                                    if (hasAlmond)
                                    {
                                        if (madeDrink.almondAmount <= almondAmount + 0.15 && madeDrink.almondAmount >= almondAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                    else if (hasSkim)
                                    {
                                        if (madeDrink.skimAmount <= skimAmount + 0.15 && madeDrink.skimAmount >= skimAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                    else
                                    {
                                        if (madeDrink.wholeAmount <= wholeAmount + 0.15 && madeDrink.wholeAmount >= wholeAmount - 0.15)
                                        {
                                            PassedDrink();
                                        }
                                        else
                                        {
                                            FailedDrink();
                                        }
                                    }
                                }
                                else
                                {
                                    FailedDrink();
                                }
                            }
                            else if (hasSkim)
                            {
                                if (madeDrink.skimAmount <= skimAmount + 0.15 && madeDrink.skimAmount >= skimAmount - 0.15)
                                {
                                    PassedDrink();
                                }
                                else
                                {
                                    FailedDrink();
                                }
                            }
                            else if (hasAlmond)
                            {
                                if (madeDrink.almondAmount <= almondAmount + 0.15 && madeDrink.almondAmount >= almondAmount - 0.15)
                                {
                                    PassedDrink();
                                }
                                else
                                {
                                    FailedDrink();
                                }
                            }
                            else if (hasWhole)
                            {
                                if (madeDrink.wholeAmount <= wholeAmount + 0.15 && madeDrink.wholeAmount >= wholeAmount - 0.15)
                                {
                                    PassedDrink();
                                }
                                else
                                {
                                    FailedDrink();
                                }
                            }
                            else if (hasWater)
                            {
                                if (madeDrink.wholeAmount <= wholeAmount + 0.15 && madeDrink.wholeAmount >= wholeAmount - 0.15)
                                {
                                    PassedDrink();
                                }
                                else
                                {
                                    FailedDrink();
                                }
                            }
                        }
                        else
                        {
                            FailedDrink();
                        }
                 
                    }
                    else
                    {
                        FailedDrink();
                    }
                }
                else
                {
                    FailedDrink();
                }
            }
            else
            {
                FailedDrink();
            }
        }
        else
        {
            FailedDrink();
        }
        
    }

    public void FailedDrink()
    {
        resultText.text = "Wrong drink!";
        if (registeredNPC.isFemale)
        {
            int clipInt = Random.Range(0, badClipsF.Count + 1);
            voicesSource.clip = badClipsF[clipInt];
        }
        else
        {
            int clipInt = Random.Range(0, badClipsM.Count + 1);
            voicesSource.clip = badClipsM[clipInt];
        }
        voicesSource.Play();
        resultText.color = Color.red;
        LeanTween.scale(resultText.gameObject, Vector3.one, 0.5f).setOnComplete(Shrink);
        Debug.Log("Failed Drink");
    }

    public void PassedDrink()
    {
        if (registeredNPC.isFemale)
        {
            int clipInt = Random.Range(0, doneClipsF.Count + 1);
            voicesSource.PlayOneShot(doneClipsF[clipInt]);
        }
        else
        {
            int randomPlay = Random.Range(0, 2);
            if (randomPlay == 0)
            {
                int clipInt = Random.Range(0, doneClipsM.Count + 1);
                voicesSource.PlayOneShot(doneClipsM[clipInt]);
            }
            else
            {

            }
            
        }
        
        orderText.text = "";
        ClearValues();
        registeredNPC.orderComplete = true;
        servedNPCs += 1;
        DeRegisterNPC();
        resultText.text = "Success!";
        resultText.color = Color.green;
        LeanTween.scale(resultText.gameObject, Vector3.one, 0.5f).setOnComplete(Shrink);
        drinkController.ResetDrink();
        Debug.Log("Passed Drink");
        orderActive = false;
        thePlayer.hasOrder = false;
        
    }

    public void Shrink()
    {
        LeanTween.scale(resultText.gameObject, Vector3.zero, 0.5f).setOnComplete(Shrink);
    }

}
