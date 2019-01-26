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


    Animator anim;
    SpriteRenderer spriteRenderer;


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

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Stop)
        {
            spriteRenderer.flipX = true;
            anim.Play("P-IdleRightUp");
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
                spriteRenderer.flipX = true;
            } else {
                spriteRenderer.flipX = false;
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

            //Debug.Log($"AnimString: {GetComponent<SpriteRenderer>().flipX} - {rBody.velocity}");

            anim.Play(animString);
        }

        if (InputController.Instance.AButton > 0)
        {
            DialogManager.Instance.StartDialog();
        }

    }

}
