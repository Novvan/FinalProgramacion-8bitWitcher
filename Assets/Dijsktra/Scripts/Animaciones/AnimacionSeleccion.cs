﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionSeleccion : MonoBehaviour
{
    private float timer;
    public float speed;
    public bool animarInverso;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        speed = animarInverso ? speed*-1 : speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 360)
        {
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime * speed;
        }
        
        this.GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, timer);   
    }
}