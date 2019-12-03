using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private FillerHandler Health;
    [SerializeField] private FillerHandler Stamina;
    
    
    public float InitHealth;
    private float CurrentHealth;
    public float InitStamina;
    private float currentStamina;

    private void Start()
    {
        Health.Initialize(InitHealth, InitHealth);
        Stamina.Initialize(InitStamina,InitStamina);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Health.MyCurrentValue -= 10;
            Stamina.MyCurrentValue -= 5;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Health.MyCurrentValue += 10;
            Stamina.MyCurrentValue += 5;
        }
    }
}