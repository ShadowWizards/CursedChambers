using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    // References
    public CanvasGroup canvasgroup;
    public Image myImage;
    public bool fadeIn;
    public bool fadeOut;
    public float timeToFade;
    public float alphaLevel;
    private bool playerIsDead;
    private DeathHandler deathHandler;

    void Start()
    {
        canvasgroup = GetComponent<CanvasGroup>();
        myImage = GetComponent<Image>();
        deathHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<DeathHandler>();
        alphaLevel = 1f;
        fadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        // If fadein is true it slowly fades in
        if(fadeIn == true)
        {
            if(canvasgroup.alpha < alphaLevel)
            {
                canvasgroup.alpha += timeToFade * Time.deltaTime;
                if(canvasgroup.alpha >= alphaLevel)
                {
                    fadeIn = false;
                    if(playerIsDead)
                    {
                        deathHandler.stopTime();
                    }
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
    public void DeathScreen()
    {
        fadeIn = true;
        playerIsDead = true;

        myImage.color = Color.red;
        alphaLevel = 0.25f;
        

        timeToFade /= 5;
        deathHandler.playerIsDead();
        Time.timeScale = 0.75f;
    }

    public void WinScreen()
    {
        fadeIn = true;
        playerIsDead = true;

        myImage.color = new Color32(59, 177, 67, 255);
        alphaLevel = 0.25f;
        

        timeToFade /= 5;
        deathHandler.PlayerWon();
        Time.timeScale = 0.75f;
    }
}
