using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool hasKey;
    public bool canOpen;
    public GameObject door;
    public GameObject noKeyMessage;
    public GameObject haveKeyMessage;
    public Animator doorSwing;

    void Start()
    {
        doorSwing = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            doorSwing.SetBool("Open", true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (hasKey) {
                canOpen = true;
                StartCoroutine(haveKey());
            }
            else {
                print("Need to find the gold key!");
                StartCoroutine(noKey());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            canOpen = false;
        }
    }
    
    IEnumerator noKey()
    {
        noKeyMessage.SetActive(true);
        yield return new WaitForSeconds(10);
        noKeyMessage.SetActive(false);
    }
    
    IEnumerator haveKey()
    {
        haveKeyMessage.SetActive(true);
        yield return new WaitForSeconds(10);
        haveKeyMessage.SetActive(false);
    }
}