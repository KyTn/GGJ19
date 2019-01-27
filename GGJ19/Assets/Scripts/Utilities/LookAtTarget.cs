using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public GameObject TargetInDialog;
    public GameObject TargetInWorld;

    public Vector3 lookat;
    void Update()
    {
        if (GameManager.Instance.InGameStates == InGameStates.InDialog)
        {
            lookat = Vector3.right * TargetInDialog.transform.position.x +
             Vector3.up * transform.position.y +
             Vector3.forward * TargetInDialog.transform.position.z;

            transform.LookAt(lookat);
        }
        else
        {
            lookat = Vector3.right * TargetInWorld.transform.position.x +
                Vector3.up * transform.position.y +
                Vector3.forward * TargetInWorld.transform.position.z;

            transform.LookAt(lookat);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + lookat);
    }

}
