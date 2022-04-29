using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInteract : MonoBehaviour
{
        [SerializeField] private bool triggerActive = false;



        public Hoop leftHoop;
        public Hoop rightHoop;
        public GameObject TextPopUp;
        private bool hoopsGone = false;


        void Start() {
            leftHoop = GameObject.Find("LeftHoopCylinder").GetComponent<Hoop>();
            rightHoop = GameObject.Find("RightHoopCylinder").GetComponent<Hoop>();

        }
 
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                triggerActive = true;
                

                if (TextPopUp)
                {
                    ShowFloatingText();
                    print("Entered...");
                }

                if (hoopsGone){
                    print("Teleported...");
                }

            }
        }
 
        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                triggerActive = false;
                //DestroyFloatingText();
            }
        }

        void ShowFloatingText()
        {
            Vector3 offset = new Vector3(0, 1.358f, -0.457f);
            Vector3 position = transform.position + offset;
            Instantiate(TextPopUp, position, Quaternion.identity, transform);
        }

        void DestroyFloatingText()
        {
            Destroy(TextPopUp);
        }
 
         void Update()
        {
            print(leftHoop.getHasBeenShot());
            print(rightHoop.getHasBeenShot());
            if(leftHoop.getHasBeenShot() && rightHoop.getHasBeenShot()) {
                print("ayo");
                this.gameObject.SetActive(false);
                hoopsGone = true;
            }
            
        }
        
 
        public void SomeCoolAction()
        {
 
        }
}