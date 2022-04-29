using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField]
    int speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredVelocity = transform.forward;
        rb.MovePosition(this.transform.position + desiredVelocity * speed * Time.deltaTime);
    }


}
