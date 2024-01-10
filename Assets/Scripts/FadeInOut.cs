using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{

    public CanvasGroup canvasgroup;
    public bool fadein;
    public bool fadeout;
    public float TimeToFade;

    void Start()
    {
        canvasgroup = GetComponent<CanvasGroup>();
        fadeout = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadein == true)
        {
            if(canvasgroup.alpha < 1)
            {
                canvasgroup.alpha += TimeToFade * Time.deltaTime;
                if(canvasgroup.alpha >= 1)
                {
                    fadein = false;
                }
            }
        }
        if(fadeout == true)
        {
            if(canvasgroup.alpha >= 0)
            {
                canvasgroup.alpha -= TimeToFade * Time.deltaTime;
                if(canvasgroup.alpha == 0)
                {
                    fadeout = false;
                }
            }
        }
    }
    public void FadeIn()
    {
        fadein = true;
    }
    public void FadeOut()
    {
        fadeout = true;
    }
}
