using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenager : MonoBehaviour
{
    public static ScoreMenager instance; 
    public Text scoreText;
    int score = 0; 

    private void Awake(){
        instance = this; 
    }
    void Start()
    {
        scoreText.text = score.ToString()+" Points";
    }
    public void AddPoint(){
        score+=1;
        scoreText.text = score.ToString()+" Points";
    }
    
}
