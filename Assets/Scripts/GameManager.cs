using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerSpawn;
    [SerializeField] private List<GameObject> _enemySpawns;
    [SerializeField] private GameObject _enemy;
    private List<GameObject> _enemyList = new List<GameObject>();
    private GameObject[] _enemyArray;
    public GameObject[] EnemyArray => _enemyArray;
    public List<GameObject> EnemyList => _enemyList;

    public bool isAlive = true;

    void Start()
    {
        if (_enemySpawns.Count != 0)
        {
            for (int i = 0; i < _enemySpawns.Count; i++)
            {
                _enemy.GetComponent<wood_enemy>().playerSpawn = _playerSpawn;
                GameObject wood = Instantiate(_enemy, _enemySpawns[i].transform);
                _enemyList.Add(wood);
            }
            _enemyArray = new GameObject[_enemyList.Count];
            _enemyArray = _enemyList.ToArray();
            QuickSort(_enemyList, 0, _enemyList.Count - 1);
        }
        
        //QuickSort(_enemyArray, 0, _enemyList.Count - 1);
    }
    
    // static public void QuickSort(GameObject[] array, int start, int end)
    // {
    //     int i, j, center;
    //     GameObject pivot;
    //     center = (start + end) / 2;
    //     Debug.Log(center);
    //     pivot = array[center];
    //     i = start;
    //     j = end;
    //     do
    //     {
    //         while (array[i].GetComponent<wood_enemy>().dist < pivot.GetComponent<wood_enemy>().dist) i++;
    //         while (array[j].GetComponent<wood_enemy>().dist > pivot.GetComponent<wood_enemy>().dist) j--;
    //         if (i <= j)
    //         {
    //             GameObject temp;
    //             temp = array[i];
    //             array[i] = array[j];
    //             array[j] = temp;
    //             i++;
    //             j--;
    //         }
    //     } while (i <= j);        
    //     if (start < j)
    //     {
    //         QuickSort(array, start, j);
    //     }
    //
    //     if (i < end)
    //     {
    //         QuickSort(array, i, end);
    //     }
    // }
    static public void QuickSort(List<GameObject> list, int start, int end)
    {
        int i, j, center;
        GameObject pivot;
        center = (start + end) / 2;
        //Debug.Log(center);
        pivot = list[center];
        i = start;
        j = end;
        do
        {
            while (list[i].GetComponent<wood_enemy>().dist < pivot.GetComponent<wood_enemy>().dist) i++;
            while (list[j].GetComponent<wood_enemy>().dist > pivot.GetComponent<wood_enemy>().dist) j--;
            if (i <= j)
            {
                GameObject temp;
                temp = list[i];
                list[i] = list[j];
                list[j] = temp;
                i++;
                j--;
            }
        } while (i <= j);
    
        if (start < j)
        {
            QuickSort(list, start, j);
        }
    
        if (i < end)
        {
            QuickSort(list, i, end);
        }
    }
}