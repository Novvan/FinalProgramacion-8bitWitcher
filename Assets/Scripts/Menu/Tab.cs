using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tab : MonoBehaviour
{
    private bool _active;
    [SerializeField] private GameManager _gm;
    private GameObject _panelHP;
    private GameObject[] _enemyArray;
    private List<GameObject> _enemyList;

    private void Start()
    {
        _panelHP = this.transform.Find("HP Panel").gameObject;
        _active = false;
        _enemyArray = _gm.EnemyArray;
        _enemyList = _gm.EnemyList;
    }


    void Update()
    {
        
        for (int i = 0; i < 10; i++)
        {
            GameObject Enemylabel = _panelHP.transform.GetChild(i).gameObject;
            Enemylabel.GetComponent<EnemyRow>().changeText(0, (i + 1).ToString());
            Enemylabel.GetComponent<EnemyRow>().changeText(1, _enemyList[i].GetComponent<wood_enemy>().dist.ToString());
            Enemylabel.GetComponent<EnemyRow>().changeText(2, _enemyList[i].GetComponent<wood_enemy>().Health.ToString()); 
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            _panelHP.SetActive(!_active);
            _active = !_active;
        }
    }
}