using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //mobility
    public float tester ;
    public float frontBackVelocity;
    public float leftRightVelocity;
    private Vector3 forward;
    private Vector3 left;
    private Vector3 right;
    private Vector3 back;
    public Rigidbody rb;
    private float lookSpeed = 1;
    public AudioClip jumpSound;
    public AudioClip footStep;

    //game control
    public bool paused = false;

    //grounded detection
    public bool airborne = false;
    private Ray ray;
    private RaycastHit hit;
    private float rayDist = 2.75f;
    public int wait = 0;
    private bool coyote = true;
    

    //animation
    public Transform head;
    public CapsuleCollider playerCollider;
    public Animator anim;
    private AudioSource speaker;

    //constants
    private const int SPEED = 10;
    private const int JUMPHEIGHT = 12;
    private const int MAX_VELOCITY = 15;

    // Start is called before the first frame update
    void Start()
    {
        head.Rotate(-6f, 0, 0);
        speaker = GetComponent<AudioSource>();

    }

    public void playFootStep(){
         if (!airborne){
             speaker.PlayOneShot(footStep);
         }
    }

    private void FixedUpdate()
    {
        ray = new Ray(transform.position + new Vector3(0, playerCollider.center.y + 1f, 0), transform.up * -1.0f);
        Debug.DrawRay(ray.origin, ray.direction * rayDist, Color.red);

        if (!Physics.Raycast(ray, out hit, rayDist) && coyote)
        {
            wait++;
        }

        else if (Physics.Raycast(ray, out hit, rayDist))
        {
            coyote = true;
            airborne = false;
        }

        if (wait == 5)
        {
            airborne = true;
            wait = 0;
            coyote = false;
        }
        if (!paused)
        {
            if (frontBackVelocity < 0)
            {
                rb.AddForce(forward * SPEED / 2);
            }

            if (Input.GetKey(KeyCode.W) && !airborne && (frontBackVelocity < MAX_VELOCITY)){
                rb.AddForce(forward * SPEED);
            }
            else if (!airborne && frontBackVelocity > 0) rb.AddForce(back * SPEED / 2);
            if (Input.GetKey(KeyCode.S))
                rb.AddForce(back * SPEED);
            if (Input.GetKey(KeyCode.A) && leftRightVelocity < 5)
                rb.AddForce(left * SPEED);
            if (Input.GetKey(KeyCode.D) && leftRightVelocity > -5)
                rb.AddForce(right * SPEED);
            if (Input.GetKey(KeyCode.LeftShift))
                rb.AddForce(new Vector3(0, 2, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        tester = rb.velocity.magnitude;
        if (!paused)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                lookSpeed = 0.25f;
            }
            else lookSpeed = 1.5f;

            if (Input.GetAxis("Mouse X") > 0 )
                gameObject.transform.Rotate(0, 1 * lookSpeed, 0);
            if (Input.GetAxis("Mouse X") < 0)
                gameObject.transform.Rotate(0, -1 * lookSpeed, 0);

            if (Input.GetAxis("Mouse Y") < 0  &&  head.transform.rotation.eulerAngles.x < 358)
                head.Rotate(0.75f * lookSpeed, 0, 0);
            if (Input.GetAxis("Mouse Y") > 0 &&  head.transform.rotation.eulerAngles.x > 280)
                head.Rotate(-0.75f * lookSpeed, 0, 0);

            if (Input.GetKeyDown(KeyCode.Space) && !airborne){
                speaker.PlayOneShot(jumpSound);
                rb.velocity = (new Vector3(rb.velocity.x, JUMPHEIGHT, rb.velocity.z));
            }
        }

        forward = transform.TransformDirection(Vector3.forward);
        left = transform.TransformDirection(Vector3.left);
        right = transform.TransformDirection(Vector3.right);
        back = transform.TransformDirection(Vector3.back);

        frontBackVelocity = Vector3.Dot(rb.velocity, forward);
        leftRightVelocity = Vector3.Dot(rb.velocity, left);


      
      
        //animation controls
        if (Mathf.Abs(frontBackVelocity) > 1 || Mathf.Abs(leftRightVelocity) > 1)
        {
            anim.SetBool("isRunning", true);
            anim.SetFloat("speed", Mathf.Max(Mathf.Abs(frontBackVelocity), Mathf.Abs(leftRightVelocity)) / 10);
        }
        else anim.SetBool("isRunning", false);
        anim.SetBool("isJumping", airborne);
    }
}