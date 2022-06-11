using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pauser : MonoBehaviour
{
    public float check;
    public bool paused;
    //public Text pausedText;
    public GameObject Menu;
    public PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        //pausedText.enabled = false;
        check = Time.timeScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!paused){
            Time.timeScale = 0;
            //pausedText.enabled = true;
            Menu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }else{
                Time.timeScale = check;
            //pausedText.enabled = false;
            Menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        paused = !paused;
        pm.paused = paused;
        
        }
    }

    public void Unpause() {
        Time.timeScale = check;
        //pausedText.enabled = false;
        Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        pm.paused = paused;
    }
}
