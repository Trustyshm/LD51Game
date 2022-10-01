using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class WaterMovement : MonoBehaviour
{
    public Image m_Image;

    public Sprite[] m_SpriteArray;
    public float m_Speed = 0.2f;

    private int m_IndexSprite;
    Coroutine m_CoroutineAnim;
    bool isDone;

    public void Func_PlayUIAnim()
    {
        isDone = false;
        StartCoroutine(Func_PlayAnimUI());
    }


    void OnEnable()
    {
        Func_PlayUIAnim();
    }


    IEnumerator Func_PlayAnimUI()
    {
        yield return new WaitForSeconds(m_Speed);
        if (m_IndexSprite >= m_SpriteArray.Length){
            m_IndexSprite = 0;
        }
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
        m_IndexSprite += 1;
        if (isDone == false)
        {
            m_CoroutineAnim = StartCoroutine(Func_PlayAnimUI());
        }
    }
}
