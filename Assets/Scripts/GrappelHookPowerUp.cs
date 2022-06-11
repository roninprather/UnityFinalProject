using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrappelHookPowerUp : MonoBehaviour
{
    public GameObject player;
    public GameObject instruct;
    // Start is called before the first frame update
    void Start()
    {
        instruct.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {

        
    }

        private void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.tag == "Player"){
            GrappelHook gh = player.GetComponent<GrappelHook>();
            gh.hasHook = true;
            transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 100f, gameObject.transform.position.z);
            StartCoroutine(Instruct());
        }

    }

    IEnumerator Instruct()
    {
       
        
        instruct.SetActive(true);
        yield return new WaitForSeconds(10);
        instruct.SetActive(false);
       
    }



}
