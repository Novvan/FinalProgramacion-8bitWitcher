using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Queue: MonoBehaviour {

    public List<GameObject> enemies;
    public Queue<GameObject> waitingLine;

    private GameObject temp;
    private int rand;
    public int CantEnemies;

    private void Awake()
    {
        waitingLine = new Queue<GameObject>();

        for (int k = 0; k < CantEnemies; k++)
        {
            rand = Random.Range(0, enemies.Count);
            temp = Instantiate(enemies[rand], new UnityEngine.Vector3((float)-k / 2, 0, 0), enemies[rand].transform.rotation);
            waitingLine.Enqueue(temp);
            Debug.Log("Spawn");
        }
    }
    
    public void LineEnqueue()
    {
        rand = Random.Range(0, enemies.Count);
        temp = Instantiate(enemies[rand], new UnityEngine.Vector3(-(float)waitingLine.Count / 2, 0, 0), enemies[rand].transform.rotation);
        waitingLine.Enqueue(temp);
    }
    public void LineDequeue()
    {
        temp = waitingLine.Dequeue();
        Destroy(temp);
        ResetQueue();
    }
    
    private void ResetQueue()
    {
        GameObject[] tempList = new GameObject[waitingLine.Count];
        waitingLine.CopyTo(tempList, 0);

        for(int x=0; x < tempList.Length; x++)
        {
            tempList[x].transform.position = new UnityEngine.Vector2(-(float)x / 2, 0);

        }
    }
}
