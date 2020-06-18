using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyRow : MonoBehaviour
{
    private GameObject _textObject = null;

    public void changeText(int component,string text)
    {
        _textObject = this.transform.GetChild(component).gameObject;
        _textObject.GetComponent<TextMeshProUGUI>().text = text;
        //Debug.Log(_textObject);
    }
}
