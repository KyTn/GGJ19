using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class MapManager : MonoBehaviour
{

    public static MapManager Instance;

    public int CurrentMapId = -1;

    public GameObject FirstFocus; 

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("MapManager already exists");
            return;
        }
        Instance = this;

    }
    
    public void GoToVillage(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void StartMap()
    {
        EventSystem.current.SetSelectedGameObject(FirstFocus);
    }


    public void CloseMap()
    {
        GameManager.Instance.ChangeToInWindow(() => PlayerController.instance.Stop = false);
    }

}
