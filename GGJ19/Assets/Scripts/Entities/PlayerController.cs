using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    Rigidbody rBody;
    public float speedMovement = 1f;
    public float speedRotate = 1f;


    // Use this for initialization
    void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
            // Movement
            rBody.velocity = (Vector3.Normalize(transform.forward * InputController.Instance.forward) +
                                (-1 * transform.forward * InputController.Instance.backward) +
                                (-1 * transform.right * InputController.Instance.left) +
                                (transform.right * InputController.Instance.right))
                                * speedMovement

                                + rBody.velocity.y * Vector3.up;


            //// Rotate camera
            //Quaternion q = Quaternion.identity;
            //q.eulerAngles = transform.rotation.eulerAngles +
            //                (Vector3.up * InputController.instance.mouseYPos +
            //                Vector3.down * InputController.instance.mouseYNeg)
            //                * speedRotate;
            //transform.rotation = q;
        
    }

}
