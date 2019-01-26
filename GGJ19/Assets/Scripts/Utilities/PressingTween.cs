using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PressingTween : MonoBehaviour
{
    RectTransform image;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<RectTransform>();
    }

    void Start()
    {
        DOTween.Sequence()
            .Append(image.DOScale(1.2f, 0.9f))
            .Append(image.DOScale(1f, 0.9f))
            .SetLoops(-1);
    }
}
