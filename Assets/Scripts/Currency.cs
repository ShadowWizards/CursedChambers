using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    private Transform container;
    // Start is called before the first frame update
    void Start()
    {
        container = this.transform;
    }

    public void SetCurrency(int value)
    {
        container.Find("Currency").GetComponent<TextMeshProUGUI>().SetText(value.ToString());
    }
}
