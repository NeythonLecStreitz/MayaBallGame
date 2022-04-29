using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuFPSCam : MonoBehaviour
{
    public GameObject parent;
    public PlayerController pc;
    public Rigidbody rb;

    public float sensitivity = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        parent = this.transform.parent.gameObject;
        if (pc == null) {
            if(parent.GetComponent<Hunahpu>().GetPlayerController() != null) {
                this.pc = parent.GetComponent<Hunahpu>().GetPlayerController();
            }
        }
        else {
            Vector2 lookTest = pc.GetLookInput();
            HandleLook(lookTest);
        }
    }


    void HandleLook(Vector2 input) {
        Vector3 yInput;
        Vector3 xInput = new Vector3(0, input.x, 0);
        yInput = new Vector3(input.y, 0, 0);

        /*if((transform.rotation.x <= -.35 &&  input.y > 0) || (transform.rotation.x >= .35 &&  input.y < 0) || transform.rotation.x > -.35 && transform.rotation.x < .35) {

            
        }
        else {
            yInput = new Vector3(0, 0, 0);
        }*/
        
        transform.Rotate(-yInput * Time.deltaTime * sensitivity);
        parent.transform.Rotate(xInput * Time.deltaTime * sensitivity);

        // Constantly modify the rotation if necessary
        Vector3 temp = transform.rotation.eulerAngles;
        if(temp.x >= 30f && temp.x <= 90) {
            temp.x = 29;
            transform.rotation = Quaternion.Euler(temp.x, temp.y, temp.z);
        } else if(temp.x >= 90 && temp.x <= 320f) {
            temp.x = 320f;
            transform.rotation = Quaternion.Euler(temp.x, temp.y, temp.z);
        }
        else {
            // Do nothing
        }

        

    }
}