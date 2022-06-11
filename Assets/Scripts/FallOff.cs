using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOff : MonoBehaviour
{
    public GameObject player;
    public Transform respawn;
     void Start() {
       
    }

    private void OnTriggerEnter(Collider other){
        print("huh");
        if (other.gameObject.tag=="Player"){
            player.transform.position = new Vector3(respawn.position.x, respawn.position.y, respawn.position.z);
        
         }

    }
}

