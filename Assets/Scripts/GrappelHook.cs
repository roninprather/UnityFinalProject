using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrappelHook : MonoBehaviour
{
 public Vector3 startPos;
 public Vector3 endPos;
 private float lerpDuration = 2; 
 public GameObject camObj;
 public Camera cam;
 private Ray ray;
 private RaycastHit hit;
 private float rayDist = 50f;
 public Image reticle;
 public bool hasHook = false;
 Animator anim;
 public Transform camPoint;
 private Transform IKTargetRightHand ;
 
 public bool handPos=false;
 [Range(0,1)]public float IKGoal = 1;
 public Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        IKTargetRightHand = camPoint;

    }

    void OnAnimatorIK(){
        if (handPos){
            SetHandPosition();
        }
    }
    private void SetHandPosition(){
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IKGoal);
        anim.SetIKPosition(AvatarIKGoal.RightHand, IKTargetRightHand.position);
    }

    // Update is called once per frame
    void Update()
    {
           
        if (hasHook){
            if (Input.GetKeyDown(KeyCode.Z)){
                IKTargetRightHand = camPoint;
                cam.fieldOfView=20f;
                reticle.enabled = true;
                handPos = true;
            }

            if (Input.GetKeyUp(KeyCode.Z)){
                reticle.enabled = false;
                cam.fieldOfView=80f;
                ray = new Ray(camObj.transform.position, camObj.transform.forward);
                Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.red);
                if (Physics.Raycast(ray, out hit, rayDist)){
                        if (hit.collider.gameObject.tag == "Hook") {
                            startPos = transform.position;
                            endPos = hit.collider.gameObject.transform.position;
                            IKTargetRightHand = hit.collider.gameObject.transform;
                            rigid.isKinematic = true;
                            StartCoroutine(Lerp());
                            
                        }else if (hit.collider.gameObject.tag == "Drone") {
                            startPos = transform.position;
                            endPos = hit.collider.gameObject.transform.position;
                            IKTargetRightHand = hit.collider.gameObject.transform;
                            hit.collider.gameObject.GetComponent<EnemyMovement>().waitSec = lerpDuration;
                            hit.collider.gameObject.GetComponent<EnemyMovement>().hooked = true;
                            rigid.isKinematic = true;
                            StartCoroutine(Lerp());
                        }else{
                            handPos = false;
                        }
                }else {
                    handPos = false;
                }
                
                
            }
            
        }
    }
    

    IEnumerator Lerp()
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            transform.position=Vector3.Lerp(startPos,new Vector3 (endPos.x, endPos.y + 0.5f, endPos.z),timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
             yield return null;
        }
        rigid.isKinematic = false;
        handPos = false;
    
    }
}