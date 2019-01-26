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

    bool isLeft;
    bool isRight;
    bool isDown;
    bool isUp;
    bool isIdle;

    // Use this for initialization
    void Awake()
    {
        rBody = GetComponent<Rigidbody>();
        instance = this;
        isLeft = false;
        isRight = false;
        isDown = true;
        isUp = false;
        isIdle = false;
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

            if (rBody.velocity.x > 0) {
                isLeft = false;
                isRight = true;
            } // isLeft
            if (rBody.velocity.x < 0) {
                isLeft = true;
                isRight = false;
            } // isRight
            if (rBody.velocity.z > 0) {
                isUp = true;
                isDown = false;
            } // isUp
            if (rBody.velocity.z < 0) {
                isUp = false;
                isDown = true;
            } // isDown
            if (rBody.velocity.z != 0 && rBody.velocity.x == 0) {
                isLeft = false;
                isRight = false;
            }
            if (rBody.velocity.z == 0 && rBody.velocity.x == 0) {
                isIdle = true;
            } else {
                isIdle = false;
            }
            if (isLeft) {
                GetComponent<SpriteRenderer>().flipX = true;
            } else {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            string animString = "P-";
            if (isIdle)
                animString += "Idle";
            else
                animString += "Walk";
            if (isLeft || isRight)
                animString += "Right";
            if (isUp)
                animString += "Up";
            if (isDown)
                animString += "Down";

            Debug.Log($"AnimString: {GetComponent<SpriteRenderer>().flipX} - {rBody.velocity}");

            Animator anim = GetComponent<Animator>();
            anim.Play(animString);
        }

        if (InputController.Instance.AButton > 0)
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
