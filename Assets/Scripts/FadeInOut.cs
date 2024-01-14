using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    // References
    public CanvasGroup canvasgroup;
    public bool fadeIn;
    public bool fadeOut;
    public float timeToFade;

    void Start()
    {
        canvasgroup = GetComponent<CanvasGroup>();
        fadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        // If fadein is true it slowly fades in
        if(fadeIn == true)
        {
            if(canvasgroup.alpha < 1)
            {
                canvasgroup.alpha += timeToFade * Time.deltaTime;
                if(canvasgroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        // If fadeout is true it slowly fades out
        if(fadeOut == true)
        {
            if(canvasgroup.alpha >= 0)
            {
                canvasgroup.alpha -= timeToFade * Time.deltaTime;
                if(canvasgroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
    public void FadeIn()
    {
        fadeIn = true;
    }
    public void FadeOut()
    {
        fadeOut = true;
    }
}
