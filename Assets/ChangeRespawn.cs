using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRespawn : MonoBehaviour
{
    public Level1Respawn respawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respawner.currentRespawn = gameObject.transform;
        }
    }
}
