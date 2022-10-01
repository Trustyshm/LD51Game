using UnityEngine;
using UnityEngine.EventSystems;


public class PourController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Animator anim;
    bool isPouring;
    public ParticleSystem pourParticles;
    public GameObject liquidObject;



    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPouring)
        {
            isPouring = false;
            anim.SetTrigger("PlayerClicked");
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPouring = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPouring = false;
        anim.SetTrigger("ClickReleased");
    }

    public void StartPouring()
    {
        bool fillCup = true;
        Debug.Log("Is Pouring");
        pourParticles.Play();
        if (fillCup)
        {
            LeanTween.scaleY(liquidObject, 1f, 2f);
        }
    }

    public void StopPouring()
    {
        pourParticles.Stop();
        LeanTween.cancel(liquidObject);
    }
}
