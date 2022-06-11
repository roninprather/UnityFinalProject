using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Goal : MonoBehaviour
{

    public GameObject end;
    public GameObject stayPaused;
    public PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        end.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.tag == "Player"){
            pm.paused = true;
            Time.timeScale = 0;
            end.SetActive(true);
            stayPaused.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
        }

    }
}
