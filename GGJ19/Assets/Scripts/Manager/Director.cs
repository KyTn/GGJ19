using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public static Director Instance;

    public bool DEBUG_MODE = false;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Director already exists");
            return;
        }
        Instance = this;
    }

}
