using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public LockedDoor door;
    public GameObject KeyActual;
    public GameObject KeyIcon;

    private void Start() {
        KeyIcon.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.hasKey = true;
            print(other.gameObject.name + " has obtained the key!");
            KeyActual.SetActive(false);
            KeyIcon.SetActive(true);
        }
    }

}