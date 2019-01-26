using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    public Camera Camera;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("GameManager already exists");
            return;
        }
        Instance = this;
    }

    public Transform InDialogLocalPosition;
    public Transform InWorldLocalPosition;


}
