using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = false;
    public string levelToLoad;

    void Start() { 
     startTime = Time.time;
    }
    
    void Update () {
        if (finished)
            return;
        
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    public void Finish ()
    {
        finished = true;
        timerText.color = Color.yellow;

        if (Time.time <= 0.01f)
        {
            SceneManager.LoadScene("Scenes/BonusLevel", LoadSceneMode.Single);;
        }
        else
        {
            SceneManager.LoadScene("Scenes/BossLevel", LoadSceneMode.Single);
        }
    }
}
