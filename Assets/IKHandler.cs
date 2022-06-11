using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHandler : MonoBehaviour
{
 Animator anim;
 public Transform IKTargetRightHand;
 public bool handPosisiotnEnabled=false;
 [Range(0,1)]public float ikPositionWeightRightHand = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    void OnAnimatorIK()
    {
        if (handPosisiotnEnabled){
            SetHandPosition();
        }
    }


    
    private void SetHandPosition(){
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, ikPositionWeightRightHand);
        anim.SetIKPosition(AvatarIKGoal.RightHand, IKTargetRightHand.position);
    }
  }

