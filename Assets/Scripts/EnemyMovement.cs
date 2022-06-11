using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    public GameObject player;
    public Transform[] points;
    private int i =0;
    private int phase;
    public bool hooked;
    public float waitSec;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(player.GetComponent<CapsuleCollider>(), GetComponent<CapsuleCollider>());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hooked){
             StartCoroutine(pause());
        }
        if (Vector3.Distance(player.transform.position, points[2].position) < 10f){
            phase = 4;
        }else if (Vector3.Distance(player.transform.position, points[0].position) < 10f){
            phase = 2;
        }else{
            phase = 0;
        }

         if (!enemy.pathPending && enemy.remainingDistance < 0.5f){

        i = (i+1) % 2;
         }
         enemy.destination = new Vector3(points[phase+i].position.x, points[phase+i].position.y, points[phase+i].position.z);
    }

     IEnumerator pause()
    {
       
        
        enemy.isStopped = true;
       yield return new WaitForSeconds(waitSec);
       hooked = false;
          
        enemy.isStopped = false;;
       
    }
}
