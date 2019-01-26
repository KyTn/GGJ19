using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InGameStates
{
    InWorld = 0, 
    InDialog = 1
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public InGameStates InGameStates;

    public Transform InDialogLocalPosition { get; set; }
    public Transform InWorldLocalPosition { get; set; }




    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("GameManager already exists");
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        InGameStates = InGameStates.InDialog;
    }

    public void ChangeToInDialog()
    {


        CameraController.Instance.Camera.transform.DOMove(InDialogLocalPosition.position, 0.8f);
    }

    public void ChangeToInWindow()
    {
        CameraController.Instance.Camera.transform.DOMove(InWorldLocalPosition.position, 0.8f);
    }



}
