using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PourController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Animator anim;
    bool isPouring;
    public ParticleSystem pourParticles;
    public GameObject liquidObject;
    public float pourTime;

    public bool isMilk;

    public bool isTea;

    public bool isFlavor;

    public bool isIce;

    public bool isOne;
    public bool isTwo;
    public bool isThree;
    public bool isFour;

    public Color oneColor;
    public Color twoColor;
    public Color threeColor;
    public Color fourColor;
    public Color teaColor;

    public GameObject iceCubes;
    public GameObject iceCubeOne;
    public GameObject iceCubeTwo;
    public GameObject iceCubeThree;
    public GameObject iceCubeFour;
    public GameObject iceCubeFive;

    public GameObject teaBag;
    public GameObject replaceButton;
    public GameObject exitButton;

    private Color pourColor;

    private bool doingPour = false;

    private DrinkController drinkController;
    private float currentY;
    private float newY;

    private bool isCalculated;

    private Transform teaLocation;

    public AudioSource soundEffects;
    public AudioClip pourNoise;
    public AudioClip flavorNoise;
    public AudioClip dunkNoise;
    public AudioClip cupNoise;
    public AudioClip iceNoise;


    // Start is called before the first frame update
    void Start()
    {
        drinkController = GameObject.FindGameObjectWithTag("DrinkController").GetComponent<DrinkController>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    void OnEnable()
    {
        SetPourColor();
    }

    public void PlayPour()
    {
        soundEffects.PlayOneShot(pourNoise);
    }

    public void StopPour()
    {
        soundEffects.Stop();
    }

    public void PlayIce()
    {
        soundEffects.PlayOneShot(iceNoise);
    }

    public void PlayDunk()
    {
        soundEffects.PlayOneShot(dunkNoise);
    }

    public void PlayFlavorPump()
    {
        soundEffects.PlayOneShot(flavorNoise);
    }

    public void ResetTeas()
    {
        if (isTea && !isFlavor && anim != null)
        {
            anim.SetTrigger("DrinkReset");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isPouring && (liquidObject.transform.localScale.y < 1f))
        {
            isPouring = false;
            anim.SetTrigger("PlayerClicked");
        }

        if (doingPour && (liquidObject.transform.localScale.y == 1f))
        {
            doingPour = false;
            isCalculated = true;
            anim.SetTrigger("ClickReleased");
        }

    }

    private void SetPourColor()
    {
        if (!isIce)
        {
            if (isOne)
            {
                pourColor = oneColor;
                if (!isFlavor)
                {
                    pourParticles.startColor = oneColor;
                }

            }
            if (isTwo)
            {
                pourColor = twoColor;
                if (!isFlavor)
                {
                    pourParticles.startColor = twoColor;
                }

            }
            if (isThree)
            {
                pourColor = threeColor;
                if (!isFlavor)
                {
                    pourParticles.startColor = threeColor;
                }

            }
            if (isFour)
            {
                Debug.Log("new color");
                pourColor = fourColor;
                pourParticles.startColor = fourColor;
                pourColor.a = 0.6f;
            }
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        exitButton.SetActive(false);
        replaceButton.SetActive(false);
        if (isTea)
        {
            StartSteeping();
        }
        else if (isIce && !iceCubes.activeInHierarchy)
        {
            StartParticles();
        }else if (!isIce)
        {
            isPouring = true;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isFlavor)
        {
            StartCoroutine(DelayButtons());
            if (!isTea && !isIce)
            {
                isPouring = false;
                anim.SetTrigger("ClickReleased");
            }
        }
        else
        {
            StartCoroutine(DelayTeaButtons());
            if (!isTea && !isIce)
            {
                isPouring = false;
                anim.SetTrigger("ClickReleased");
            }
        }
        
        
    }

    IEnumerator DelayButtons()
    {
        yield return new WaitForSeconds(0.6f);
        exitButton.SetActive(true);
        if (!isIce)
        {
            replaceButton.SetActive(true);
        }
              
    }

    IEnumerator DelayTeaButtons()
    {
        yield return new WaitForSeconds(1.9f);
        Debug.Log("Ran");
        exitButton.SetActive(true);
        replaceButton.SetActive(true);
    }

    private void CancelPouring()
    {
        if (!isTea && !isIce)
        {
            isPouring = false;
            anim.SetTrigger("ClickReleased");
        }
    }

    public void StartParticles()
    {
        pourParticles.Play();
        if (isIce && !iceCubes.activeInHierarchy)
        {
            StartCoroutine(AddIceCubes());
        }
        else if (isIce && iceCubes.activeInHierarchy)
        {
            Debug.Log("Ice Already added");
        }
    }

    IEnumerator AddIceCubes()
    {
        exitButton.SetActive(false);
        PlayIce();
        iceCubes.SetActive(true);
        iceCubeOne.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        iceCubeTwo.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        iceCubeThree.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        iceCubeFour.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        iceCubeFive.SetActive(true);
        drinkController.hasIce = true;
        StopParticles();
        exitButton.SetActive(true);
   
    }

    public void StopParticles()
    {
        pourParticles.Stop();
    }

    public void StartSteeping()
    {
        float currentY = liquidObject.transform.localScale.y;
        if (currentY > 0f)
        {
            if (isTea && !isFlavor && teaBag.activeInHierarchy)
            {
                Debug.Log("Tea Already Added");
            }
            else
            {

                anim.SetTrigger("ItemUsed");

                Debug.Log("Adding tea or flavor");
                HandleTeaFlavor();
                if (isTea && !isFlavor)
                {
                    replaceButton.SetActive(false);
                }
                
            }
            LeanTween.delayedCall(liquidObject, 0.2f, () =>
            {
                LeanTween.imageColor(liquidObject.GetComponent<RectTransform>(), pourColor, 2f);
                //LeanTween.scaleY(liquidObject, 1f, pourTime - (currentY * pourTime));
            });
        }
        else if (isFlavor)
        {
            Debug.Log("requires liquid");
        }
        else if (isTea)
        {
            if (teaBag.activeInHierarchy)
            {
                Debug.Log("Tea Already Used");
            }
            else
            {

                anim.SetTrigger("ItemUsed");


                Debug.Log("Adding tea or flavor");
                HandleTeaFlavor();
                replaceButton.SetActive(false);
            }
            
            LeanTween.delayedCall(liquidObject, 0.5f, () =>
            {
                LeanTween.imageColor(liquidObject.GetComponent<RectTransform>(), pourColor, 2f);
                //LeanTween.scaleY(liquidObject, 1f, pourTime - (currentY * pourTime));
            });
        }
    }

    private void HandleTeaFlavor()
    {
        if (isTea && !isFlavor)
        {
            if (isOne)
            {
                drinkController.hasChai = true;
            }
            if (isTwo)
            {
                drinkController.hasBlack = true;
            }
            if (isThree)
            {
                drinkController.hasGreen = true;
            }
        }
        if (isFlavor)
        {
            if (isOne)
            {
                drinkController.hasPumpkin = true;
                drinkController.pumpkinPumps += 1;
            }
            if (isTwo)
            {
                drinkController.hasStraw = true;
                drinkController.strawPumps += 1;
            }
            if (isThree)
            {
                drinkController.hasFrench = true;
                drinkController.frenchPumps += 1;
            }
        }
    }

    public void InsertTea()
    {
        if (isTea && !isFlavor)
        {
            teaBag.SetActive(true);
        }
        
    }

    public void StartPouring()
    {
        currentY = liquidObject.transform.localScale.y;
        Color currentColor = liquidObject.GetComponent<Image>().color;
        
        if (currentY < 1f)
        {
            doingPour = true;
            if (currentColor == Color.white)
            {
                liquidObject.GetComponent<Image>().color = pourColor;
                bool fillCup = true;
                pourParticles.Play();
                if (fillCup)
                {
                    LeanTween.delayedCall(liquidObject, 0.5f, () =>
                    {
                        LeanTween.scaleY(liquidObject, 1f, 3f - (currentY * 3f)).setOnComplete(SteepTea);
                    });
                }

            }
            else
            {
                //SetPourColor();
                bool fillCup = true;
                if (isMilk)
                {
                    pourColor = liquidObject.GetComponent<Image>().color;
                    pourColor.g = liquidObject.GetComponent<Image>().color.g + 0.1f;
                }
                pourParticles.Play();
                if (fillCup)
                {
                    LeanTween.delayedCall(liquidObject, 0.5f, () =>
                    {
                        LeanTween.imageColor(liquidObject.GetComponent<RectTransform>(), pourColor, 2f);
                        LeanTween.scaleY(liquidObject, 1f, pourTime - (currentY * pourTime)).setOnComplete(SteepTea);
                    });
                }
            }

        }
        else
        {
            Debug.Log("Cup is Full");
        }
        
    }

    private void SteepTea()
    {
        Debug.Log("Trying");
        if(teaBag.activeInHierarchy == true)
        {
            Debug.Log("Steeped");
            LeanTween.imageColor(liquidObject.GetComponent<RectTransform>(), teaColor, 1.5f);
        }

        HandleMilkCoffee();
    }

    private void HandleMilkCoffee()
    {
        newY = liquidObject.transform.localScale.y;
        Debug.Log("Adding milk or coffee");
        if (isMilk || !isTea )
        {
            if (isMilk)
            {
                if (isOne)
                {
                    drinkController.hasWhole = true;
                    drinkController.wholeAmount += newY - currentY;
                }
                if (isTwo)
                {
                    drinkController.hasSkim = true;
                    drinkController.skimAmount += newY - currentY;
                }
                if (isThree)
                {
                    drinkController.hasAlmond = true;
                    drinkController.almondAmount += newY - currentY;
                }
            }
            else
            {
                if (isOne)
                {
                    drinkController.hasDark = true;
                    drinkController.darkAmount += newY - currentY;
                }
                if (isTwo)
                {
                    drinkController.hasMedium = true;
                    drinkController.mediumAmount += newY - currentY;
                }
                if (isThree)
                {
                    Debug.Log("Is working");
                    drinkController.hasLight = true;
                    drinkController.lightAmount += newY - currentY;
                }
                if (isFour)
                {
                    drinkController.hasWater = true;
                    drinkController.waterAmount += newY - currentY;
                }
            }
        }
    }

    public void StopPouring()
    {
        if ((!isTea || isMilk) && isCalculated == false)
        {
           HandleMilkCoffee();
        }
        doingPour = false;
        isCalculated = false;
        pourParticles.Stop();
        LeanTween.cancel(liquidObject);
        if (teaBag.activeInHierarchy == true)
        {
            LeanTween.imageColor(liquidObject.GetComponent<RectTransform>(), teaColor, 1.5f);
        }
    }
}
