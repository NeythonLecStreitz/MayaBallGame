using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayaBallParticle : MonoBehaviour
{


    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(pos.y < -1) {
            print("AHH");
            rb.velocity = new Vector3(0,0,0);
            pos.y = 1;
            transform.position = pos;
        }
    }

    void OnCollisionEnter(Collision other) {

        string objName = other.gameObject.layer.ToString();
        //print(objName);
        //print(other.gameObject.name);
        if(objName == "8" && transform.position.y < .2) {
            // Upon Collision, make the gameobject pickup-able again
            print("testing");
            this.gameObject.layer = LayerMask.NameToLayer("Default");

            
            SphereCollider test = GetComponent<SphereCollider>();

            test.isTrigger = true;
            test.radius = 2f;
            rb.velocity = new Vector3(0, 0, 0);

            Destroy(rb);
        }

    }

    void OnCollisionStay(Collision other) {

        string objName = other.gameObject.layer.ToString();
        //print(objName);
        //print(other.gameObject.name);
        if(objName == "8" && transform.position.y < .2) {
            // Upon Collision, make the gameobject pickup-able again
            //print("testing");
            this.gameObject.layer = LayerMask.NameToLayer("Default");

            
            SphereCollider test = GetComponent<SphereCollider>();

            test.isTrigger = true;
            test.radius = 1.5f;
            rb.velocity = new Vector3(0, 0, 0);

            Destroy(rb);
        }

    }
}
