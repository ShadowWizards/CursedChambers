using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI container;
    // Start is called before the first frame update
    void Start()
    {
        container = GameObject.Find("ScoreAmount").GetComponent<TextMeshProUGUI>();
    }

    public void SetScore(int value)
    {
        container.SetText(value.ToString());
    }
    
}
