using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnabler : MonoBehaviour
{
    public GameObject uiStuff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        uiStuff.SetActive(true);
    }

    void OnDisable()
    {
        uiStuff.SetActive(false);
    }
}
