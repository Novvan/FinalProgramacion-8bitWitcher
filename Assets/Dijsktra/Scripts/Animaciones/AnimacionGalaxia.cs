using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionGalaxia : MonoBehaviour
{
    private float timer;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
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
        this.transform.eulerAngles = new Vector3(0, 0, timer*-1);   
    }
}
