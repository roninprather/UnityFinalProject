using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitToMenu : MonoBehaviour
{
    public void QuitGame(){
        Application.Quit();
    }

    public void GoToMenu(){
        SceneManager.LoadScene("main menu");
    }
}