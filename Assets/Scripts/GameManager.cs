using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private List<GameObject> _enemySpawns;
    [SerializeField] private GameObject _enemy;
    private List<GameObject> _enemyList = new List<GameObject>();
    private GameObject[] _enemyArray;
    public GameObject[] EnemyArray => _enemyArray;
    public List<GameObject> EnemyList => _enemyList;
    public Queue<GameObject> waitingline;
    
    public bool isAlive = true;

    void Start()
    {
        waitingline = new Queue<GameObject>();
        if (_enemySpawns.Count != 0)
        {
            for (int i = 0; i < _enemySpawns.Count; i++)
            {
                GameObject wood = Instantiate(_enemy, _enemySpawns[i].transform);
                Debug.Log("Spawn");
                _enemyList.Add(wood);
                _enemyList[i].GetComponent<wood_enemy>().playerSpawn = _player;
                waitingline.Enqueue(wood);
            }
            QuickSort(_enemyList, 0, _enemyList.Count - 1);
        }
    }
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
    
    public void LineEnqueue()
    {
        var temp = Instantiate(_enemy, _enemySpawns[2].transform);
        waitingline.Enqueue(temp);
    }
    public void LineDequeue()
    {
        var temp = waitingline.Dequeue();
        Destroy(temp);
        ResetQueue();
    }
    
    private void ResetQueue()
    {
        GameObject[] tempList = new GameObject[waitingline.Count];
        waitingline.CopyTo(tempList, 0);

        for(int x=0; x < tempList.Length; x++)
        {
            tempList[x].transform.position = new Vector2(-(float)x / 2, 0);
        }
    }
    
}