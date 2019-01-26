using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum InGameStates
{
    InWorld = 0, 
    InDialog = 1
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public InGameStates InGameStates;



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
        InGameStates = InGameStates.InWorld;
        //Dialog testDialog = new Dialog();
    }

    public void ChangeToInDialog(Action callbackWhenCompleteTween)
    {
        CameraManager.Instance.Camera.transform.DOLocalRotateQuaternion(
            CameraManager.Instance.InDialogLocalPosition.localRotation, 0.8f);

        CameraManager.Instance.Camera.transform.DOMove(
            CameraManager.Instance.InDialogLocalPosition.position, 0.8f)
            .OnComplete(() => callbackWhenCompleteTween?.Invoke());
        InGameStates = InGameStates.InDialog;
    }

    public void ChangeToInWindow(Action callbackWhenCompleteTween)
    {
        CameraManager.Instance.Camera.transform.DOLocalRotateQuaternion(
            CameraManager.Instance.InWorldLocalPosition.localRotation, 0.8f);

        CameraManager.Instance.Camera.transform.DOMove(
            CameraManager.Instance.InWorldLocalPosition.position, 0.8f)
            .OnComplete(() => callbackWhenCompleteTween?.Invoke());
        InGameStates = InGameStates.InWorld;
    }



}
