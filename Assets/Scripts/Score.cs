using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private Transform container;
    // Start is called before the first frame update
    void Start()
    {
        container = this.transform;
    }

    public void SetScore(int value)
    {
        container.Find("ScoreAmount").GetComponent<TextMeshProUGUI>().SetText(value.ToString());
    }
    
}
