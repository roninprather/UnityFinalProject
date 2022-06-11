using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton2 : MonoBehaviour
{
    public void QuitGame(){
    Application.Quit();
}

public void StartGame(){
    SceneManager.LoadScene("Level 2");
    Time.timeScale = 1.0f;
}
}
