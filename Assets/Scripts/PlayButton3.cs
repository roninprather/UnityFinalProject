using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton3 : MonoBehaviour
{
    public Slider volumeSlider;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1.0f;
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1.0f;
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1.0f;
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene("Level 3");
        Time.timeScale = 1.0f;
    }

    public void ChangeVolume()
    {
        gameObject.GetComponent<AudioSource>().volume = volumeSlider.value;
    }
}