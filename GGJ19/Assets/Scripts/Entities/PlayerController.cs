using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    Rigidbody rBody;
    public float speedMovement = 1f;
    public float speedRotate = 1f;

    public bool Stop; 
    
    void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        instance = this;
    }
   
    void Update()
    {
        if (Stop)
        {
            return;
        }
        if (GameManager.Instance.InGameStates == InGameStates.InWorld)
        {
            // Movement
            rBody.velocity = (Vector3.Normalize(transform.forward * InputController.Instance.forward) +
                                (-1 * transform.forward * InputController.Instance.backward) +
                                (-1 * transform.right * InputController.Instance.left) +
                                (transform.right * InputController.Instance.right))
                                * speedMovement
                                + rBody.velocity.y * Vector3.up;
            
        }

        if(InputController.Instance.AButton > 0)
        {
            if (GameManager.Instance.InGameStates == InGameStates.InWorld)
            {
                Stop = true;
                GameManager.Instance.ChangeToInDialog(() => Stop = false);
            }
            else if (GameManager.Instance.InGameStates == InGameStates.InDialog)
            {
                Stop = true;
                GameManager.Instance.ChangeToInWindow(() => Stop = false);
            }
        }
        
    }

}
