using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public GameObject Target;

    public Vector3 lookat;
    void Update()
    {
        if (GameManager.Instance.InGameStates == InGameStates.InDialog)
        {
            lookat = Vector3.right * Target.transform.position.x +
             Vector3.up * transform.position.y +
             Vector3.forward * Target.transform.position.z;

            transform.LookAt(lookat);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + lookat);
    }

}
