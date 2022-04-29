using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayaBall : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) {
        
        string otherName = other.gameObject.name;
        if(otherName.Equals("Hunahpu")) {
            // adjust hunahpu script variable
            //print("Triggered with hunahpu");
            Hunahpu hunahpu = other.gameObject.GetComponent<Hunahpu>();
            hunahpu.hasBall = true;
            Destroy(this.gameObject);

        }
        else if(otherName.Equals("Xbalanque")) {
            // adjust xbalanque script variable
            //print("Triggered with xblanaque");
            Xbalanque xbalanque = other.gameObject.GetComponent<Xbalanque>();
            xbalanque.hasBall = true;
            Destroy(this.gameObject);

        } else {
            //print(other.gameObject.name);
            //print("Should not die here");
        }
    }
}
