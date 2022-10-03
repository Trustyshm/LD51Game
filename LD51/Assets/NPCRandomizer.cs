using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandomizer : MonoBehaviour
{
    [Header("NPC Parts")]
    public Renderer botHair;
    public Renderer botShirt;
    public Renderer botPants;
    public Renderer botSkin;
    public Renderer botHat;
    public Renderer botBeard;
    public GameObject beardObject;
    public GameObject hatObject;

    [Header("Clothes Colors")]
    public Color colorOne;
    public Color colorTwo;
    public Color colorThree;
    public Color colorFour;
    public Color colorFive;
    public Color colorSix;

    [Header("Hair Colors")]
    public Color hairOne;
    public Color hairTwo;
    public Color hairThree;
    public Color hairFour;

    [Header("Skin Colors")]
    public Color skinOne;
    public Color skinTwo;
    public Color skinThree;
    public Color skinFour;

    private List<Color> colorList = new List<Color>();
    private List<Color> hairList = new List<Color>();
    private List<Color> skinList = new List<Color>();

    public bool isFemale;

    // Start is called before the first frame update
    void Awake()
    {
        colorList.Add(colorOne);
        colorList.Add(colorTwo);
        colorList.Add(colorThree);
        colorList.Add(colorFour);
        colorList.Add(colorFive);
        colorList.Add(colorSix);

        hairList.Add(hairOne);
        hairList.Add(hairTwo);
        hairList.Add(hairThree);
        hairList.Add(hairFour);

        skinList.Add(skinOne);
        skinList.Add(skinTwo);
        skinList.Add(skinThree);
        skinList.Add(skinFour);
    }

    private void OnEnable()
    {
        RandomizeNPC();
    }

    public void RandomizeNPC()
    {
        RandomizeClothes();
        RandomizeHair();
        RandomizeSkin();
        RandomizeHat();
        if (!isFemale)
        {
            RandomizeBeard();
        }
    }

    public void RandomizeClothes()
    {
        int clothesVar = Random.Range(0, colorList.Count - 1);
        botShirt.material.color = colorList[clothesVar];
        int pantsVar = Random.Range(0, colorList.Count - 1);
        botPants.material.color = colorList[pantsVar];
    }

    public void RandomizeHair()
    {
        int hairVar = Random.Range(0, hairList.Count - 1);
        botHair.material.color = hairList[hairVar];
    }

    public void RandomizeSkin()
    {
        int skinVar = Random.Range(0, skinList.Count - 1);
        botSkin.material.color = skinList[skinVar];
    }

    public void RandomizeHat()
    {
        int hasHat = Random.Range(0, 5);
            switch (hasHat)
            {
                case 0:
                    hatObject.SetActive(true);
                    int hatVar = Random.Range(0, colorList.Count - 1);
                    botHat.material.color = colorList[hatVar];
                    break;
                case 1:
                    hatObject.SetActive(true);
                    int ahatVar = Random.Range(0, colorList.Count - 1);
                    botHat.material.color = colorList[ahatVar];
                break;
                case 2:
                    hatObject.SetActive(false);
                    break;
                case 3:
                    hatObject.SetActive(false);
                    break;
                case 4:
                    hatObject.SetActive(false);
                    break;
                default:
                    hatObject.SetActive(false);
                    break;

            }
        
    }

    public void RandomizeBeard()
    {
        int hasBeard = Random.Range(0, 5);
        switch (hasBeard)
        {
            case 0:
                beardObject.SetActive(true);
                int hatVar = Random.Range(0, hairList.Count - 1);
                botBeard.material.color = hairList[hatVar];
                break;
            case 1:
                beardObject.SetActive(true);
                int ahatVar = Random.Range(0, hairList.Count - 1);
                botBeard.material.color = hairList[ahatVar];
                break;
            case 2:
                beardObject.SetActive(false);
                break;
            case 3:
                beardObject.SetActive(false);
                break;
            case 4:
                beardObject.SetActive(false);
                break;
            default:
                beardObject.SetActive(false);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
