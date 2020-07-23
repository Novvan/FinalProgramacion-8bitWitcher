using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel2 : MonoBehaviour {
    
    public void StartLevel ()
    {
        SceneManager.LoadScene("Scenes/Level2", LoadSceneMode.Single);
    }
}
