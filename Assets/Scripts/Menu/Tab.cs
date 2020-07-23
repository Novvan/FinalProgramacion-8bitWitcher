using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tab : MonoBehaviour
{
    private bool _active;
    [SerializeField] private GameManager _gm;
    public GameObject _panelHP;
    private List<GameObject> _enemyList;
    private bool _listupdated;
    private void Update()
    {
        _enemyList = _gm.EnemyList;
        _updateList(_enemyList);
    }
    private void _updateList(List<GameObject> el)
    {
        if (el.Count > 0 && !_listupdated)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject Enemylabel = _panelHP.transform.GetChild(i).gameObject;
                Enemylabel.GetComponent<EnemyRow>().ChangeText(0, (i + 1).ToString());
                Enemylabel.GetComponent<EnemyRow>().ChangeText(1, el[i].GetComponent<wood_enemy>().dist.ToString());
                Enemylabel.GetComponent<EnemyRow>().ChangeText(2, el[i].GetComponent<wood_enemy>().Health.ToString());
                _listupdated = false;
            }     
        }
    }
}