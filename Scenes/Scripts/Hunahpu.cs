using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunahpu : MonoBehaviour
{


    public GameObject input = null;
    public GameObject huCam;

    public bool hasBall;

    public bool holdingBallAnim;

    // fields for ability
    public GameObject blowgun;
    public GameObject bullet;
    public bool isAiming;
    public int cooldown;
    public int aimCooldown = 0;

    public PlayerController pc = null;

    public GameObject mayanBall;
    public GameObject mayanBallRAW;

    public GameObject rawBall;
    public float launchVelocity = 700f;

    public Rigidbody rb;

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        huCam = GameObject.Find("HuCam");
        hasBall = false;
        holdingBallAnim = false;
        rb = GetComponent<Rigidbody>();
        isAiming = false;
        cooldown = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(input==null) {
            input = GameObject.Find("Player(Clone)");
            if(input != null) {
                pc = input.GetComponent<PlayerController>();
                input.name = "HunahpuController";
            }
            
        }
        else {
            HandleMovement(pc.GetMovementInput());
            HandleBall(pc.GetBall());
            HandleAim(pc.GetAim());
            HandleAbility(pc.GetAbility());
            // Do stuff here
        }
    }

    void HandleMovement(Vector2 input) {

        Vector3 desiredVelocity = input.x * transform.right + input.y * transform.forward;
        rb.MovePosition(this.transform.position + desiredVelocity * speed * Time.deltaTime);
    
    }

    public PlayerController GetPlayerController() {
        return pc;
    }

    public void HandleBall(bool ball) {
        if(ball == true && hasBall == true) {
            pc.ResetBall();

            // Vector3 v3Force = launchVelocity * XCam.transform.forward;


            GameObject newBall = Instantiate(mayanBall, huCam.transform.position, huCam.transform.rotation);
            newBall.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * launchVelocity);
            hasBall = false;
            Destroy(rawBall);
            holdingBallAnim = false;
        }
        if(!holdingBallAnim && hasBall) {
            // Instantiate a child that will be found directly in front of the player
            rawBall = Instantiate(mayanBallRAW);
            rawBall.transform.parent = this.transform;
            rawBall.transform.localPosition = new Vector3(.187f, 1.154f, .409f);
            holdingBallAnim = true;

        }
    }

   public void HandleAbility(bool ability){
       if(isAiming && ability && cooldown ==0) {
            GameObject newBall = Instantiate(bullet, blowgun.transform.position, huCam.transform.rotation);
            //newBall.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000); 


            cooldown = 100;
       }
       if(cooldown > 0) {
           cooldown--;
       }
   }

   public void HandleAim(bool rightTrigger) {
       bool done = false;
       if(rightTrigger && isAiming && aimCooldown == 0) {
            //remove the thing
            blowgun.SetActive(false);

            isAiming = false;
            done = true;
            aimCooldown = 20;
       }
       if(rightTrigger && !isAiming && !done && aimCooldown == 0) {
           //add the thing
           blowgun.SetActive(true);
           isAiming = true;
           aimCooldown = 20;
       }
       if(aimCooldown > 0) {
           aimCooldown--;
       }
   }
}
