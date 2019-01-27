using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoFocusOnStart : MonoBehaviour
{
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
