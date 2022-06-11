using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Respawn : MonoBehaviour
{
    public Transform currentRespawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = currentRespawn.transform.position;
        }
    }
}
