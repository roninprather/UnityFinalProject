using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIJump : MonoBehaviour
{
    public Transform returnPoint;
    public UnityEngine.AI.NavMeshAgent enemy;
    public Animator anim;
    public GameObject player;
    private bool headPos = true;
    public Transform respawn;
    [Range(0,1)]public float weight = 1;
    [Range(0,1)]public float headWeight = 1;
    [Range(0,1)]public float bodyWeight = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       anim.SetFloat("velocity",  enemy.velocity.magnitude);
                    
    
        
    }

    private void OnTriggerStay(Collider other){
        if (other.gameObject.tag=="Player"){
            enemy.destination = other.transform.position;
            if (Vector3.Distance(transform.position, other.transform.position) < 1f){
                other.transform.position = respawn.position;
            }
    }
    }
     private void OnTriggerExit(Collider other){
        if (other.gameObject.tag=="Player"){
            enemy.destination = returnPoint.position;
    }
    }
    
    void OnAnimatorIK(){
        if (headPos){
             anim.SetLookAtWeight(weight, bodyWeight, headWeight);
        anim.SetLookAtPosition(player.transform.position);
        }
    }
}
