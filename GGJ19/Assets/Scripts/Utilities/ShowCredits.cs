using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour
{
    public bool isShowing = false;
    RectTransform rectt;

    private void Awake()
    {
        rectt = GetComponent<RectTransform>();
    }

    public void SHOWORHIDE()
    {
        if (isShowing)
        {
            rectt.DOAnchorPosX(-800, 0.9f); isShowing = false;
        }
        else
        {

            rectt.DOAnchorPosX(0, 0.9f); isShowing = true;
        }
    }

    
}
