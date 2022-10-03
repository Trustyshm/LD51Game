using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineChatter : MonoBehaviour
{

    public List<AudioClip> waitingClips = new List<AudioClip>();
    public AudioSource voicesSource;
    private int peopleInt;

    private float thirtySeconds = 5f;
    private float shoutTimer;



    // Start is called before the first frame update
    void Start()
    {
        peopleInt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        thirtySeconds -= Time.deltaTime;
        if (thirtySeconds <= 0)
        {
            GetPeopleInt();
        }
        if (thirtySeconds <= 0 && peopleInt > 3)
        {
            thirtySeconds = 6;
            PlayComplaint();
        }
        
           
    }

    void GetPeopleInt()
    {
        peopleInt = transform.childCount;
    }

    private void PlayComplaint()
    {
        int clipInt = Random.Range(0, waitingClips.Count);
        voicesSource.PlayOneShot(waitingClips[clipInt]);      
    }
}
