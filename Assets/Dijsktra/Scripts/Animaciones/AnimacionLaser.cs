using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionLaser : MonoBehaviour
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
        if(timer >= 1)
        {
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime * speed;
        }
        this.GetComponent<Image>().materialForRendering.SetTextureOffset("_MainTex", new Vector2(timer*-1, 0));
    }
}
