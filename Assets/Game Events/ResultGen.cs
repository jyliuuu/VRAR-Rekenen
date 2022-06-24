using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultGen : MonoBehaviour
{
    public bool correct = false;
    public TextMeshPro resultDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if (correct == true)
        {
            resultDisplay.SetText("CORRECT!");
        }
        else
        {
            resultDisplay.SetText(" ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(correct);
    }
}
