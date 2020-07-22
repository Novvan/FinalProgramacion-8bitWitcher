using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class FillerHandler : MonoBehaviour
{
    public float lerpSpeed;
    private Image content;
    private float currentFill;
    public float MyMaxValue { get; set; }
    private float currentValue;
    
    public float MyCurrentValue
    {
        get { return currentValue; }
        set
        {
            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }

            else if (value < 0)
            { 
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }
            currentFill = currentValue / MyMaxValue;
        }
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }

    private void Start()
    {
        content = GetComponent<Image>();
    }

    private void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }
}