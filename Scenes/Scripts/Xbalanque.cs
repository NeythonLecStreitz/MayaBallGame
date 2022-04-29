using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbalanque : MonoBehaviour
{


    public GameObject input = null;
    public GameObject mayanBall;
    public GameObject XCam;

    public GameObject lightObject;
    public Light aura;

    public bool hasBall;

    public PlayerController pc = null;
    public float launchVelocity = 700f;


    public bool holdingBallAnim;
    public GameObject mayanBallRAW;

    public GameObject rawBall;

    public Rigidbody rb;

    public int cooldown;
    public int abilityforce;
    public int lightCooldown;

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        XCam = GameObject.Find("XCam");
        hasBall = false;
        holdingBallAnim = false;
        cooldown = 0;
        abilityforce = 10;
        rb = GetComponent<Rigidbody>();

        aura = lightObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(input==null) {
            input = GameObject.Find("Player(Clone)");
            if(input != null) {
                pc = input.GetComponent<PlayerController>();
                input.name = "XbalanqueController";
            }
            
        }
        else {
            HandleMovement(pc.GetMovementInput());
            HandleBall(pc.GetBall());
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


            GameObject newBall = Instantiate(mayanBall, XCam.transform.position, XCam.transform.rotation);
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


    public void HandleAbility(bool ability) {
        if(ability && cooldown == 0) {
            //print("I should ddo something");
            Vector3 desiredVelocity =  1 * transform.forward * abilityforce;
            rb.MovePosition(this.transform.position + desiredVelocity * speed * Time.deltaTime);
            cooldown = 100;
            lightCooldown = 25;
            lightObject.SetActive(true);
        }
        if(cooldown > 0) {
            cooldown--;
        }
        if(lightCooldown > 0) {
            lightCooldown --;
            aura.intensity = aura.intensity - 4;

            if(lightCooldown == 0) {
                aura.intensity = 100;
                lightObject.SetActive(false);
            }
        }

    }
}
