using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check2 : MonoBehaviour
{
    public GameObject plane;
    public Transform respawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.name=="Player"){
            plane.GetComponent<FallOff>().respawn = respawn;
        } 
        
    }
}
