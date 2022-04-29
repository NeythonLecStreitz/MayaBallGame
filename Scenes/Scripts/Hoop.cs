using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{

    public bool hasBeenShot;

    void Start() {
        hasBeenShot = false;
    }


    public bool getHasBeenShot() {
        return hasBeenShot;
    }


    void OnCollisionEnter(Collision other) {
        //print("sup");
        if(other.gameObject.name == "MayanBall(Clone)") {
            // Hello World
            //print("ayo");
            hasBeenShot = true;
        }
    }

}
