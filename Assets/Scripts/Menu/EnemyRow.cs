using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyRow : MonoBehaviour
{
    private GameObject _textObject = null;

    public void ChangeText(int component,string text)
    {
        _textObject = transform.GetChild(component).gameObject;
        _textObject.GetComponent<TextMeshProUGUI>().text = text;
        //Debug.Log(_textObject);
    }
}
